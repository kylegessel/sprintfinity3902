using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprintfinity3902.Maps
{
    public class Dungeon : IDungeon
    {
        private List<IRoom> dungeonRooms;
        private IRoom currentRoom;
        public int Id { get; set; }

        public Dungeon()
        {
            dungeonRooms = new List<IRoom>();
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room1.csv", 1));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room2.csv", 2));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\TestRoom.csv", 3));

            currentRoom = GetById(1);
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
            currentRoom.Update(gameTime);
            /*
            foreach(IRoom room in dungeonRooms)
            {
                room.Update(gameTime);
            }
            */
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentRoom.Draw(spriteBatch);
            /*
            foreach(IRoom room in dungeonRooms)
            {
                room.Draw(spriteBatch);
            }
            */
        }

        public IRoom GetById(int id)
        {
            return this.dungeonRooms.FirstOrDefault(z => z.Id == id);
        }
    }
}
