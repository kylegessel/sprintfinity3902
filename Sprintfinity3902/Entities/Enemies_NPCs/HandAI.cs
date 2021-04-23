using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Sprintfinity3902.Entities.Enemies_NPCs
{
    public class HandAI
    {
        private static float ERROR_DISPLACEMENT_LENGTH = 2.4f;
        private static int REFERENCE_POINT_Y = 96;
        private static int REFERENCE_POINT_X = 32;
        private static int SCALED_TILE_SIDE_LENGTH = Global.Var.TILE_SIZE * Global.Var.SCALE;
        private static Vector2[] UNIT_TILE_VECTORS = new Vector2[] {
            new Vector2(0, 0),
            new Vector2(SCALED_TILE_SIDE_LENGTH, 0),
            new Vector2(SCALED_TILE_SIDE_LENGTH, SCALED_TILE_SIDE_LENGTH),
            new Vector2(0, SCALED_TILE_SIDE_LENGTH)
        };
        private static Vector2 REFERENCE_POINT = new Vector2(REFERENCE_POINT_X * Global.Var.SCALE, REFERENCE_POINT_Y * Global.Var.SCALE);

        /* Route to player as a queue of tuple <x, y> */
        private Queue<Tuple<int, int>> route;
        /* A bool matrix of whether or not a block is present
         * NOTE: Only checks for "BLOK" in csv
         * imp below
         */
        private bool[,] pathMatrix;
        private IEnemy handRef;
        private AbstractEntity.Direction lastDirection;
        private Tuple<int, int> lastPlayerTile;
        private bool coolDown;
        private int count;

        public HandAI(IRoom _room, IEnemy _handRef)
        {
            pathMatrix = new bool[7, 12];
            parseRoomLayout(_room.path);
            handRef = _handRef;
            count = 0;
            coolDown = false;
            lastDirection = AbstractEntity.Direction.NONE;
            route = new Queue<Tuple<int, int>>();
            route.Enqueue(demap(_handRef.Position));
        }

        /* Abstracts the room to a boolean matrix based of elgibility of traversal */
        private void parseRoomLayout(string path)
        {
            StreamReader sr = new StreamReader(path);

            sr.ReadLine();
            sr.ReadLine();

            for (int i = 0; i < Global.Var.TILE_ROW_NUM; i++) {
                string line = sr.ReadLine();
                if (!string.IsNullOrWhiteSpace(line)) {
                    string[] lineValues = line.Split(',');

                    if (lineValues.Length > Global.Var.TILE_COLUMN_NUM) {
                        throw new Exception("" + path + " is not formatted correctly. Expected " + Global.Var.TILE_COLUMN_NUM + " items, got " + lineValues.Length + " from string: '" + line + "'");
                    }

                        for (int j = 0; j < lineValues.Length; j++) {
                            pathMatrix[i, j] = lineValues[j] != "BLOK";
                        }
                    
                    
                }
            }

            sr.Close();
        }

        /* Returns the difference of two vectors, a - b */
        private Vector2 deltaVec(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        /* Returns the magnitude of a vector, |a| */
        private float magVec(Vector2 a)
        {
            return (float)Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }

        /* Determines if the hand position in on an intersection:
         * if true:
         *      returns the position of the tile that the hand is 'on'
         * else:
         *      returns Vector2.Zero which is considered as null (Vector2 cannot be null so this is workaround)
         * 
         * def 'on' to be a boolean evaluated to true iff the distance from any block's upper left point is less than
         *      the ERROR_DISPLACEMENT_LENGTH and coolDown == false
         * */
        private Vector2 isOnIntersection(Vector2 myPos)
        {
            // The vector from the upper left of the room--REFERENCE_POINT--to the hands upper-left position
            Vector2 relativePositionVec = deltaVec(myPos, REFERENCE_POINT);

            // Defines the vector to the position of the tile whose body contains the position of hand
            Vector2 normRPV = new Vector2(relativePositionVec.X % SCALED_TILE_SIDE_LENGTH, relativePositionVec.Y % SCALED_TILE_SIDE_LENGTH);

            /* Defines an enumerable object of a subset of UNIT_TILE_VECTORS
             * where each member's distance to the normRPV is less than the ERROR_DISPLACEMENT_LENGTH
             * 
             * Re-explained, this selects a vector(s) from UNIT_TILE_VECTORS iff its distance from the 
             * normRPV is less than ERROR_DISPLACEMENT_LENGTH
             * 
             * This determines if the hand is on a tile intersection and if it is the tile the hand is in, 
             * the tile to the bottom, the tile to the right, or the tile which is diagonal from the tile
             */
            IEnumerable<Vector2> selected = (IEnumerable<Vector2>)UNIT_TILE_VECTORS.Where(x => magVec(deltaVec(x, normRPV)) < ERROR_DISPLACEMENT_LENGTH);

            // If more than one vector is selected, then error because the displacement is far too large
            if (selected.Count() > 1) throw new Exception("The error displacement length is too large");

            // If the hand is close to a vertex
            if (selected.Count() > 0) {
                // Take the position of the hand and map it to the tile; don't round it
                Tuple<int, int> mytile = demap(myPos, rounded: false);
                // Return the (perfect) position of the tile which the hand is intersecting with
                return new Vector2(mytile.Item1 * SCALED_TILE_SIDE_LENGTH + selected.First().X + REFERENCE_POINT.X, mytile.Item2 * SCALED_TILE_SIDE_LENGTH + selected.First().Y + REFERENCE_POINT.Y);
            }

            // Return the zero vector which the reciever should interpret as null since (0, 0) is not in the tile map position
            return Vector2.Zero;

        }

        /* This takes a position and determines which tile contains the position
         *
         * if rounded is true, only hands that are halfway or more into a tile are considered to be in that tile
         * 
         * else the tile will represent the literal tile which contains the position of the hand
         * 
         * for example, if each tile is split into four quadrants, when rounded is true, this function will
         * only return the tile if the position is in quadrant two,
         * otherwise if rounded is false, the function will return the tile iff 
         * the position is in any quadrant of the tile
         */
        private Tuple<int, int> demap(Vector2 pos, bool rounded = true)
        {
            Vector2 vec = deltaVec(pos, REFERENCE_POINT);

            if (rounded) {
                return new Tuple<int, int>((int)Math.Round(vec.X / (Global.Var.SCALE * Global.Var.TILE_SIZE)), (int)Math.Round(vec.Y / (Global.Var.SCALE * Global.Var.TILE_SIZE)));
            }

            return new Tuple<int, int>((int)(vec.X / (Global.Var.SCALE * Global.Var.TILE_SIZE)), (int)(vec.Y / (Global.Var.SCALE * Global.Var.TILE_SIZE)));
        }

        // Returns true if pathMatrix is true at a and the item is within the bounds of the tileset
        private bool isValid(Tuple<int, int> a)
        {
            return a.Item1 < Global.Var.TILE_COLUMN_NUM && a.Item1 >= Global.Var.ZERO && a.Item2 < Global.Var.TILE_ROW_NUM && a.Item2 >= Global.Var.ZERO && pathMatrix[a.Item2, a.Item1];
        }

        // Adds a (tile, path history) to l if 'tile' is valid and enqueues 'tile' to 'path history'
        private void addIfValid(List<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>> l, Tuple<Tuple<int, int>, Queue<Tuple<int, int>>> tile)
        {
            if (isValid(tile.Item1)) {
                tile.Item2.Enqueue(tile.Item1);
                l.Add(tile);
            }
        }

        /* Determines all valid adjacent tiles of a given tile and returns a list of them with path histories where the front of path history is
         * the adjacent tile 
         */
        private List<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>> adjacentTiles(Tuple<Tuple<int, int>, Queue<Tuple<int, int>>> tile)
        {
            List<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>> adj = new List<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>>();

            addIfValid(adj, new Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>(new Tuple<int, int>(tile.Item1.Item1 - 1, tile.Item1.Item2), new Queue<Tuple<int, int>>(tile.Item2)));
            addIfValid(adj, new Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>(new Tuple<int, int>(tile.Item1.Item1 + 1, tile.Item1.Item2), new Queue<Tuple<int, int>>(tile.Item2)));
            addIfValid(adj, new Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>(new Tuple<int, int>(tile.Item1.Item1, tile.Item1.Item2 - 1), new Queue<Tuple<int, int>>(tile.Item2)));
            addIfValid(adj, new Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>(new Tuple<int, int>(tile.Item1.Item1, tile.Item1.Item2 + 1), new Queue<Tuple<int, int>>(tile.Item2)));

            return adj;

        }

        /* BFS for finding the shortest path to the player */
        private Queue<Tuple<int, int>> determineBestPath(Tuple<int, int> myTile, Tuple<int, int> playerTile)
        {
            // BFS - Referenced: https://www.geeksforgeeks.org/shortest-path-in-a-binary-maze/

            List<Tuple<int, int>> exploredNodes = new List<Tuple<int, int>>();

            Tuple<Tuple<int, int>, Queue<Tuple<int, int>>> mappedTile = new Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>(myTile, new Queue<Tuple<int, int>>());

            exploredNodes.Add(myTile);

            Queue<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>> toExplore = new Queue<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>>(adjacentTiles(mappedTile));

            while (toExplore.Count > 0) {

                Tuple<Tuple<int, int>, Queue<Tuple<int, int>>> item = toExplore.Dequeue();

                Tuple<int, int> tile = item.Item1;
                Queue<Tuple<int, int>> tilePath = item.Item2;

                if (exploredNodes.Contains(tile)) { continue; } else exploredNodes.Add(tile);

                if (tile.Equals(playerTile)) {
                    return tilePath;
                } else {
                    foreach (Tuple<Tuple<int, int>, Queue<Tuple<int, int>>> i in adjacentTiles(item)) {
                        toExplore.Enqueue(i);
                    }
                }

            }

            return new Queue<Tuple<int, int>>();

        }

        // Defines enum direction from a given tile to a different tile (dest & pos) should be cardinal to each other
        private AbstractEntity.Direction directionToTile(Tuple<int, int> dest, Tuple<int, int> pos)
        {
            if (dest.Item1 - pos.Item1 > 0) {
                return AbstractEntity.Direction.RIGHT;
            }
            if (dest.Item1 - pos.Item1 < 0) {
                return AbstractEntity.Direction.LEFT;
            }
            if (dest.Item2 - pos.Item2 > 0) {
                return AbstractEntity.Direction.DOWN;
            }
            if (dest.Item2 - pos.Item2 < 0) {
                return AbstractEntity.Direction.UP;
            }

            return AbstractEntity.Direction.NONE;
        }

        /*
         * Determines which direction a hand should take, given the player's position
         */
        public AbstractEntity.Direction WhichDirection(Vector2 myPos, Vector2 playerPos)
        {

            // Tile representation of the hand and player's position without rounding
            Tuple<int, int> currentPlayerTile = demap(playerPos);
            Tuple<int, int> currentMyTile = demap(myPos);

            // If an intersection has recently been found - wait
            if (coolDown) {
                count++;
                if (count > 3) {
                    coolDown = false;
                    count = 0;
                }
            } else {
                
                Vector2 nearestIntersection = isOnIntersection(myPos);

                // If a hand is on an intersection and (this is the first time this method is called or the best path has one more tile)
                if (nearestIntersection != Vector2.Zero && (route == null || route.Count > 0)) {
                    // Snap the hand's position to be perfectly aligned to tile (important to reduce movement errors from tile to tile)
                    handRef.Position = nearestIntersection;

                    // If the player has not moved tiles
                    if (currentPlayerTile.Equals(lastPlayerTile)) {
                        // Just grab the next tile in the queue
                        route.Dequeue();

                    } else { // player moved
                        // Re-route
                        route = determineBestPath(currentMyTile, currentPlayerTile);

                        lastPlayerTile = currentPlayerTile;
                    }

                    lastDirection = route.Count > 0 ? directionToTile(route.First(), currentMyTile) : lastDirection;
                    coolDown = true;

                }
            }

            return lastDirection;

        }

        /*
         * This is a dfs which is guaranteed to find a to b but not min a to b
         * therefore a bfs is implemented in its place
         * 
         private Queue<Tuple<int, int>> determineBestPath(Tuple<int, int> myTile, Tuple<int, int> playerTile, List<Tuple<int, int>> exploredNodes=null, int depth=0) {
            // BFS - Referenced: https://www.geeksforgeeks.org/shortest-path-in-a-binary-maze/

            if (myTile.Equals(playerTile)) { return new Queue<Tuple<int, int>>(new[] { playerTile }); }

            if (exploredNodes == null) {
                exploredNodes = new List<Tuple<int, int>>();
            } else if (exploredNodes.Contains(myTile)) {
                return null;
            }
            exploredNodes.Add(myTile);

            Queue<Tuple<int, int>> RIGHT, LEFT, DOWN, UP;

            Tuple<int, int> right, left, down, up;

            right = new Tuple<int, int>(myTile.Item1 + 1, myTile.Item2);
            left = new Tuple<int, int>(myTile.Item1 - 1, myTile.Item2);
            down = new Tuple<int, int>(myTile.Item1, myTile.Item2 + 1);
            up = new Tuple<int, int>(myTile.Item1, myTile.Item2 - 1);

            RIGHT = isValid(right) ? determineBestPath(right, playerTile, exploredNodes, depth: depth + 1) : null;
            UP = isValid(up) ? determineBestPath(up, playerTile, exploredNodes, depth: depth + 1) : null;
            LEFT = isValid(left) ? determineBestPath(left, playerTile, exploredNodes, depth: depth + 1) : null;
            DOWN = isValid(down) ? determineBestPath(down, playerTile, exploredNodes, depth: depth + 1) : null;
            

            IEnumerable<Queue<Tuple<int, int>>> results = new Queue<Tuple<int, int>>[4] { RIGHT, LEFT, DOWN, UP}
            .Where(x => x != null && x.First().Equals(playerTile));

            IEnumerable<int> resultCounts = results.Select(x => x.Count);

            if (results.Count() == 0) return null;

            Queue<Tuple<int, int>> bestPath = results.ToList()[indexOfMin(resultCounts.ToArray())];

            bestPath.Enqueue(myTile);

            if (depth == 0) {
                return new Queue<Tuple<int, int>>(bestPath.Reverse());
            }

            return bestPath;

        }
         */

    }
}