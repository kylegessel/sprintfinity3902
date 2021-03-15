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
        public List<IEntity> enemies { get; set; }
        public List<IEntity> items { get; set; }
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
            enemies = new List<IEntity>();
            items = new List<IEntity>();
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

            foreach (IEntity entity in enemies)
                entity.Update(gameTime);

            foreach (IEntity entity in items)
                entity.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBlock entity in blocks)
                entity.Draw(spriteBatch);

            foreach (IEntity entity in enemies)
                entity.Draw(spriteBatch);

            foreach (IEntity entity in items)
                entity.Draw(spriteBatch);
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

            foreach (IEntity entity in enemies)
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
            count = count + 2*Global.Var.SCALE;
        }

        public void SetPauseCount()
        {
            count = 0;
        }
    }
}
