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

        private static float ERROR_DISPLACEMENT_LENGTH = 1.6f;
        private static int NINETY_SIX = 96;
        private static int THIRTY_TWO = 32;
        private static int SCALED_TILE_SIDE_LENGTH = Global.Var.TILE_SIZE * Global.Var.SCALE;
        private static Vector2[] UNIT_TILE_VECTORS = new Vector2[] {
            new Vector2(0, 0),
            new Vector2(SCALED_TILE_SIDE_LENGTH, 0),
            new Vector2(SCALED_TILE_SIDE_LENGTH, SCALED_TILE_SIDE_LENGTH),
            new Vector2(0, SCALED_TILE_SIDE_LENGTH)
        };
        private static Vector2 referencePos = new Vector2(THIRTY_TWO * Global.Var.SCALE, NINETY_SIX * Global.Var.SCALE);

        private Queue<Tuple<int, int>> route;

        private bool[,] pathMatrix;
        private IEnemy handRef;
        private AbstractEntity.Direction lastDirection;
        private bool coolDown;
        private int count;
        private Tuple<int, int> lastPlayerTile;

        public HandAI(IRoom _room, IEnemy _handRef)
        {
            //route = new Queue<Tuple<int, int>>();
            pathMatrix = new bool[7, 12];
            parseRoomLayout(_room.path);
            handRef = _handRef;
            count = 0;
            coolDown = false;
            lastDirection = AbstractEntity.Direction.NONE;
        }


        private void parseRoomLayout(string path)
        {
            StreamReader sr = new StreamReader(path);

            sr.ReadLine();
            sr.ReadLine();

            for (int i = 0; i < 7; i++)
            {
                string line = sr.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');

                    for (int j = 0; j < lineValues.Length; j++)
                    {
                        pathMatrix[i, j] = lineValues[j] != "BLOK";
                    }
                }
            }

            sr.Close();
        }

        private Vector2 deltaVec(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        private float magVec(Vector2 a)
        {
            return (float)Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }

        private Vector2 isOnIntersection(Vector2 myPos, bool printDis = false)
        {
            Vector2 relativePositionVec = deltaVec(myPos, referencePos);

            // The vector in 1, 1 space which is scaled to the tile size... this vector represents from the upper left tile
            // as origin, the vector to my position
            Vector2 normRPV = new Vector2(relativePositionVec.X % SCALED_TILE_SIDE_LENGTH, relativePositionVec.Y % SCALED_TILE_SIDE_LENGTH);

            // Determine if the normRPV relative to each corner is less than the error displacement
            // if so, we conclude that I'm on an intersection
            IEnumerable<Vector2> selected = (IEnumerable<Vector2>)UNIT_TILE_VECTORS.Where(x => magVec(deltaVec(x, normRPV)) < ERROR_DISPLACEMENT_LENGTH);

            if (printDis)
            {
                foreach (Vector2 vec in UNIT_TILE_VECTORS)
                {
                    Debug.WriteLine("Dist mag: " + magVec(deltaVec(vec, normRPV)));
                }
            }

            // If more than one corner registers I'm on intersection,
            // alert programmer because error displacement is too high
            if (selected.Count() > 1) throw new Exception("The error displacement length is too large");

            // If I was registered with a vertex
            if (selected.Count() > 0)
            {

                Tuple<int, int> mytile = demap(myPos, rounded: false);
                //Debug.WriteLine(mytile.Item1 * SCALED_TILE_SIDE_LENGTH + selected.First().X + referencePos.X + ", " + (mytile.Item2 * SCALED_TILE_SIDE_LENGTH + selected.First().Y + referencePos.Y));
                return new Vector2(mytile.Item1 * SCALED_TILE_SIDE_LENGTH + selected.First().X + referencePos.X, mytile.Item2 * SCALED_TILE_SIDE_LENGTH + selected.First().Y + referencePos.Y);
            }

            return Vector2.Zero;

        }

        private Tuple<int, int> demap(Vector2 pos, bool rounded = true)
        {
            Vector2 vec = deltaVec(pos, referencePos);

            if (rounded)
            {
                return new Tuple<int, int>((int)Math.Round(vec.X / (Global.Var.SCALE * Global.Var.TILE_SIZE)), (int)Math.Round(vec.Y / (Global.Var.SCALE * Global.Var.TILE_SIZE)));
            }

            return new Tuple<int, int>((int)(vec.X / (Global.Var.SCALE * Global.Var.TILE_SIZE)), (int)(vec.Y / (Global.Var.SCALE * Global.Var.TILE_SIZE)));
        }

        private bool isValid(Tuple<int, int> a)
        {
            return a.Item1 <= 11 && a.Item1 >= 0 && a.Item2 <= 6 && a.Item2 >= 0 && pathMatrix[a.Item2, a.Item1];
        }



        private void addIfValid(List<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>> l, Tuple<Tuple<int, int>, Queue<Tuple<int, int>>> tile)
        {
            if (isValid(tile.Item1))
            {
                tile.Item2.Enqueue(tile.Item1);
                l.Add(tile);
            }
        }

        private List<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>> adjacentTiles(Tuple<Tuple<int, int>, Queue<Tuple<int, int>>> tile)
        {
            List<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>> adj = new List<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>>();

            addIfValid(adj, new Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>(new Tuple<int, int>(tile.Item1.Item1 - 1, tile.Item1.Item2), new Queue<Tuple<int, int>>(tile.Item2)));
            addIfValid(adj, new Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>(new Tuple<int, int>(tile.Item1.Item1 + 1, tile.Item1.Item2), new Queue<Tuple<int, int>>(tile.Item2)));
            addIfValid(adj, new Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>(new Tuple<int, int>(tile.Item1.Item1, tile.Item1.Item2 - 1), new Queue<Tuple<int, int>>(tile.Item2)));
            addIfValid(adj, new Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>(new Tuple<int, int>(tile.Item1.Item1, tile.Item1.Item2 + 1), new Queue<Tuple<int, int>>(tile.Item2)));

            return adj;

        }

        private Queue<Tuple<int, int>> determineBestPath(Tuple<int, int> myTile, Tuple<int, int> playerTile)
        {
            // BFS - Referenced: https://www.geeksforgeeks.org/shortest-path-in-a-binary-maze/

            List<Tuple<int, int>> exploredNodes = new List<Tuple<int, int>>();

            Tuple<Tuple<int, int>, Queue<Tuple<int, int>>> mappedTile = new Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>(myTile, new Queue<Tuple<int, int>>());

            exploredNodes.Add(myTile);

            Queue<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>> toExplore = new Queue<Tuple<Tuple<int, int>, Queue<Tuple<int, int>>>>(adjacentTiles(mappedTile));

            while (toExplore.Count > 0)
            {

                Tuple<Tuple<int, int>, Queue<Tuple<int, int>>> item = toExplore.Dequeue();

                Tuple<int, int> tile = item.Item1;
                Queue<Tuple<int, int>> tilePath = item.Item2;

                if (exploredNodes.Contains(tile)) { continue; } else exploredNodes.Add(tile);

                if (tile.Equals(playerTile))
                {
                    return tilePath;
                }
                else
                {
                    foreach (Tuple<Tuple<int, int>, Queue<Tuple<int, int>>> i in adjacentTiles(item))
                    {
                        toExplore.Enqueue(i);
                    }
                }

            }

            return null;

        }

        private AbstractEntity.Direction directionToTile(Tuple<int, int> dest, Tuple<int, int> pos)
        {
            if (dest.Item1 - pos.Item1 > 0)
            {
                return AbstractEntity.Direction.RIGHT;
            }
            if (dest.Item1 - pos.Item1 < 0)
            {
                return AbstractEntity.Direction.LEFT;
            }
            if (dest.Item2 - pos.Item2 > 0)
            {
                return AbstractEntity.Direction.DOWN;
            }
            if (dest.Item2 - pos.Item2 < 0)
            {
                return AbstractEntity.Direction.UP;
            }

            return AbstractEntity.Direction.NONE;
        }

        public AbstractEntity.Direction WhichDirection(Vector2 myPos, Vector2 playerPos)
        {

            // x, y ordering
            Tuple<int, int> currentPlayerTile = demap(playerPos);
            Tuple<int, int> currentMyTile = demap(myPos);

            if (coolDown)
            {
                count++;
                if (count > 3)
                {
                    coolDown = false;
                    count = 0;
                }
            }
            else
            {

                Vector2 nearestIntersection = isOnIntersection(myPos);

                if (nearestIntersection != Vector2.Zero && (route == null || route.Count > 0))
                {

                    if (currentPlayerTile.Equals(lastPlayerTile))
                    { // player static
                        route.Dequeue();
                        Debug.WriteLine("At intersection, popping instruction");
                        if (route.Count == 0)
                        {
                            route = determineBestPath(currentMyTile, currentPlayerTile);
                        }

                    }
                    else
                    { // player moved

                        handRef.Position = nearestIntersection;
                        Debug.WriteLine("At intersection");
                        route = determineBestPath(currentMyTile, currentPlayerTile);
                        //route.Dequeue();
                        //printQueue(route);
                        Debug.WriteLine("Going to " + route.First().ToString() + " via " + directionToTile(route.First(), currentMyTile));

                        lastPlayerTile = currentPlayerTile;
                    }

                    lastDirection = directionToTile(route.First(), currentMyTile);
                    coolDown = true;

                }
            }

            //Debug.WriteLine(lastDirection.ToString());

            return lastDirection;

        }

        private void printQueue(Queue<Tuple<int, int>> r)
        {
            Queue<Tuple<int, int>> a = new Queue<Tuple<int, int>>();
            while (r.Count > 0)
            {
                a.Enqueue(r.Dequeue());
                Debug.WriteLine("(" + a.Last().Item2 + ", " + a.Last().Item1 + ")");
            }

            a.Reverse();

            while (a.Count > 0)
            {
                r.Enqueue(a.Dequeue());
            }
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