using System.IO;
using Sprintfinity3902.Interfaces;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Entities.Doors;

namespace Sprintfinity3902.Maps
{
    public class RoomLoader
    {
        StreamReader mapStream;
        private IRoom Room { get; set; }
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
            DoorTop = new Door(new Vector2(560, 320));
            DoorBottom = new Door(new Vector2(560, 1040));
            DoorLeft = new Door(new Vector2(0, 680));
            DoorRight = new Door(new Vector2(1120, 680));
            Room.roomEntities.Add(new RoomExterior(new Vector2(0, 320)));
            Room.roomEntities.Add(new RoomInterior(new Vector2(160, 480)));
            Room.roomEntities.Add(DoorTop);
            Room.roomEntities.Add(DoorBottom);
            Room.roomEntities.Add(DoorLeft);
            Room.roomEntities.Add(DoorRight);
            
            string line;
            int currX = 160;
            int currY = 480;
            Vector2 Position = new Vector2(currX, currY);
            for(int i = 0; i < 7; i++)
            {
                line = mapStream.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');
                    for(int j = 0; j < 12; j++)
                    {
                        switch (lineValues[j])
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

                            //ENEMIES
                            case "BBAT":
                                Room.roomEntities.Add(new BlueBatEnemy(Position));
                                break;
                            case "SKLN":
                                Room.roomEntities.Add(new SkeletonEnemy(Position));
                                break;


                            //ITEMS
                            case "KEYI":
                                Room.roomEntities.Add(new KeyItem(Position));
                                break;

                        }
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
                    switch (lineValues[0])
                    {
                        case "WALT":
                            DoorTop.SetState(DoorBottom.wallTop);
                            break;
                        case "WALB":
                            DoorBottom.SetState(DoorBottom.wallBottom);
                            break;
                        case "WALL":
                            DoorLeft.SetState(DoorBottom.wallLeft);
                            break;
                        case "WALR":
                            DoorRight.SetState(DoorBottom.wallRight);
                            break;
                        case "ODRT":
                            DoorTop.SetState(DoorTop.openDoorTop);
                            break;
                    }
                }

            }
        }
            
    }
}
