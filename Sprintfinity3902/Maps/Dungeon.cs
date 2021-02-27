using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Maps
{
    public class Dungeon : IDungeon
    {
        private List<IRoom> dungeonRooms;
        //private IRoom currentRoom; 
            //Will probably be used in the future so that only the current room is updated and drawn

        public Dungeon()
        {
            dungeonRooms = new List<IRoom>();
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\TestRoom.csv"));
        }

        public void Build()
        {
            foreach(IRoom room in dungeonRooms)
            {
                room.loader.Build();
            }
        }

        public void Update(GameTime gameTime)
        {            
            foreach(IRoom room in dungeonRooms)
            {
                room.Update(gameTime);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {            
            foreach(IRoom room in dungeonRooms)
            {
                room.Draw(spriteBatch);
            }
            
        }
    }
}
