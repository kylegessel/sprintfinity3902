using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

namespace Sprintfinity3902.Dungeon
{
    public class Room : IRoom
    {
        /*MAGIC NUMBERS REFACTOR*/
        private static int INITIAL_ROOM_TYPE = 1;
        private static int INITIAL_ROOM_X = 2;
        private static int INITIAL_ROOM_Y = 7;
        private static int PAUSE_COUNT = 176;
        private static int SHIFT_AMOUNT = 2;

        public int Id { get; set; }
        //public List<IEntity> roomEntities { get; set; }
        public List<IBlock> blocks { get; set; }
        public Dictionary<int, IEntity> enemies { get; set; }
        public List<IEntity> items { get; set; }
        public List<IEntity> enemyProj { get; set; }
        public List<IEntity> garbage { get; set; }
        public List<IDoor> doors { get; set; }
        public Point RoomPos { get; set; }
        public int RoomType { get; set; }

        public bool WinRoom { get; set; }
        public bool roomCleared { get; set; }
        //projectiles may have to be added here later.

        public string path { get; set; }
        public bool Pause { get; set; }
        public float startY { get; set; }
        public int count { get; set; }

        public Room(string fileLocation, int id)
        {
            blocks = new List<IBlock>();
            enemies = new Dictionary<int, IEntity>();
            items = new List<IEntity>();
            garbage = new List<IEntity>();
            enemyProj = new List<IEntity>();
            doors = new List<IDoor>();
            RoomPos = new Point(INITIAL_ROOM_X, INITIAL_ROOM_Y);
            WinRoom = false;
            RoomType = INITIAL_ROOM_TYPE;
            path = fileLocation;
            Id = id;
            Pause = false;
            roomCleared = false;
        }

        public void Update(GameTime gameTime)
        { 
            foreach (IBlock entity in blocks)
                entity.Update(gameTime);
            foreach (IEntity entity in enemyProj)
                entity.Update(gameTime);
            foreach (IEntity entity in enemies.Values)
                entity.Update(gameTime);

            foreach (IEntity entity in items)
                entity.Update(gameTime);

            foreach (IEntity entity in garbage)
                entity.Update(gameTime);
            foreach (IDoor door in doors)
                door.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            foreach (IBlock entity in blocks)
                entity.Draw(spriteBatch, color);
            foreach (IEntity entity in enemyProj)
                entity.Draw(spriteBatch, color);
            foreach (IEntity entity in enemies.Values)
                entity.Draw(spriteBatch, color);

            foreach (IEntity entity in items)
                entity.Draw(spriteBatch, color);
            foreach (IDoor door in doors)
                door.Draw(spriteBatch, color);
            foreach (IEntity entity in garbage)
                entity.Draw(spriteBatch, color);


        }

        /*MAGIC NUMBERS REFACTOR*/
        public void ChangePosition(bool pause)
        {
            Pause = pause;
            foreach (IBlock entity in blocks)
            {
                if(count != PAUSE_COUNT * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + SHIFT_AMOUNT * Global.Var.SCALE;
                }
                else if (count != PAUSE_COUNT * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - SHIFT_AMOUNT * Global.Var.SCALE;
                }
            }

            foreach (IEntity entity in enemies.Values)
            {
                if (count != PAUSE_COUNT * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + SHIFT_AMOUNT * Global.Var.SCALE;
                }
                else if (count != PAUSE_COUNT * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - SHIFT_AMOUNT * Global.Var.SCALE;
                }
            }

            foreach (IEntity entity in items)
            {
                if (count != PAUSE_COUNT * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + SHIFT_AMOUNT * Global.Var.SCALE;
                }
                else if (count != PAUSE_COUNT * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - SHIFT_AMOUNT * Global.Var.SCALE;
                }
            }

            foreach (IEntity entity in garbage)
            {
                if (count != PAUSE_COUNT * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + SHIFT_AMOUNT * Global.Var.SCALE;
                }
                else if (count != PAUSE_COUNT * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - SHIFT_AMOUNT * Global.Var.SCALE;
                }
            }

            foreach (IEntity entity in enemyProj)
            {
                if (count != PAUSE_COUNT * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + SHIFT_AMOUNT * Global.Var.SCALE;
                }
                else if (count != PAUSE_COUNT * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - SHIFT_AMOUNT * Global.Var.SCALE;
                }
            }

            foreach (IEntity entity in doors)
            {
                if (count != PAUSE_COUNT * Global.Var.SCALE && pause)
                {
                    entity.Y = entity.Y + SHIFT_AMOUNT * Global.Var.SCALE;
                }
                else if (count != PAUSE_COUNT * Global.Var.SCALE && pause == false)
                {
                    entity.Y = entity.Y - SHIFT_AMOUNT * Global.Var.SCALE;
                }
            }

            count = count + SHIFT_AMOUNT * Global.Var.SCALE;
        }

        public void SetPauseCount()
        {
            count = 0;
        }

    }
}
