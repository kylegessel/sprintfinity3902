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
        //public List<IEntity> roomEntities { get; set; }
        public List<IEntity> blocks { get; set; }
        public List<IEntity> enemies { get; set; }
        public List<IEntity> items { get; set; }
        //projectiles may have to be added here later.

        public string path { get; set; }
        public RoomLoader loader { get; set; }
        public bool Pause { get; set; }

        public Room(string fileLocation, int id)
        {
            blocks = new List<IEntity>();
            enemies = new List<IEntity>();
            items = new List<IEntity>();
            Pause = false;
            path = fileLocation;
            Id = id;

            loader = new RoomLoader(this);
        }

        public void Update(GameTime gameTime)
        {
            if (!Pause)
            {
                foreach (IEntity entity in blocks)
                {
                    entity.Update(gameTime);
                }

                foreach (IEntity entity in enemies)
                {
                    entity.Update(gameTime);
                }

                foreach (IEntity entity in items)
                {
                    entity.Update(gameTime);
                }
            }
            else
            {
                ChangePosition(gameTime);
                foreach (IEntity entity in blocks)
                {
                    entity.Update(gameTime);
                }

                foreach (IEntity entity in enemies)
                {
                    entity.Update(gameTime);
                }

                foreach (IEntity entity in items)
                {
                    entity.Update(gameTime);
                }
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            foreach (IEntity entity in blocks)
            {
                entity.Draw(spriteBatch);
            }
            //Change position of all entities in the room when you enter the 
            //pause menu or inventory screen

            foreach (IEntity entity in enemies)
            {
                entity.Draw(spriteBatch);
            }

            foreach (IEntity entity in items)
            {
                entity.Draw(spriteBatch);
            }


        }

        public void ChangePosition(GameTime gameTime)
        {
            foreach (IEntity entity in blocks)
            {
               if(entity.Position.Y != 256 * Global.Var.SCALE)
               {
                    entity.Y = entity.Y + 1 *Global.Var.SCALE;
               }
            }

            foreach (IEntity entity in enemies)
            {
                if (entity.Position.Y != 256 * Global.Var.SCALE)
                {
                    entity.Y = entity.Y + 1 * Global.Var.SCALE;
                }
            }

            foreach (IEntity entity in items)
            {
                if (entity.Position.Y != 256 * Global.Var.SCALE)
                {
                    entity.Y = entity.Y + 1 * Global.Var.SCALE;
                }
            }
            
        }

        public void PauseGame()
        {
            Pause = !Pause;
            foreach (IEntity entity in blocks)
            {
                entity.StopMoving();
            }

            foreach (IEntity entity in enemies)
            {
                entity.StopMoving();
            }

            foreach (IEntity entity in items)
            {
                entity.StopMoving();
            }
        }
    }
}
