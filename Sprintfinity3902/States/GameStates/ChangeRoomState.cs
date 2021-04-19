using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.States.Door;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprintfinity3902.States.GameStates
{
    public class ChangeRoomState : IGameState
    {
        private Game1 Game;
        private IDoor Door;
        public ILink Link;
        public IPlayer Player;
        public IMap Map { get; set; }
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
        private const int LINK_VERTICAL_DOOR_X = 120;
        private const int LINK_HORIZONTAL_DOOR_Y = 144;
        private const int LINK_UP_Y = 99;
        private const int LINK_DOWN_Y = 193;
        private const int LINK_LEFT_X = 35;
        private const int LINK_RIGHT_X = 208;

        public ChangeRoomState(Game1 game, IDoor door)
        {
            Game = game;
            Link = game.link;
            game.link.RemoveDecorator();
            Player = (IPlayer)game.link;
            Change = false;
            offsetTotal = 0;
            CurrRoomPositionOffset = new Vector2(0, 0);
            NextRoomPositionOffset = new Vector2(-1, -1);
            Door = door;
            nextRoomID = door.DoorDestination;
        }
        public void SetUp()
        {
            KeyboardManager.Instance.PushCommandMatrix();
            Player.CurrentState.Sprite.Animation.Stop();
            nextRoom = Game.dungeon.GetById(nextRoomID);
            doorDirection = Door.CurrentState.doorDirection;
            Offset();
            Change = true;
            Link.Position = new Vector2(-1000, -1000);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
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

            Game.dungeonHud.Draw(spriteBatch, Color.White);
            HudMenu.InGameHud.Instance.Draw(spriteBatch, Color.White);
            HudMenu.InventoryHud.Instance.Draw(spriteBatch, Color.White);
            Game.miniMapHud.Draw(spriteBatch, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            foreach (IBlock block in nextRoom.blocks)
            {
                block.Update(gameTime);
            }
              
            foreach (IDoor door in nextRoom.doors)
            {
                door.Update(gameTime);
            }

            Game.dungeonHud.Update(gameTime);
            HudMenu.InGameHud.Instance.Update(gameTime);
            HudMenu.InventoryHud.Instance.Update(gameTime);
            Game.miniMapHud.Update(gameTime);

            if (Change)
            {
                ChangeOffset();
            }

            if (offsetTotal == 0)
            {
                StopAnimation();
            }
        }


        public void Offset()
        {
            CurrRoomPositionOffset = new Vector2(0, 0);
            switch (doorDirection)
            {
                case DoorDirection.UP:
                    NextRoomPositionOffset = new Vector2(0, -(ROOM_HEIGHT) * Global.Var.SCALE);
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
                    if (Game.dungeon.CurrentRoom.doors[1].CurrentState.IsBombable || Game.dungeon.CurrentRoom.doors[1].CurrentState.IsLocked)
                        Game.dungeon.CurrentRoom.doors[1].Open();
                    SetLinkPositionDown();
                    break;
                case DoorDirection.DOWN:
                    // Set links position to the top of the next room.
                    if (Game.dungeon.CurrentRoom.doors[0].CurrentState.IsBombable || Game.dungeon.CurrentRoom.doors[0].CurrentState.IsLocked)
                        Game.dungeon.CurrentRoom.doors[0].Open();
                    SetLinkPositionUp();
                    break;
                case DoorDirection.LEFT:
                    if (Game.dungeon.CurrentRoom.doors[3].CurrentState.IsBombable || Game.dungeon.CurrentRoom.doors[3].CurrentState.IsLocked)
                        Game.dungeon.CurrentRoom.doors[3].Open();
                    // Set links position to the top of the next room.
                    SetLinkPositionRight();

                    break;
                case DoorDirection.RIGHT:
                    if (Game.dungeon.CurrentRoom.doors[2].CurrentState.IsBombable || Game.dungeon.CurrentRoom.doors[2].CurrentState.IsLocked)
                        Game.dungeon.CurrentRoom.doors[2].Open();
                    // Set links position to the top of the next room.
                    SetLinkPositionLeft();

                    break;
            }
            Change = false;

            foreach (IDoor door in nextRoom.doors)
            {
                Debug.WriteLine(door.roomEntered);
                if (!door.roomEntered)
                {
                    door.roomEntered = true;
                    door.Close();
                }
            }
            Game.SetState(Game.PLAYING);
        }
        public void SetLinkPositionUp()
        {
            Link.X = LINK_VERTICAL_DOOR_X * Global.Var.SCALE;
            Link.Y = LINK_UP_Y * Global.Var.SCALE;
        }

        public void SetLinkPositionDown()
        {
            Link.X = LINK_VERTICAL_DOOR_X * Global.Var.SCALE;
            Link.Y = LINK_DOWN_Y * Global.Var.SCALE;
        }
        public void SetLinkPositionLeft()
        {
            Link.X = LINK_LEFT_X * Global.Var.SCALE;
            Link.Y = LINK_HORIZONTAL_DOOR_Y * Global.Var.SCALE;
        }
        public void SetLinkPositionRight()
        {
            Link.X = LINK_RIGHT_X * Global.Var.SCALE;
            Link.Y = LINK_HORIZONTAL_DOOR_Y * Global.Var.SCALE;
        }
    }
}
