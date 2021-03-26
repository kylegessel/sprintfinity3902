using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Dungeon.GameState;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System.Collections.Generic;
using System.Linq;
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

        public Dungeon(Game1 game)
        {

            dungeonRooms = new List<IRoom>();

            for (int roomNum = 1; roomNum < 19; roomNum++) {
                dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room" + roomNum + ".csv", roomNum));
            }

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

        public void Update(GameTime gameTime)
        {
            CurrentRoom.Update(gameTime);
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

            Game.link.X = (room.Id == 13 ? FORTY_EIGHT : ONE_HUNDRED_TWENTY) * Global.Var.SCALE;
            Game.link.Y = (room.Id == 13 ? NINETY_SEVEN : ONE_HUNDRED_NINETY_THREE) * Global.Var.SCALE;
        }

        public void CleanUp() {
            SoundManager.Instance.DestroySoundEffectInstance(backgroundMusicInstanceID);
        }

        public void UpdateState(IDungeon.GameState state)
        {
            switch (state) {
                case IDungeon.GameState.WIN:
                    CurrentRoom = new WinWrapper(CurrentRoom, this, Game);
                    break;
                case IDungeon.GameState.LOSE:
                    CurrentRoom = new LoseWrapper(CurrentRoom, this, Game);
                    break;
                case IDungeon.GameState.RETURN:
                    Game.UpdateState(Game1.GameState.OPTIONS);
                    break;
            }
        }
    }
}
