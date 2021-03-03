using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sprintfinity3902.Dungeon
{
    public class Room : IRoom
    {
        public int Id { get; set; }
        public List<IEntity> roomEntities { get; set; }
        public string path { get; set; }
        public RoomLoader loader { get; set; }

        public Room(string fileLocation, int id)
        {
            roomEntities = new List<IEntity>();
            path = fileLocation;
            Id = id;

            loader = new RoomLoader(this);
        }

        public void Update(GameTime gameTime)
        {
            
            foreach (IEntity entity in roomEntities)
            {
                entity.Update(gameTime);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            foreach (IEntity entity in roomEntities)
            {
                entity.Draw(spriteBatch);
            }
            
        }

        public void ChangePosition()
        {
            foreach (IEntity entity in roomEntities)
            {
                //Change position of all entities in the room when you enter the 
                //pause menu or inventory screen
            }
        }
    }
}
