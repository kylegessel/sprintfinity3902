using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprintfinity3902.Dungeon
{
    public class Dungeon : IDungeon
    {
        private List<IRoom> dungeonRooms;
        private IRoom currentRoom;
        private int currentId;
        public int Id { get; set; }

        public Dungeon()
        {
            dungeonRooms = new List<IRoom>();
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room1.csv", 1));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room2.csv", 2));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room3.csv", 3));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room4.csv", 4));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room5.csv", 5));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room6.csv", 6));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room7.csv", 7));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room8.csv", 8));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room9.csv", 9));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room10.csv", 10));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room11.csv", 11));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room12.csv", 12));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room13.csv", 13));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room14.csv", 14));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room15.csv", 15));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room16.csv", 16));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room17.csv", 17));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room18.csv", 18));
            dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\TestRoom.csv", 19));

            currentRoom = GetById(1);
            currentId = 1;
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

        public void NextRoom()
        {
            currentId = currentRoom.Id;
            if(currentRoom.Id == 19)
            {
                currentRoom = GetById(1);
            }
            else
            {
                currentId++;
                currentRoom = GetById(currentId);
            }
        }

        public void PreviousRoom()
        {
            currentId = currentRoom.Id;
            if (currentRoom.Id == 1)
            {
                currentRoom = GetById(19);
            }
            else
            {
                currentId--;
                currentRoom = GetById(currentId);
            }
        }
    }
}
