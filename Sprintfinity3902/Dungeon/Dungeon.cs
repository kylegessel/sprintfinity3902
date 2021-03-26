using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Dungeon.GameState;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using Sprintfinity3902.States.Door;
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
