using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sprintfinity3902.Dungeon
{
    public class TemplateFactory
    {
        private static string[,] roomMatrix;
        private static List<Point> freeTiles;
        private static int floor;
        private static string[] insert;

        private static TemplateFactory instance;
        public static TemplateFactory Instance
        {
            get {
                if (instance == null) {
                    instance = new TemplateFactory();
                }
                return instance;
            }
        }

        private TemplateFactory() {
            freeTiles = new List<Point>();
        }

        public void Initialize() { }

        public void SetParams(int _floor, params string[] _insert) {
            floor = _floor;
            insert = _insert;
        }

        public void GenerateRandRoomAtPath(string path) {
            if (floor < 1) throw new Exception("Floors begin with 1 and continue upwards");
            roomMatrix = new string[Global.Var.TILE_ROW_NUM, Global.Var.TILE_COLUMN_NUM];
            freeTiles.Clear();

            Random rand = new Random();

            for (int r = 0; r < roomMatrix.GetLength(0); r++) {
                for (int c = 0; c < roomMatrix.GetLength(1); c++) {
                    Point p = new Point(c, r);
                    if (!isInDoorPos(p)) {
                        freeTiles.Add(p);
                    }
                }
            }


            for (int i = 0; i < insert.Length; i++) {
                string cur = insert[i];

                if (freeTiles.Count == 0) throw new Exception("There is not enough room to insert everything you wanted.");
                int pos = rand.Next(0, freeTiles.Count);
                Point p = freeTiles[pos];

                insertElem(p, cur);
            }

            // Refresh file
            FileStream fd = File.Create(path);
            fd.Close();
            File.AppendAllText(path, "RMEX,,,,,,,,,,,,\n");
            File.AppendAllText(path, "RMIN,,,,,,,,,,,,\n");

            switch (floor) {
                case 1:
                    generateFloorOneRoom();
                    break;
                case 2:
                    generateFloorTwoRoom();
                    break;
                case 3:
                    generateFloorThreeRoom();
                    break;
                case 4:
                    generateFloorFourRoom();
                    break;
                case 5:
                    generateFloorFiveRoom();
                    break;
            }

            // Assert bfs from door to door considering blocks
            // if fail, return GenerateRandRoomAtPath(path) else append text

            File.AppendAllText(path, ToString());
            
        }

        private void generateFloorOneRoom() {
            Random r = new Random();

            for (int i = 0; i < floor * r.Next(1, floor); i++) {

                if (freeTiles.Count == 0) {
                    break;
                } else {
                    int pos = r.Next(0, freeTiles.Count);
                    Point p = freeTiles[pos];
                    // This will remove from freeTiles for us
                    createBlock(p);
                }

            }
            
        }

        private void generateFloorTwoRoom() {
            Random r = new Random();

            for (int i = 0; i < floor * r.Next(1, floor); i++) {

                if (freeTiles.Count == 0) {
                    break;
                } else {
                    int pos = r.Next(0, freeTiles.Count);
                    Point p = freeTiles[pos];
                    // This will remove from freeTiles for us
                    createBlock(p);
                }

            }
        }

        private void generateFloorThreeRoom() {
            Random r = new Random();

            for (int i = 0; i < floor * r.Next(1, floor); i++) {

                if (freeTiles.Count == 0) {
                    break;
                } else {
                    int pos = r.Next(0, freeTiles.Count);
                    Point p = freeTiles[pos];
                    // This will remove from freeTiles for us
                    createBlock(p);
                }

            }
        }

        private void generateFloorFourRoom() {
            Random r = new Random();

            for (int i = 0; i < floor * r.Next(1, floor)*2; i++) {

                if (freeTiles.Count == 0) {
                    break;
                } else {
                    int pos = r.Next(0, freeTiles.Count);
                    Point p = freeTiles[pos];
                    // This will remove from freeTiles for us
                    createBlock(p);
                }

            }
        }

        private void generateFloorFiveRoom() {
            Random r = new Random();

            for (int i = 0; i < floor * r.Next(1, floor); i++) {

                if (freeTiles.Count == 0) {
                    break;
                } else {
                    int pos = r.Next(0, freeTiles.Count);
                    Point p = freeTiles[pos];
                    // This will remove from freeTiles for us
                    createWildEnemy(p);
                }

            }
        }

        private bool isValid(Point p) {
            return p.X >= 0 && p.X < roomMatrix.GetLength(1) && p.Y >= 0 && p.Y < roomMatrix.GetLength(0);
        }

        private bool isInDoorPos(Point p) {
            return p.X == 0 && p.Y == Global.Var.TILE_ROW_NUM / 2 || // Left door
                p.X == Global.Var.TILE_COLUMN_NUM - 1 && p.Y == Global.Var.TILE_ROW_NUM / 2 || // Right Door
                (p.X == (Global.Var.TILE_COLUMN_NUM - 1) / 2 || p.X == (Global.Var.TILE_COLUMN_NUM - 1) / 2 + 1) && 
                p.Y == 0 || // Up door
                (p.X == (Global.Var.TILE_COLUMN_NUM - 1) / 2 || p.X == (Global.Var.TILE_COLUMN_NUM - 1) / 2 + 1) &&
                p.Y == Global.Var.TILE_ROW_NUM - 1; // Down door
        }

        private void createBlock(Point center) {
            insertElem(center, "BLOK");
        }

        private void createWildEnemy(Point center)
        {
            insertElem(center, "WILD1");
        }

        private void insertElem(Point tile, string e) {
            if (!isValid(tile)) throw new Exception("Cannot insert at tile " + tile);
            if (!freeTiles.Contains(tile)) throw new Exception("Cannot insert " + e + ". It will overwrite.");

            freeTiles.Remove(tile);

            roomMatrix[tile.Y, tile.X] = e;

        }

        public override string ToString()
        {
            string room = "";

            for (int r = 0; r < roomMatrix.GetLength(0); r++) {
                for (int c = 0; c < roomMatrix.GetLength(1); c++) {
                    room += roomMatrix[r, c];
                    if (c != roomMatrix.GetLength(1) - 1) {
                        room += ", ";
                    } else {
                        room += '\n';
                    }
                }
            }

            return room;
        }

    }
}
