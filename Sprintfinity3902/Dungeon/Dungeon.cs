using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using Sprintfinity3902.States.Door;
using System.Collections.Generic;
using System.Linq;

namespace Sprintfinity3902.Dungeon
{
    public class Dungeon : IDungeon
    {
        private Game1 Game;
        private List<IRoom> dungeonRooms;
        public IRoom CurrentRoom { get; set; }
        private int currentId;
        public int NextId { get; set; }

        private string backgroundMusicInstanceID;

        public Dungeon(Game1 game)
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

            CurrentRoom = GetById(1);
            currentId = CurrentRoom.Id;
            NextId = CurrentRoom.Id;

            Game = game;

            backgroundMusicInstanceID = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Dungeon), 0.02f, true);

            SoundManager.Instance.GetSoundEffectInstance(backgroundMusicInstanceID).Play();
        }

        public void Build()
        {
            foreach(IRoom room in dungeonRooms)
            {
                if(room.Id == 13)
                {
                    room.loader13.Build();
                }
                else
                {
                    room.loader.Build();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (CurrentRoom.Id != NextId) {
            //SetLinkPosition();
            CurrentRoom.garbage.Clear();
        }
            CurrentRoom = GetById(NextId);
            CurrentRoom.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentRoom.Draw(spriteBatch);
        }

        public IRoom GetById(int id)
        {
            return this.dungeonRooms.FirstOrDefault(z => z.Id == id);
        }

        public void NextRoom()
        {
            currentId = CurrentRoom.Id;
            if(CurrentRoom.Id == 18)
            {
                CurrentRoom = GetById(1);
            }
            else
            {
                currentId++;
                CurrentRoom = GetById(currentId);
            }
            NextId = CurrentRoom.Id;
            CurrentRoom.garbage.Clear();
            SetLinkPosition();
        }

        public void PreviousRoom()
        {
            currentId = CurrentRoom.Id;
            if (CurrentRoom.Id == 1)
            {
                CurrentRoom = GetById(18);
            }
            else
            {
                currentId--;
                CurrentRoom = GetById(currentId);
            }
            NextId = CurrentRoom.Id;
            CurrentRoom.garbage.Clear();
            SetLinkPosition();
        }

        public IRoom GetCurrentRoom()
        {
            return CurrentRoom;
        }

        public void SetCurrentRoom(int id)
        {
            NextId = id;
        }
        public void ChangeRoom(IDoor door)
        {
            switch (door.CurrentState.doorDirection)
            {
                case DoorDirection.UP:
                    // Set links position to the bottom of the next room.
                    SetLinkPositionDown();
                    break;
                case DoorDirection.DOWN:
                    // Set links position to the top of the next room.
                    SetLinkPositionUp();
                    break;
                case DoorDirection.LEFT:
                    // Set links position to the top of the next room.
                    SetLinkPositionRight();
                    break;
                case DoorDirection.RIGHT:
                    // Set links position to the top of the next room.
                    SetLinkPositionLeft();
                    break;
            }
            SetCurrentRoom(door.DoorDestination);
        }
        public void SetLinkPositionUp()
        {
            // 112 * Global.Var.SCALE, 64 * Global.Var.SCALE
            Game.link.X = 120 * Global.Var.SCALE;
            Game.link.Y = (64 + 35) * Global.Var.SCALE;
        }

        public void SetLinkPositionDown()
        {
            Game.link.X = 120 * Global.Var.SCALE;
            Game.link.Y = 193 * Global.Var.SCALE;
        }
        public void SetLinkPositionLeft()
        {
            Game.link.X = 35 * Global.Var.SCALE;
            Game.link.Y = (136 + 8) * Global.Var.SCALE;
        }
        public void SetLinkPositionRight()
        {
            Game.link.X = (224 - 16) * Global.Var.SCALE;
            Game.link.Y = (136+8) * Global.Var.SCALE;
        }

        public void SetLinkPosition()
        {
            IRoom room = GetCurrentRoom();
            
            if(NextId == 13)
            {
                Game.link.X = 48 * Global.Var.SCALE;
                Game.link.Y = 97 * Global.Var.SCALE;
            }
            else
            {
                Game.link.X = 120 * Global.Var.SCALE;
                Game.link.Y = 193 * Global.Var.SCALE;
            }
        }

        public void CleanUp() {
            SoundManager.Instance.GetSoundEffectInstance(backgroundMusicInstanceID).Stop();
            SoundManager.Instance.GetSoundEffectInstance(backgroundMusicInstanceID).Dispose();
        }
    }
}
