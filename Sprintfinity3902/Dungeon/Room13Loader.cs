using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Entities.Doors;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sprintfinity3902.Dungeon
{
    public class Room13Loader
    {
        StreamReader mapStream;
        private IRoom Room { get; set; }
        private Vector2 Position { get; set; }
        int enemyID;


        // Have this input a filename and then load the room.
        public Room13Loader(IRoom room)
        {
            // Really think there is a better way to list these files, just a demo for the time being though.
            Room = room;
            mapStream = new StreamReader(Room.path);

        }

        public void Build()
        {
            string line;
            int currX = 16 * Global.Var.SCALE;
            int currY = 80 * Global.Var.SCALE;
            Position = new Vector2(currX, currY);

            for (int i = 0; i < 2; i++)
            {
                line = mapStream.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');
                    BuildWallAndFloor(lineValues[0]);
                }
            }

            // add fake entitities
            for (int i = 0; i < 9; i++)
            {
                line = mapStream.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');
                    for (int j = 0; j < 14; j++)
                    {
                        BuildBlocks(lineValues[j]);
                        currX += 16 * Global.Var.SCALE;
                        if (currX == 16 * Global.Var.SCALE * 14 + 16 * Global.Var.SCALE)
                        {
                            currX = 16 * Global.Var.SCALE;
                            currY += 16 * Global.Var.SCALE;
                        }
                        Position = new Vector2(currX, currY);
                    }
                }
            }
            
        }

        public void BuildWallAndFloor(string input)
        {
            switch (input)
            {
                //WALLS AND FLOORS
                case "R13E":
                    Room.blocks.Add(new VerticalWall(new Vector2(-32 * Global.Var.SCALE, 80 * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(-32 * Global.Var.SCALE, 160 * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(256 * Global.Var.SCALE, 80 * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(256 * Global.Var.SCALE, 160 * Global.Var.SCALE)));

                    Room.blocks.Add(new HorizontalWall(new Vector2(0 * Global.Var.SCALE, 48 * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(120 * Global.Var.SCALE, 48 * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(240 * Global.Var.SCALE, 48 * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(0 * Global.Var.SCALE, 240 * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(120 * Global.Var.SCALE, 240 * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(240 * Global.Var.SCALE, 240 * Global.Var.SCALE)));
                    break;
                case "R13I":
                    Room.blocks.Add(new Room13(new Vector2(0 * Global.Var.SCALE, 80 * Global.Var.SCALE)));
                    break;
                case " ":
                    break;

            }
        }

        public void BuildBlocks(string input)
        {
            switch (input)
            {
                //BLOCKS
                case "BLCK":
                    Room.blocks.Add(new BlackBlock(Position));
                    break;
                case "BRIK":
                    Room.blocks.Add(new BrickBlock(Position));
                    break;
                case "DARK":
                    Room.blocks.Add(new DarkBlueBlock(Position));
                    break;
                case "STAR":
                    Room.blocks.Add(new StairsBlock(Position));
                    break;
                case "STIP":
                    Room.blocks.Add(new StripeBlock(Position));
                    break;

                //ENEMIES
                case "BBAT":
                    Room.enemies.Add(enemyID, new BlueBatEnemy(Position));
                    enemyID++;
                    break;

                //ITEMS
                // Probably could use a static bomb and boomerang object now that I think of it.
                case "BOWI":
                    Room.items.Add(new BowItem(Position));
                    break;

            }
        }

    }
}
