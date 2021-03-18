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
        /*MAGIC NUMBERS REFACTOR*/
        private static int FOURTEEN = 14;
        private static int THIRTY_TWO = 32;
        private static int FORTY_EIGHT = 48;
        private static int EIGHTY = 80;
        private static int ONE_HUNDRED_TWENTY = 120;
        private static int ONE_HUNDRED_SIXTY = 160;
        private static int TWO_HUNDRED_FORTY = 240;
        private static int TWO_HUNDRED_FIFTY_SIX = 256;

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
            int currX = Global.Var.TILE_SIZE * Global.Var.SCALE;
            int currY = EIGHTY * Global.Var.SCALE;
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
                        currX += Global.Var.TILE_SIZE * Global.Var.SCALE;
                        if (currX == Global.Var.TILE_SIZE * Global.Var.SCALE * FOURTEEN + Global.Var.TILE_SIZE * Global.Var.SCALE)
                        {
                            currX = Global.Var.TILE_SIZE * Global.Var.SCALE;
                            currY += Global.Var.TILE_SIZE * Global.Var.SCALE;
                        }
                        Position = new Vector2(currX, currY);
                    }
                }
            }
            
        }

        /*MAGIC NUMBERS REFACTOR*/
        public void BuildWallAndFloor(string input)
        {
            switch (input)
            {
                //WALLS AND FLOORS
                case "R13E":
                    Room.blocks.Add(new VerticalWall(new Vector2(-THIRTY_TWO * Global.Var.SCALE, EIGHTY * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(-THIRTY_TWO * Global.Var.SCALE, ONE_HUNDRED_SIXTY * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(TWO_HUNDRED_FIFTY_SIX * Global.Var.SCALE, EIGHTY * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(TWO_HUNDRED_FIFTY_SIX * Global.Var.SCALE, ONE_HUNDRED_SIXTY * Global.Var.SCALE)));

                    Room.blocks.Add(new HorizontalWall(new Vector2(Global.Var.ZERO * Global.Var.SCALE, FORTY_EIGHT * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(ONE_HUNDRED_TWENTY * Global.Var.SCALE, FORTY_EIGHT * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(TWO_HUNDRED_FORTY * Global.Var.SCALE, FORTY_EIGHT * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(Global.Var.ZERO * Global.Var.SCALE, TWO_HUNDRED_FORTY * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(ONE_HUNDRED_TWENTY * Global.Var.SCALE, TWO_HUNDRED_FORTY * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(TWO_HUNDRED_FORTY * Global.Var.SCALE, TWO_HUNDRED_FORTY * Global.Var.SCALE)));
                    break;
                case "R13I":
                    Room.blocks.Add(new Room13(new Vector2(Global.Var.ZERO * Global.Var.SCALE, EIGHTY * Global.Var.SCALE)));
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
