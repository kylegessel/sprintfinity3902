using System.IO;
using System.Collections.Generic;
using Sprintfinity3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;

namespace Sprintfinity3902.Maps
{
    public class RoomLoader
    {
        StreamReader mapStream;
        private IRoom Room { get; set; }

        // Have this input a filename and then load the room.
        public RoomLoader(IRoom room)
        {
            // Really think there is a better way to list these files, just a demo for the time being though.
            Room = room;
            mapStream = new StreamReader(Room.path);

        }

        public void Build()
        {
            Room.roomEntities.Add(new RoomExterior(new Vector2(0, 320)));
            Room.roomEntities.Add(new RoomInterior(new Vector2(160, 480)));
            
            string line;
            int currX = 160;
            int currY = 480;
            Vector2 Position = new Vector2(currX, currY);
            while (!mapStream.EndOfStream)
            {
                line = mapStream.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');
                    foreach (string s in lineValues)
                    {
                        switch (s)
                        {
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
            
        }
            
    }
}
