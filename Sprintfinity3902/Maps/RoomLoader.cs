using System.IO;
using Sprintfinity3902.Interfaces;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Entities.Doors;
using System;

namespace Sprintfinity3902.Maps
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
            DoorTop = new Door(new Vector2(112*Globals.GlobalVariables.SCALE, 64*Globals.GlobalVariables.SCALE));
            DoorBottom = new Door(new Vector2(112 * Globals.GlobalVariables.SCALE, 208 * Globals.GlobalVariables.SCALE));
            DoorLeft = new Door(new Vector2(0, 136*Globals.GlobalVariables.SCALE));
            DoorRight = new Door(new Vector2(224*Globals.GlobalVariables.SCALE, 136*Globals.GlobalVariables.SCALE));
            Room.roomEntities.Add(new RoomExterior(new Vector2(0, 64*Globals.GlobalVariables.SCALE)));
            Room.roomEntities.Add(new RoomInterior(new Vector2(32*Globals.GlobalVariables.SCALE, 96*Globals.GlobalVariables.SCALE)));
            Room.roomEntities.Add(DoorTop);
            Room.roomEntities.Add(DoorBottom);
            Room.roomEntities.Add(DoorLeft);
            Room.roomEntities.Add(DoorRight);
            
            string line;
            int currX = 160;
            int currY = 480;
            Position = new Vector2(currX, currY);
            for(int i = 0; i < 7; i++)
            {
                line = mapStream.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');
                    for(int j = 0; j < 12; j++)
                    {
                        BuildBlocks(lineValues[j]);
                        currX += 80;
                        if(currX == 80 * 12 + 160)
                        {
                            currX = 160;
                            currY += 80;
                        }
                        Position = new Vector2(currX, currY);
                    }
                }
            }
            for(int i = 0; i < 4; i++)
            {
                line = mapStream.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');
                    BuildDoors(lineValues[0], lineValues[1]);
                }

            }
        }
        public void BuildBlocks(string input)
        {
            switch (input)
            {
                //BLOCKS
                case "TILE":
                    Room.roomEntities.Add(new FloorBlock(Position));
                    break;
                case "BLOK":
                    Room.roomEntities.Add(new RegularBlock(Position));
                    break;
                case "RFSH":
                    Room.roomEntities.Add(new Face1Block(Position));
                    break;
                case "LFSH":
                    Room.roomEntities.Add(new Face2Block(Position));
                    break;
                case "SPOT":
                    Room.roomEntities.Add(new SpottedBlock(Position));
                    break;
                case "BLCK":
                    Room.roomEntities.Add(new BlackBlock(Position));
                    break;
                case "BRIK":
                    Room.roomEntities.Add(new BrickBlock(Position));
                    break;
                case "DARK":
                    Room.roomEntities.Add(new DarkBlueBlock(Position));
                    break;
                case "STAR":
                    Room.roomEntities.Add(new StairsBlock(Position));
                    break;
                case "STIP":
                    Room.roomEntities.Add(new StripeBlock(Position));
                    break;

                //ENEMIES
                case "BBAT":
                    Room.roomEntities.Add(new BlueBatEnemy(Position));
                    break;
                case "SKLN":
                    Room.roomEntities.Add(new SkeletonEnemy(Position));
                    break;
                case "BOSS":
                    Room.roomEntities.Add(new FinalBossEnemy(Position));
                    break;
                case "FIRE":
                    Room.roomEntities.Add(new Fire(Position));
                    break;
                case "GELY":
                    Room.roomEntities.Add(new GelEnemy(Position));
                    break;
                case "GORY":
                    BoomerangItem goriyaBoomerang = new BoomerangItem();
                    Room.roomEntities.Add(goriyaBoomerang);
                    Room.roomEntities.Add(new GoriyaEnemy(goriyaBoomerang, Position));
                    break;
                case "HAND":
                    Room.roomEntities.Add(new HandEnemy(Position));
                    break;
                case "OLDM":
                    Room.roomEntities.Add(new OldManNPC(Position));
                    break;
                case "SPKE":
                    Room.roomEntities.Add(new SpikeEnemy(Position));
                    break;


                //ITEMS
                // Probably could use a static bomb and boomerang object now that I think of it.
                case "KEYI":
                    Room.roomEntities.Add(new KeyItem(Position));
                    break;
                case "BOWI":
                    Room.roomEntities.Add(new BowItem(Position));
                    break;
                case "CLCK":
                    Room.roomEntities.Add(new ClockItem(Position));
                    break;
                case "CMPS":
                    Room.roomEntities.Add(new CompassItem(Position));
                    break;
                case "FARY":
                    Room.roomEntities.Add(new FairyItem(Position));
                    break;
                case "HCON":
                    Room.roomEntities.Add(new HeartContainerItem(Position));
                    break;
                case "HART":
                    Room.roomEntities.Add(new HeartItem(Position));
                    break;
                case "MAPI":
                    Room.roomEntities.Add(new MapItem(Position));
                    break;
                case "RUPE":
                    Room.roomEntities.Add(new RupeeItem(Position));
                    break;
                case "TRIF":
                    Room.roomEntities.Add(new TriforceItem(Position));
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
