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

        private static float ERROR_DISPLACEMENT_LENGTH = (float)0.1f;
        private static int NINETY_SIX = 96;
        private static int THIRTY_TWO = 32;
        private static int SCALED_TILE_SIDE_LENGTH = Global.Var.TILE_SIZE* Global.Var.SCALE;
        private static Vector2 UNIT_VECTOR_X = new Vector2(SCALED_TILE_SIDE_LENGTH, 0);
        private static Vector2 UNIT_VECTOR_Y = new Vector2(0, -SCALED_TILE_SIDE_LENGTH);
        private static Vector2 UNIT_VECTOR_XY = new Vector2(SCALED_TILE_SIDE_LENGTH, -SCALED_TILE_SIDE_LENGTH);
        private static Vector2 referencePos = new Vector2(THIRTY_TWO * Global.Var.SCALE, NINETY_SIX * Global.Var.SCALE);

        private Tuple<int, int> lastPlayerTile;
        private AbstractEntity.Direction lastDirection;

        private Queue<Tuple<int, int>> route;

        private bool[,] pathMatrix;


        public HandAI(IRoom _room) {
            route = new Queue<Tuple<int, int>>();
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
                        Debug.Write(lineValues[j] != "BLOK");
                    }
                    Debug.WriteLine("");
                }
            }

            sr.Close();
        }
        

        private Vector2 deltaVec(Vector2 a, Vector2 b) {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        private float magVec(Vector2 a) {
            return (float)Math.Sqrt(a.X* a.X + a.Y* a.Y);
        }

        private int chooseNewDirection(Vector2 myPos, Vector2 playerPos) {
            return 0;
        }

        private bool isOnIntersection(Vector2 myPos) {
            return false;

            Vector2 displaceMent = deltaVec(myPos, referencePos);

            Vector2 nearestIntersectionMinimal = new Vector2(displaceMent.X % SCALED_TILE_SIDE_LENGTH,
                displaceMent.Y % SCALED_TILE_SIDE_LENGTH);

            if (new Rectangle(32 * Global.Var.SCALE, 96 * Global.
                Var.SCALE, SCALED_TILE_SIDE_LENGTH / 2, SCALED_TILE_SIDE_LENGTH / 2)
                .Contains(nearestIntersectionMinimal.X, nearestIntersectionMinimal.Y)) {
                /*Quad 2*/

            } else if (new Rectangle(32 * Global.Var.SCALE + SCALED_TILE_SIDE_LENGTH / 2, 96 * Global.
                Var.SCALE, SCALED_TILE_SIDE_LENGTH / 2, SCALED_TILE_SIDE_LENGTH / 2)
                .Contains(nearestIntersectionMinimal.X, nearestIntersectionMinimal.Y)) {
                /*Quad 1*/
            } else if (new Rectangle(32 * Global.Var.SCALE + SCALED_TILE_SIDE_LENGTH / 2, 96 * Global.
                Var.SCALE + SCALED_TILE_SIDE_LENGTH / 2,
                SCALED_TILE_SIDE_LENGTH / 2, SCALED_TILE_SIDE_LENGTH / 2)
                .Contains(nearestIntersectionMinimal.X, nearestIntersectionMinimal.Y)) {
                /*Quad 3*/

            } else { 
                /*Quad 4*/
            }

           // return trueNearestIntersectionmin < ERROR_DISPLACEMENT_LENGTH;
        }

        private Tuple<int, int> demap(Vector2 pos) {
            Vector2 vec = deltaVec(pos, referencePos);

            return new Tuple<int, int>((int)Math.Round(vec.X / (Global.Var.SCALE * Global.Var.TILE_SIZE)), (int)Math.Round(vec.Y / (Global.Var.SCALE * Global.Var.TILE_SIZE)));
        }

        private bool isValid(Tuple<int, int> a) {
            return a.Item1 <= 11 && a.Item1 >= 0 && a.Item2 <= 6 && a.Item2 >= 0 && pathMatrix[a.Item2, a.Item1];
        }
        
        private void determineBestPath(Queue<Tuple<int, int>> exploredNodes, Tuple<int, int> myTile, Tuple<int, int> playerTile, int depth = 0) {

            if (depth == 0) exploredNodes.Clear();

            if (myTile.Equals(playerTile)) { exploredNodes.Enqueue(playerTile); return; }

            Tuple<int, int> right, left, down, up;

            right = new Tuple<int, int>(myTile.Item1 + 1, myTile.Item2);
            left = new Tuple<int, int>(myTile.Item1 - 1, myTile.Item2);
            down = new Tuple<int, int>(myTile.Item1, myTile.Item2 + 1);
            up = new Tuple<int, int>(myTile.Item1, myTile.Item2 - 1);

            Queue<Tuple<int, int>> refRight, refLeft, refDown, refUp;

            refRight = new Queue<Tuple<int, int>>(exploredNodes);
            refLeft = new Queue<Tuple<int, int>>(exploredNodes);
            refDown = new Queue<Tuple<int, int>>(exploredNodes);
            refUp = new Queue<Tuple<int, int>>(exploredNodes);


            if (isValid(right) && !exploredNodes.Contains(right)) {
                refRight.Enqueue(right);
                determineBestPath(refRight, myTile, playerTile, depth+1);
            }

            if (isValid(left) && !exploredNodes.Contains(left)) {
                refLeft.Enqueue(left);
                determineBestPath(refLeft, myTile, playerTile, depth + 1);
            }

            if (isValid(down) && !exploredNodes.Contains(down)) {
                refDown.Enqueue(down);
                determineBestPath(refDown, myTile, playerTile, depth + 1);
            }

            if (isValid(up) && !exploredNodes.Contains(up)) {
                refUp.Enqueue(up);
                determineBestPath(refUp, myTile, playerTile, depth + 1);
            }

            exploredNodes.Enqueue(left);

        }
        

        public AbstractEntity.Direction WhichDirection(Vector2 myPos, Vector2 playerPos) {

            if (lastPlayerTile == null) {
                lastPlayerTile = demap(playerPos);
                lastDirection = AbstractEntity.Direction.NONE;
                return lastDirection;
            }

            Tuple<int, int> currentPlayerTile = demap(playerPos);
            Tuple<int, int> currentMyTile = demap(myPos);

            if (!lastPlayerTile.Equals(currentPlayerTile)) {
                // Update
                determineBestPath(route, currentMyTile, currentPlayerTile);
                lastPlayerTile = currentPlayerTile;
                Tuple<int, int> reff = route.First();

                if (reff.Item1 - currentMyTile.Item1 < 0) {
                    lastDirection = AbstractEntity.Direction.LEFT;
                }
                if (reff.Item1 - currentMyTile.Item1 > 0) {
                    lastDirection = AbstractEntity.Direction.RIGHT;
                }
                if (reff.Item2 - currentMyTile.Item2 < 0) {
                    lastDirection = AbstractEntity.Direction.UP;
                }
                if (reff.Item2 - currentMyTile.Item2 > 0) {
                    lastDirection = AbstractEntity.Direction.DOWN;
                }

                return lastDirection;
            }

            return lastDirection;

        }

    }
}
