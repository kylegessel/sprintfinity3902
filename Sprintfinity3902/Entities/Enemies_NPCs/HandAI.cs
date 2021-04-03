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

        private static float ERROR_DISPLACEMENT_LENGTH = (float)0.6f;
        private static int NINETY_SIX = 96;
        private static int THIRTY_TWO = 32;
        private static int SCALED_TILE_SIDE_LENGTH = Global.Var.TILE_SIZE* Global.Var.SCALE;
        private static Vector2[] UNIT_TILE_VECTORS = new Vector2[] {
            new Vector2(0, 0),
            new Vector2(SCALED_TILE_SIDE_LENGTH, 0),
            new Vector2(SCALED_TILE_SIDE_LENGTH, SCALED_TILE_SIDE_LENGTH),
            new Vector2(0, SCALED_TILE_SIDE_LENGTH)
        };
        private static Vector2 referencePos = new Vector2(THIRTY_TWO * Global.Var.SCALE, NINETY_SIX * Global.Var.SCALE);


        private Queue<Tuple<int, int>> route;

        private bool[,] pathMatrix;
        private AbstractEntity.Direction lastDirection;

        public HandAI(IRoom _room) {
            //route = new Queue<Tuple<int, int>>();
            pathMatrix = new bool[7, 12];
            parseRoomLayout(_room.path);
        }

        
        private void parseRoomLayout(string path) {
            StreamReader sr = new StreamReader(path);

            sr.ReadLine();
            sr.ReadLine();

            for (int i = 0; i < 7; i++) {
                string line = sr.ReadLine();
                if (!string.IsNullOrWhiteSpace(line)) {
                    string[] lineValues = line.Split(',');

                    for (int j = 0; j < lineValues.Length; j++) {
                        pathMatrix[i, j] = lineValues[j] != "BLOK";
                    }
                }
            }

            sr.Close();
        }
        

        private Vector2 deltaVec(Vector2 a, Vector2 b) {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        private float magVec(Vector2 a)
        {
            return (float)Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }


        private bool isOnIntersection(Vector2 myPos)
        {
            Vector2 dt = deltaVec(myPos, referencePos);

            Vector2 normdt = new Vector2(dt.X % SCALED_TILE_SIDE_LENGTH, dt.Y % SCALED_TILE_SIDE_LENGTH);

            return UNIT_TILE_VECTORS.Any(x => magVec(deltaVec(x, normdt)) < ERROR_DISPLACEMENT_LENGTH);

        }

        private Tuple<int, int> demap(Vector2 pos) {
            Vector2 vec = deltaVec(pos, referencePos);

            return new Tuple<int, int>((int)Math.Round(vec.X / (Global.Var.SCALE * Global.Var.TILE_SIZE)), (int)Math.Round(vec.Y / (Global.Var.SCALE * Global.Var.TILE_SIZE)));
        }

        private bool isValid(Tuple<Tuple<int, int>, Tuple<int, int>[]> b) {
            Tuple<int, int> a = b.Item1;
            return a.Item1 <= 11 && a.Item1 >= 0 && a.Item2 <= 6 && a.Item2 >= 0 && pathMatrix[a.Item2, a.Item1];
        }

        private int indexOfMin(params int[] a) {
            int minIndex = 0;

            for (int i = 1; i < a.Length; i++) {
                if (a[i] < a[minIndex]) {
                    minIndex = i;
                }
            }

            return minIndex;
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

        private void addIfValid(List<Tuple<Tuple<int, int>, Tuple<int, int>[]>> l, Tuple<Tuple<int, int>, Tuple<int, int>[]> tile)
        {
            if (isValid(tile)) {
                tile.Item2.Append(tile.Item1);
                l.Add(tile);
            }
        }

        private List<Tuple<Tuple<int, int>, Tuple<int, int>[]>> adjacentTiles(Tuple<Tuple<int, int>, Tuple<int, int>[]> tile)
        {
            List<Tuple<Tuple<int, int>, Tuple<int, int>[]>> adj = new List<Tuple<Tuple<int, int>, Tuple<int, int>[]>>();
            
            //tile.Item1 + 1, tile.Item2
            addIfValid(adj, new Tuple<Tuple<int, int>, Tuple<int, int>[]>(tile.Item1, tile.Item2));
            addIfValid(adj, new Tuple<Tuple<int, int>, Tuple<int, int>[]>(tile.Item1, tile.Item2));
            addIfValid(adj, new Tuple<Tuple<int, int>, Tuple<int, int>[]>(tile.Item1, tile.Item2));
            addIfValid(adj, new Tuple<Tuple<int, int>, Tuple<int, int>[]>(tile.Item1, tile.Item2));

            return adj;

        }

        private Queue<Tuple<int, int>> determineBestPath(Tuple<int, int> myTile, Tuple<int, int> playerTile) {
            // BFS - Referenced: https://www.geeksforgeeks.org/shortest-path-in-a-binary-maze/

            List<Tuple<Tuple<int, int>, Tuple<int, int>[]>> exploredNodes = new List<Tuple<Tuple<int, int>, Tuple<int, int>[]>>();

            exploredNodes.Add(new Tuple<Tuple<int, int>, Tuple<int, int>[]>(myTile, new Tuple<int, int>[7 + 12]));

            Queue<Tuple<Tuple<int, int>, Tuple<int, int>[]>> toExplore = new Queue<Tuple<Tuple<int, int>, Tuple<int, int>[]>>(adjacentTiles(myTile));


            while (toExplore.Count > 0) {

                Tuple<int, int> item = toExplore.Dequeue();

                if (exploredNodes.Contains(item)) { continue; } else exploredNodes.Add(item);

                if (item.Equals(playerTile)) { 

                } else {
                    toExplore.Concat(adjacentTiles(item));
                }


            }

            return null;

        }

        private AbstractEntity.Direction directionToTile(Tuple<int, int> a, Tuple<int, int> b) {
            if (a.Item1 - b.Item1 < 0) {
                return AbstractEntity.Direction.LEFT;
            }
            if (a.Item1 - b.Item1 > 0) {
                return AbstractEntity.Direction.RIGHT;
            }
            if (a.Item2 - b.Item2 < 0) {
                return AbstractEntity.Direction.UP;
            }
            if (a.Item2 - b.Item2 > 0) {
                return AbstractEntity.Direction.DOWN;
            }

            return AbstractEntity.Direction.NONE;
        }

        public AbstractEntity.Direction WhichDirection(Vector2 myPos, Vector2 playerPos) {


            Tuple<int, int> currentPlayerTile = demap(playerPos);
            Tuple<int, int> currentMyTile = demap(myPos);

            if (route == null ) {
                route = determineBestPath(currentMyTile, currentPlayerTile);
                //route.Dequeue(); // Remove the current position instruction of proute
                //lastDirection = directionToTile(route.First(), currentMyTile);
                // For testing route
                /*
                while (route.Count > 0) {
                    Tuple<int, int> reff = route.Dequeue();
                    Debug.WriteLine("(" + reff.Item2 + ", " + reff.Item1 + ")");
                }*/
            }

            
            if (isOnIntersection(myPos)) {
                Debug.WriteLine("At intersection, popping instruction");
                route.Dequeue();
                lastDirection = directionToTile(route.First(), currentMyTile);
            }
            

            return lastDirection;

        }

    }
}
