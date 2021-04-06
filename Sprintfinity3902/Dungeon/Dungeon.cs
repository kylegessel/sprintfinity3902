using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Dungeon.GameState;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.Sound;
using Sprintfinity3902.States.Door;
using System.Collections.Generic;
using System.Linq;

namespace Sprintfinity3902.Dungeon
{
    public class Dungeon : IDungeon
    {
        
        /*MAGIC NUMBERS REFACTOR*/
        private static int FORTY_EIGHT = 48;
        private static int NINETY_SEVEN = 97;

        private Game1 Game;
        private List<IRoom> dungeonRooms;
        public List<Point> RoomLocations { get; set; }
        private IEntity movingSword;
        public IEntity bombExplosion;
        public IEntity hitboxSword;
        public IRoom CurrentRoom { get; set; }
        public IEntity bowArrow { get; set; }
        public IEntity bombItem { get; set; }
        public IEntity boomerangItem { get; set; }


        private string backgroundMusicInstanceID;


        public List<IEntity> linkProj;

        public Dungeon(Game1 game)
        {

            boomerangItem = new BoomerangItem();
            bombExplosion = new BombExplosionItem(new Vector2(-1000, -1000));
            bombItem = new BombItem(new Vector2(-1000, -1000), (BombExplosionItem)bombExplosion);
            movingSword = new MovingSwordItem(new Vector2(-1000, -1000));
            hitboxSword = new SwordHitboxItem(new Vector2(-1000, -1000));
            bowArrow = new ArrowItem(new Vector2(-1000, -1000));

            dungeonRooms = new List<IRoom>();
            RoomLocations = new List<Point>();

            for (int roomNum = 1; roomNum <= 18; roomNum++) {
                dungeonRooms.Add(new Room(@"..\..\..\Content\Rooms\Room" + roomNum + ".csv", roomNum));
            }

            CurrentRoom = GetById(1);
            Game = game;

            linkProj = new List<IEntity>();

            linkProj.Add(boomerangItem);
            linkProj.Add(bombExplosion);
            linkProj.Add(movingSword);
            linkProj.Add(hitboxSword);
            linkProj.Add(bowArrow);

            backgroundMusicInstanceID = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Dungeon), 0.02f, true);
        }

        public void Initialize()
        {
            CollisionDetector.Instance.Initialize(Game);
            KeyboardManager.Instance.RegisterKeyUpCallback(NextRoom, Keys.L);
            KeyboardManager.Instance.RegisterKeyUpCallback(PreviousRoom, Keys.K);
            KeyboardManager.Instance.RegisterCommand(new SetDamageLinkCommand(Game), Keys.E);
            //KeyboardManager.Instance.RegisterCommand(new UseBombCommand((Player)Game.playerCharacter, (BombItem)bombItem), Keys.D1);
            KeyboardManager.Instance.RegisterCommand(new UseSelectedItemCommand((Player)Game.playerCharacter, this), Keys.D1);
            //KeyboardManager.Instance.RegisterCommand(new UseBoomerangCommand((Player)Game.playerCharacter, (BoomerangItem)boomerangItem), Keys.D2);
            //KeyboardManager.Instance.RegisterCommand(new UseBowCommand((Player)Game.playerCharacter, (ArrowItem)bowArrow), Keys.D3);
            KeyboardManager.Instance.RegisterCommand(new SetLinkAttackCommand((Player)Game.playerCharacter, (MovingSwordItem)movingSword, (SwordHitboxItem)hitboxSword), Keys.Z, Keys.N);

            SoundManager.Instance.GetSoundEffectInstance(backgroundMusicInstanceID).Play();

            IRoomLoader rload = new RoomLoader();
            foreach(IRoom room in dungeonRooms)
            {
                rload.Initialize(room);
                rload.Build();
                if (room.Id != 13)
                { 
                    RoomLocations.Add(room.RoomPos);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            CollisionDetector.Instance.CheckCollision(CurrentRoom.enemies, CurrentRoom.blocks, CurrentRoom.items, linkProj, CurrentRoom.enemyProj, CurrentRoom.doors, CurrentRoom.garbage);
            CurrentRoom.Update(gameTime);
            foreach (IEntity entity in linkProj) {
                entity.Update(gameTime);
            }
            bombItem.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentRoom.Draw(spriteBatch, Color.White);
            foreach (IEntity entity in linkProj) {
                entity.Draw(spriteBatch, Color.White);
            }
            bombItem.Draw(spriteBatch, Color.White);
        }

        public IRoom GetById(int id)
        {
            return this.dungeonRooms.FirstOrDefault(z => z.Id == id);
        }

        public void NextRoom()
        {
            int currentId = (CurrentRoom.Id + 1) % 19 == 0 ? 1 : CurrentRoom.Id + 1;
            SetCurrentRoom(currentId);
            SetLinkPosition();
        }

        public void PreviousRoom()
        {
            int currentId = (CurrentRoom.Id - 1) < 1 ? 18 : CurrentRoom.Id - 1;
            SetCurrentRoom(currentId);
            SetLinkPosition();
        }

        public IRoom GetCurrentRoom()
        {
            return CurrentRoom;
        }

        public void SetCurrentRoom(int id)
        {
            CurrentRoom.garbage.Clear();
            CurrentRoom = GetById(id);
        }
        public void ChangeRoom(IDoor door)
        {
            SetLinkPosition(door.CurrentState.doorDirection);
            SetCurrentRoom(door.DoorDestination);
        }
        
        public void SetLinkPosition(DoorDirection door = DoorDirection.UP)
        {
            if (CurrentRoom.Id == 13) {
                Game.link.X = FORTY_EIGHT * Global.Var.SCALE;
                Game.link.Y = NINETY_SEVEN * Global.Var.SCALE;
                return;
            }

            switch (door) {
                case DoorDirection.UP:
                    Game.link.X = 120 * Global.Var.SCALE;
                    Game.link.Y = 193 * Global.Var.SCALE;
                    break;
                case DoorDirection.DOWN:
                    Game.link.X = 120 * Global.Var.SCALE;
                    Game.link.Y = (64 + 35) * Global.Var.SCALE;
                    break;
                case DoorDirection.LEFT:
                    Game.link.X = (224 - 16) * Global.Var.SCALE;
                    Game.link.Y = (136 + 8) * Global.Var.SCALE;
                    break;
                case DoorDirection.RIGHT:
                    Game.link.X = 35 * Global.Var.SCALE;
                    Game.link.Y = (136 + 8) * Global.Var.SCALE;
                    break;
            }
        }
        

        public void UpdateState(IDungeon.GameState state)
        {
            switch (state) {
                case IDungeon.GameState.WIN:
                    KeyboardManager.Instance.PushCommandMatrix();
                    Game.playerCharacter.SetState(Game.playerCharacter.facingDown);
                    Game.playerCharacter.CurrentState.Sprite.Animation.Stop();
                    CurrentRoom = new WinWrapper(CurrentRoom, this, Game);
                    break;
                case IDungeon.GameState.LOSE:
                    KeyboardManager.Instance.PushCommandMatrix();
                    CurrentRoom = new LoseWrapper(CurrentRoom, this, Game);
                    break;
                case IDungeon.GameState.RETURN:
                    KeyboardManager.Instance.PopCommandMatrix();
                    Game.SetState(Game.OPTIONS);
                    break;
            }
        }
    }
}
