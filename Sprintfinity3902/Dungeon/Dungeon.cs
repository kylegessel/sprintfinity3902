using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System.Collections.Generic;
using System.Linq;

namespace Sprintfinity3902.Dungeon
{
    public class Dungeon : IDungeon
    {
        /*MAGIC NUMBERS REFACTOR*/
        private static int FORTY_EIGHT = 48;
        private static int NINETY_SEVEN = 97;
        private static int ONE_HUNDRED_TWENTY = 120;
        private static int ONE_HUNDRED_NINETY_THREE = 193;

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
            SetLinkPosition();
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

        /*MAGIC NUMBERS REFACTOR*/
        //SET UP FOR SPRINT 3 ONLY. WILL BE REMOVED UPON SUBMITTING.
        public void SetLinkPosition()
        {
            IRoom room = GetCurrentRoom();
            if(NextId == 13)
            {
                Game.link.X = FORTY_EIGHT * Global.Var.SCALE;
                Game.link.Y = NINETY_SEVEN * Global.Var.SCALE;
            }
            else
            {
                Game.link.X = ONE_HUNDRED_TWENTY * Global.Var.SCALE;
                Game.link.Y = ONE_HUNDRED_NINETY_THREE * Global.Var.SCALE;
            }
        }

        public void CleanUp() {
            SoundManager.Instance.GetSoundEffectInstance(backgroundMusicInstanceID).Stop();
            SoundManager.Instance.GetSoundEffectInstance(backgroundMusicInstanceID).Dispose();
        }
    }
}
