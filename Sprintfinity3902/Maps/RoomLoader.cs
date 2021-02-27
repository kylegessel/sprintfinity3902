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

        private List<IEntity> blocks;
        private List<IEntity> enemies;

        // Have this input a filename and then load the room.
        public RoomLoader()
        {
            // Really think there is a better way to list these files, just a demo for the time being though.
            mapStream = new StreamReader(@"..\..\..\Content\Rooms\TestRoom.csv");
            blocks = new List<IEntity>();
            enemies = new List<IEntity>();
        }

        public void Build()
        {
            string line;
            int currX = 0;
            int currY = 0;
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
                                blocks.Add(new FloorBlock(Position));
                                break;
                            case "BLOK":
                                blocks.Add(new RegularBlock(Position));
                                break;
                            case "RFSH":
                                blocks.Add(new Face1Block(Position));
                                break;
                            case "LFSH":
                                blocks.Add(new Face2Block(Position));
                                break;
                        }
                        currX += 80;
                        if(currX == 80 * 12)
                        {
                            currX = 0;
                            currY += 80;
                        }
                        Position = new Vector2(currX, currY);
                    }
                }
            }
        }
            
            
        public void Update(GameTime gameTime)
        {
            foreach(IEntity entity in blocks)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEntity entity in blocks)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}
