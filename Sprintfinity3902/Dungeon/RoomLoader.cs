using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Entities.Doors;
using Sprintfinity3902.Interfaces;
using System;
using System.IO;

namespace Sprintfinity3902.Dungeon
{
    public class RoomLoader
    {
        StreamReader mapStream;
        private IRoom Room { get; set; }
        private Vector2 Position { get; set; }
        public Door DoorTop { get; set; }
        public Door DoorBottom { get; set; }
        public Door DoorLeft { get; set; }
        public Door DoorRight { get; set; }

        // Have this input a filename and then load the room.
        public RoomLoader(IRoom room)
        {
            // Really think there is a better way to list these files, just a demo for the time being though.
            Room = room;
            mapStream = new StreamReader(Room.path);

        }

        public void Build()
        {
            string line;
            int currX = 32*Global.Var.SCALE;
            int currY = 96*Global.Var.SCALE;
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
            for (int i = 0; i < 7; i++)
            {
                line = mapStream.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');
                    for(int j = 0; j < 12; j++)
                    {
                        BuildBlocks(lineValues[j]);
                        currX += 16*Global.Var.SCALE;
                        if(currX == 16*Global.Var.SCALE * 12 + 32*Global.Var.SCALE)
                        {
                            currX = 32*Global.Var.SCALE;
                            currY += 16*Global.Var.SCALE;
                        }
                        Position = new Vector2(currX, currY);
                    }
                }
            }

            DoorTop = new Door(new Vector2(112 * Global.Var.SCALE, 64 * Global.Var.SCALE));
            DoorBottom = new Door(new Vector2(112 * Global.Var.SCALE, 208 * Global.Var.SCALE));
            DoorLeft = new Door(new Vector2(0, 136 * Global.Var.SCALE));
            DoorRight = new Door(new Vector2(224 * Global.Var.SCALE, 136 * Global.Var.SCALE));
            Room.blocks.Add(DoorTop);
            Room.blocks.Add(DoorBottom);
            Room.blocks.Add(DoorLeft);
            Room.blocks.Add(DoorRight);
            for (int i = 0; i < 4; i++)
            {
                line = mapStream.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');
                    BuildDoors(lineValues[0], lineValues[1]);
                }

            }

        }

        public void BuildWallAndFloor(string input)
        {
            switch (input)
            {
                //WALLS AND FLOORS
                case "RMEX":
                    Room.blocks.Add(new RoomExterior(new Vector2(0, 64 * Global.Var.SCALE)));
                    //add all 8

                    Room.blocks.Add(new VerticalWall(new Vector2 (0, 64 * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(0, 160 * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(224 * Global.Var.SCALE, 64 * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(224 * Global.Var.SCALE, 160 * Global.Var.SCALE)));

                    Room.blocks.Add(new HorizontalWall(new Vector2(0, 64 * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(0, 208 * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(136 * Global.Var.SCALE, 64 * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(136 * Global.Var.SCALE, 208 * Global.Var.SCALE)));






                    break;
                case "RMIN":
                    Room.blocks.Add(new RoomInterior(new Vector2(32 * Global.Var.SCALE, 96 * Global.Var.SCALE)));
                    break;
                case "RM08":
                    Room.blocks.Add(new Room8Interior(new Vector2(32 * Global.Var.SCALE, 96 * Global.Var.SCALE)));
                    break;
                case "RM14":
                    Room.blocks.Add(new Room14Interior(new Vector2(32 * Global.Var.SCALE, 96 * Global.Var.SCALE)));
                    break;
                case "RM18":
                    Room.blocks.Add(new Room18Interior(new Vector2(32 * Global.Var.SCALE, 96 * Global.Var.SCALE)));
                    break;

            }
        }

        public void BuildBlocks(string input)
        {
            switch (input)
            {
                //BLOCKS
                case "TILE":
                    Room.blocks.Add(new FloorBlock(Position));
                    break;
                case "BLOK":
                    Room.blocks.Add(new RegularBlock(Position));
                    break;
                case "RFSH":
                    Room.blocks.Add(new Face1Block(Position));
                    break;
                case "LFSH":
                    Room.blocks.Add(new Face2Block(Position));
                    break;
                case "SPOT":
                    Room.blocks.Add(new SpottedBlock(Position));
                    break;
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
                    Room.enemies.Add(new BlueBatEnemy(Position));
                    break;
                case "SKLN":
                    Room.enemies.Add(new SkeletonEnemy(Position));
                    break;
                case "BOSS":
                    FireAttack up = new FireAttack(1);
                    FireAttack center = new FireAttack(0);
                    FireAttack down = new FireAttack(2);
                    Room.enemies.Add(up);
                    Room.enemies.Add(down);
                    Room.enemies.Add(center);
                    Room.enemies.Add(new FinalBossEnemy(Position, up, center, down));
                    break;
                case "FIRE":
                    Room.enemies.Add(new Fire(Position));
                    break;
                case "GELY":
                    GelEnemy gel = new GelEnemy(Position);
                    gel.X = gel.Position.X + 4 * Global.Var.SCALE;
                    gel.Y = gel.Position.Y + 4 * Global.Var.SCALE;
                    Room.enemies.Add(gel);
                    break;
                case "GORY":
                    BoomerangItem goriyaBoomerang = new BoomerangItem();
                    Room.enemies.Add(goriyaBoomerang);
                    Room.enemies.Add(new GoriyaEnemy(goriyaBoomerang, Position));
                    break;
                case "HAND":
                    Room.enemies.Add(new HandEnemy(Position));
                    break;
                case "OLDM":
                    OldManNPC man = new OldManNPC(Position);
                    man.X = man.Position.X + 8 * Global.Var.SCALE;
                    Room.enemies.Add(man);
                    break;
                case "SPKE":
                    Room.enemies.Add(new SpikeEnemy(Position));
                    break;


                //ITEMS
                // Probably could use a static bomb and boomerang object now that I think of it.
                case "KEYI":
                    KeyItem key = new KeyItem(Position);
                    key.X = key.Position.X + 4 * Global.Var.SCALE;
                    Room.items.Add(key);
                    break;
                case "BOWI":
                    Room.items.Add(new BowItem(Position));
                    break;
                case "CLCK":
                    Room.items.Add(new ClockItem(Position));
                    break;
                case "CMPS":
                    CompassItem compass = new CompassItem(Position);
                    compass.X = compass.Position.X + 2 * Global.Var.SCALE;
                    compass.Y = compass.Position.Y + 2 * Global.Var.SCALE;
                    Room.items.Add(compass);
                    break;
                case "FARY":
                    Room.items.Add(new FairyItem(Position));
                    break;
                case "HCON":
                    HeartContainerItem hcont = new HeartContainerItem(Position);
                    hcont.X = hcont.Position.X + 1 * Global.Var.SCALE;
                    hcont.Y = hcont.Position.Y + 1 * Global.Var.SCALE;
                    Room.items.Add(hcont);
                    break;
                case "HART":
                    Room.items.Add(new HeartItem(Position));
                    break;
                case "MAPI":
                    MapItem map = new MapItem(Position);
                    map.X = map.Position.X + 4 * Global.Var.SCALE;
                    Room.items.Add(map);
                    break;
                case "RUPE":
                    Room.items.Add(new RupeeItem(Position));
                    break;
                case "TRIF":
                    TriforceItem triforce = new TriforceItem(Position);
                    triforce.X = triforce.Position.X + 11 * Global.Var.SCALE;
                    triforce.Y = triforce.Position.Y + 11 * Global.Var.SCALE;
                    Room.items.Add(triforce);
                    break;

            }
        }

        public void BuildDoors(string input, string destination)
        {
            switch (input)
            {
                // DOORS
                case "WALT":
                    DoorTop.SetState(DoorBottom.wallTop);
                    DoorTop.DoorDestination = Int16.Parse(destination);
                    break;
                case "WALB":
                    DoorBottom.SetState(DoorBottom.wallBottom);
                    DoorBottom.DoorDestination = Int16.Parse(destination);
                    break;
                case "WALL":
                    DoorLeft.SetState(DoorBottom.wallLeft);
                    DoorLeft.DoorDestination = Int16.Parse(destination);
                    break;
                case "WALR":
                    DoorRight.SetState(DoorBottom.wallRight);
                    DoorRight.DoorDestination = Int16.Parse(destination);
                    break;
                case "ODRT":
                    DoorTop.SetState(DoorTop.openDoorTop);
                    DoorTop.DoorDestination = Int16.Parse(destination);
                    break;
                case "ODRB":
                    DoorBottom.SetState(DoorTop.openDoorBottom);
                    DoorBottom.DoorDestination = Int16.Parse(destination);
                    break;
                case "ODRL":
                    DoorLeft.SetState(DoorTop.openDoorLeft);
                    DoorLeft.DoorDestination = Int16.Parse(destination);
                    break;
                case "ODRR":
                    DoorRight.SetState(DoorRight.openDoorRight);
                    DoorRight.DoorDestination = Int16.Parse(destination);
                    break;
                case "CDRT":
                    DoorTop.SetState(DoorTop.closedDoorTop);
                    DoorTop.DoorDestination = Int16.Parse(destination);
                    break;
                case "CDRB":
                    DoorBottom.SetState(DoorTop.closedDoorBottom);
                    DoorBottom.DoorDestination = Int16.Parse(destination);
                    break;
                case "CDRL":
                    DoorLeft.SetState(DoorTop.closedDoorLeft);
                    DoorLeft.DoorDestination = Int16.Parse(destination);
                    break;
                case "CDRR":
                    DoorRight.SetState(DoorRight.closedDoorRight);
                    DoorRight.DoorDestination = Int16.Parse(destination);
                    break;
                case "LDRT":
                    DoorTop.SetState(DoorTop.lockedDoorTop);
                    DoorTop.DoorDestination = Int16.Parse(destination);
                    break;
                case "LDRB":
                    DoorBottom.SetState(DoorTop.lockedDoorBottom);
                    DoorBottom.DoorDestination = Int16.Parse(destination);
                    break;
                case "LDRL":
                    DoorLeft.SetState(DoorTop.lockedDoorLeft);
                    DoorLeft.DoorDestination = Int16.Parse(destination);
                    break;
                case "LDRR":
                    DoorRight.SetState(DoorRight.lockedDoorRight);
                    DoorRight.DoorDestination = Int16.Parse(destination);
                    break;
                case "HDRT":
                    DoorTop.SetState(DoorTop.holeDoorTop);
                    DoorTop.DoorDestination = Int16.Parse(destination);
                    break;
                case "HDRB":
                    DoorBottom.SetState(DoorTop.holeDoorBottom);
                    DoorBottom.DoorDestination = Int16.Parse(destination);
                    break;
                case "HDRL":
                    DoorLeft.SetState(DoorTop.holeDoorLeft);
                    DoorLeft.DoorDestination = Int16.Parse(destination);
                    break;
                case "HDRR":
                    DoorRight.SetState(DoorRight.holeDoorRight);
                    DoorRight.DoorDestination = Int16.Parse(destination);
                    break;
            }

        }
    }
}
