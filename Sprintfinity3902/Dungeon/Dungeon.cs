using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Dungeon.GameState;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System.Collections.Generic;
using System.Linq;
using Sprintfinity3902.Dungeon.GameState;
using System.Diagnostics;

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

        private string backgroundMusicInstanceID;

        /* TODO: For demo only to show death and win state*/
        private IDungeon.GameState state;

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

            Game = game;

            backgroundMusicInstanceID = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Dungeon), 0.02f, true);

            SoundManager.Instance.GetSoundEffectInstance(backgroundMusicInstanceID).Play();
        }

        public void Build()
        {
            IRoomLoader rload = new RoomLoader();
            foreach(IRoom room in dungeonRooms)
            {
                rload.Initialize(room);
                rload.Build();
            }
        }

        public void GameStateUpdate(IDungeon.GameState local_state) {
            state = local_state;
            switch (state) {
                case IDungeon.GameState.WIN:
                    CurrentRoom = new WinWrapper(CurrentRoom, this);
                    break;
                case IDungeon.GameState.LOSE:
                    CurrentRoom = new LoseWrapper(CurrentRoom, this);
                    break;
                case IDungeon.GameState.RETURN:
                    // TODO - Return to game and show options
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            
            CurrentRoom.Update(gameTime);

            /* Artificial call to gamewin */
           
            if (state.Equals(IDungeon.GameState.NULL) && gameTime.TotalGameTime.TotalSeconds > 2) {
                GameStateUpdate(IDungeon.GameState.WIN);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentRoom.Draw(spriteBatch, Color.White);
        }

        public IRoom GetById(int id)
        {
            return this.dungeonRooms.FirstOrDefault(z => z.Id == id);
        }

        public void NextRoom()
        {
            int currentId = (CurrentRoom.Id + 1) % 19 == 0 ? 1 : CurrentRoom.Id + 1;
            SetCurrentRoom(currentId);
        }

        public void PreviousRoom()
        {
            int currentId = (CurrentRoom.Id - 1) < 1 ? 18 : CurrentRoom.Id - 1;
            SetCurrentRoom(currentId);
        }

        public IRoom GetCurrentRoom()
        {
            return CurrentRoom;
        }

        public void SetCurrentRoom(int id)
        {
            CurrentRoom.garbage.Clear();
            CurrentRoom = GetById(id);
            SetLinkPosition();
        }

        /*MAGIC NUMBERS REFACTOR*/
        //SET UP FOR SPRINT 3 ONLY. WILL BE REMOVED UPON SUBMITTING.
        public void SetLinkPosition()
        {
            IRoom room = GetCurrentRoom();
            if(room.Id == 13)
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
            SoundManager.Instance.DestroySoundEffectInstance(backgroundMusicInstanceID);
        }
    }
}
