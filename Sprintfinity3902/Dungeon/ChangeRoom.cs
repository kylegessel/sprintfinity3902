using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.States.Door;
using System;

namespace Sprintfinity3902.Dungeon
{


    public class ChangeRoom : Interfaces.IDrawable, Interfaces.IUpdateable
    {
        private Game1 Game;
        public Player Link;
        public Map Map { get; set; }
        IRoom nextRoom;
        Vector2 NextRoomPositionOffset;
        Vector2 CurrRoomPositionOffset;
        Vector2 CurrRoomPositionReset;
        DoorDirection doorDirection;
        public bool Change;
        int nextRoomID;
        int offsetTotal;
        private const int ROOM_WIDTH = 256;
        private const int ROOM_HEIGHT = 176;
        private const int SHIFT_AMOUNT = 2;
        public ChangeRoom(Game1 game)
        {
            Game = game;
            Link = game.link;
            Change = false;
            offsetTotal = 0;
            CurrRoomPositionOffset = new Vector2(0, 0);
            NextRoomPositionOffset = new Vector2(-1, -1);
        }

        public void Update(GameTime gameTime)
        {
            if (nextRoom != null)
            {
                foreach (IBlock block in nextRoom.blocks)
                {
                    block.Update(gameTime);
                }

                foreach (IDoor door in nextRoom.doors)
                {
                    door.Update(gameTime);
                }
            }

            if (Change)
            {
                ChangeOffset();
            }

            if(offsetTotal == 0)
            {
                StopAnimation();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (nextRoom != null)
            {
                foreach (IBlock block in nextRoom.blocks)
                {

                    block.Position = new Vector2(block.Position.X + NextRoomPositionOffset.X, block.Position.Y + NextRoomPositionOffset.Y);
                    block.Draw(spriteBatch, Color.White);
                }

                foreach (IDoor door in nextRoom.doors)
                {
                    door.Position = new Vector2(door.Position.X + NextRoomPositionOffset.X, door.Position.Y + NextRoomPositionOffset.Y);
                    door.Draw(spriteBatch, Color.White);
                }

                foreach (IBlock block in Game.dungeon.CurrentRoom.blocks)
                {
                    block.Position = new Vector2(block.Position.X + CurrRoomPositionOffset.X, block.Position.Y + CurrRoomPositionOffset.Y);
                    block.Draw(spriteBatch, Color.White);
                }

                foreach (IDoor door in Game.dungeon.CurrentRoom.doors)
                {
                    door.Position = new Vector2(door.Position.X + CurrRoomPositionOffset.X, door.Position.Y + CurrRoomPositionOffset.Y);
                    door.Draw(spriteBatch, Color.White);
                }
                
            }
        }

        public void StartAnimation(int nextRoomID, DoorDirection direction)
        {
            nextRoom = Game.dungeon.GetById(nextRoomID);
            this.nextRoomID = nextRoomID;
            doorDirection = direction;
            Offset();
            Change = true;
            UnregisterCommands();
            Link.Position = new Vector2(-1000, -1000);
        }

        public void StopAnimation()
        {
            

            // Temp while I change bounding boxes for unopened rooms.          

            foreach (IBlock block in nextRoom.blocks)
            {

                block.Position = new Vector2(block.Position.X + NextRoomPositionOffset.X, block.Position.Y + NextRoomPositionOffset.Y);
            }

            foreach (IDoor door in nextRoom.doors)
            {
                door.Position = new Vector2(door.Position.X + NextRoomPositionOffset.X, door.Position.Y + NextRoomPositionOffset.Y);
            }

            foreach (IBlock block in Game.dungeon.CurrentRoom.blocks)
            {
                block.Position = new Vector2(block.Position.X + CurrRoomPositionReset.X, block.Position.Y + CurrRoomPositionReset.Y);
            }

            foreach (IDoor door in Game.dungeon.CurrentRoom.doors)
            {
                door.Position = new Vector2(door.Position.X + CurrRoomPositionReset.X, door.Position.Y + CurrRoomPositionReset.Y);
            }

            Game.dungeon.SetCurrentRoom(nextRoomID);

            switch (doorDirection)
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
            Change = false;
            ReregisterCommands();
        }

        public void Offset()
        {
            CurrRoomPositionOffset = new Vector2(0, 0);
            switch (doorDirection)
            {
                case DoorDirection.UP:
                    NextRoomPositionOffset = new Vector2(0, -(ROOM_HEIGHT)*Global.Var.SCALE);
                    CurrRoomPositionReset = new Vector2(0, -(ROOM_HEIGHT - 2) * Global.Var.SCALE);
                    offsetTotal = -ROOM_HEIGHT * Global.Var.SCALE;
                    break;
                case DoorDirection.DOWN:
                    NextRoomPositionOffset = new Vector2(0, (ROOM_HEIGHT) * Global.Var.SCALE);
                    CurrRoomPositionReset = new Vector2(0, (ROOM_HEIGHT - 2) * Global.Var.SCALE);
                    offsetTotal = ROOM_HEIGHT * Global.Var.SCALE;
                    break;
                case DoorDirection.LEFT:
                    NextRoomPositionOffset = new Vector2(-ROOM_WIDTH * Global.Var.SCALE, 0);
                    CurrRoomPositionReset = new Vector2(-(ROOM_WIDTH - 2) * Global.Var.SCALE, 0);
                    offsetTotal = -ROOM_WIDTH * Global.Var.SCALE;
                    break;
                case DoorDirection.RIGHT:
                    NextRoomPositionOffset = new Vector2(ROOM_WIDTH * Global.Var.SCALE, 0);
                    CurrRoomPositionReset = new Vector2((ROOM_WIDTH - 2) * Global.Var.SCALE, 0);
                    offsetTotal = ROOM_WIDTH * Global.Var.SCALE;
                    break;
            }
        }

        public void ChangeOffset()
        {
            
            switch (doorDirection)
            {
                case DoorDirection.UP:
                    NextRoomPositionOffset = new Vector2(0, SHIFT_AMOUNT * Global.Var.SCALE);
                    CurrRoomPositionOffset = new Vector2(0, SHIFT_AMOUNT * Global.Var.SCALE);
                    offsetTotal += SHIFT_AMOUNT * Global.Var.SCALE;
                    break;
                case DoorDirection.DOWN:
                    NextRoomPositionOffset = new Vector2(0, -SHIFT_AMOUNT * Global.Var.SCALE);
                    CurrRoomPositionOffset = new Vector2(0, -SHIFT_AMOUNT * Global.Var.SCALE);
                    offsetTotal += -SHIFT_AMOUNT * Global.Var.SCALE;
                    break;
                case DoorDirection.LEFT:
                    NextRoomPositionOffset = new Vector2(SHIFT_AMOUNT * Global.Var.SCALE, 0);
                    CurrRoomPositionOffset = new Vector2(SHIFT_AMOUNT * Global.Var.SCALE, 0);                    
                    offsetTotal += SHIFT_AMOUNT * Global.Var.SCALE;
                    break;
                case DoorDirection.RIGHT:
                    NextRoomPositionOffset = new Vector2(-SHIFT_AMOUNT * Global.Var.SCALE, 0);
                    CurrRoomPositionOffset = new Vector2(-SHIFT_AMOUNT * Global.Var.SCALE, 0);
                    offsetTotal += -SHIFT_AMOUNT * Global.Var.SCALE;
                    break;
            }
        }
        public void SetLinkPositionUp()
        {
            // 112 * Global.Var.SCALE, 64 * Global.Var.SCALE
            Link.X = 120 * Global.Var.SCALE;
            Link.Y = (64 + 35) * Global.Var.SCALE;
        }

        public void SetLinkPositionDown()
        {
            Link.X = 120 * Global.Var.SCALE;
            Link.Y = 193 * Global.Var.SCALE;
        }
        public void SetLinkPositionLeft()
        {
            Link.X = 35 * Global.Var.SCALE;
            Link.Y = (136 + 8) * Global.Var.SCALE;
        }
        public void SetLinkPositionRight()
        {
            Link.X = (224 - 16) * Global.Var.SCALE;
            Link.Y = (136 + 8) * Global.Var.SCALE;
        }
        public void UnregisterCommands()
        {
            KeyboardManager.Instance.RegisterCommand(new DoNothingCommand(Game), Keys.W, Keys.Up, Keys.S, Keys.Down, Keys.A, Keys.Left, Keys.D, Keys.Right);
            KeyboardManager.Instance.RegisterCommand(new DoNothingCommand(Game), Keys.E, Keys.D1, Keys.D2, Keys.Z, Keys.N);

            KeyboardManager.Instance.RemoveKeyUpCallback(Keys.L, Keys.K);

            //Store Link within Game, then reset to that Link
        }

        public void ReregisterCommands()
        {
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveUpCommand((Player)Link), Keys.W, Keys.Up);
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveLeftCommand((Player)Link), Keys.A, Keys.Left);
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveDownCommand((Player)Link), Keys.S, Keys.Down);
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveRightCommand((Player)Link), Keys.D, Keys.Right);
            KeyboardManager.Instance.RegisterCommand(new SetDamageLinkCommand(Game), Keys.E);
            KeyboardManager.Instance.RegisterCommand(new UseBombCommand((Player)Link, (BombItem)Game.bombItem), Keys.D1);
            KeyboardManager.Instance.RegisterCommand(new UseBoomerangCommand((Player)Link, (BoomerangItem)Game.boomerangItem), Keys.D2);
            KeyboardManager.Instance.RegisterCommand(new UseBowCommand((Player)Link, (ArrowItem)Game.bowArrow), Keys.D3);
            KeyboardManager.Instance.RegisterCommand(new SetLinkAttackCommand((Player)Link, (MovingSwordItem)Game.movingSword, (SwordHitboxItem)Game.hitboxSword), Keys.Z, Keys.N);

            KeyboardManager.Instance.RegisterKeyUpCallback(Game.dungeon.NextRoom, Keys.L);
            KeyboardManager.Instance.RegisterKeyUpCallback(Game.dungeon.PreviousRoom, Keys.K);
        }
    }
}

