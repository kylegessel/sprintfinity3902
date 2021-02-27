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

        public Dungeon()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            foreach(IRoom room in dungeonRooms)
            {
                room.Draw(spriteBatch, position);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(IRoom room in dungeonRooms)
            {
                room.Update(gameTime);
            }
        }
    }
}
