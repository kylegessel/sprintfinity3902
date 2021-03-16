using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

namespace Sprintfinity3902.Dungeon
{
    public class Room : IRoom
    {
        public int Id { get; set; }
        //public List<IEntity> roomEntities { get; set; }
        public List<IBlock> blocks { get; set; }
        public Dictionary<int, IEntity> enemies { get; set; }
        public List<IEntity> items { get; set; }

        public List<IEntity> enemyProj { get; set; }
        public List<IEntity> garbage { get; set; }
        //projectiles may have to be added here later.

        public string path { get; set; }
        public RoomLoader loader { get; set; }
        public Room13Loader loader13 { get; set; }
        public bool Pause;
        public float startY;
        public int count;

        public Room(string fileLocation, int id)
        {
            blocks = new List<IBlock>();
            enemies = new Dictionary<int, IEntity>();
            items = new List<IEntity>();
            garbage = new List<IEntity>();
            enemyProj = new List<IEntity>();
            path = fileLocation;
            Id = id;
            Pause = false;

            if(this.Id == 13)
            {
                loader13 = new Room13Loader(this);
            }
            else
            {
                loader = new RoomLoader(this);
            }
        }

        public void Update(GameTime gameTime)
        { 
            foreach (IBlock entity in blocks)
                entity.Update(gameTime);

            foreach (IEntity entity in enemies.Values)
                entity.Update(gameTime);

            foreach (IEntity entity in items)
                entity.Update(gameTime);

            foreach (IEntity entity in garbage)
                entity.Update(gameTime);

            foreach (IEntity entity in enemyProj)
                entity.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBlock entity in blocks)
                entity.Draw(spriteBatch, Color.White);

            foreach (IEntity entity in enemies.Values)
                entity.Draw(spriteBatch, Color.White);

            foreach (IEntity entity in items)
                entity.Draw(spriteBatch, Color.White);

            foreach (IEntity entity in garbage)
                entity.Draw(spriteBatch, Color.White);

            foreach(IEntity entity in enemyProj)
                entity.Draw(spriteBatch, Color.White);
        }

        public void ChangePosition(bool pause)
        {
            Pause = pause;
            foreach (IBlock entity in blocks)
            {
                if(count != 176 * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + 2 * Global.Var.SCALE;
                }
                else if (count != 176 * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - 2 * Global.Var.SCALE;
                }
            }

            foreach (IEntity entity in enemies.Values)
            {
                if (count != 176 * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + 2 * Global.Var.SCALE;
                }
                else if (count != 176 * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - 2 * Global.Var.SCALE;
                }
            }

            foreach (IEntity entity in items)
            {
                if (count != 176 * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + 2 * Global.Var.SCALE;
                }
                else if (count != 176 * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - 2 * Global.Var.SCALE;
                }
            }

            foreach (IEntity entity in garbage)
            {
                if (count != 176 * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + 2 * Global.Var.SCALE;
                }
                else if (count != 176 * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - 2 * Global.Var.SCALE;
                }
            }

            foreach (IEntity entity in enemyProj)
            {
                if (count != 176 * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + 2 * Global.Var.SCALE;
                }
                else if (count != 176 * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - 2 * Global.Var.SCALE;
                }
            }

            count = count + 2*Global.Var.SCALE;
        }

        public void SetPauseCount()
        {
            count = 0;
        }
    }
}
