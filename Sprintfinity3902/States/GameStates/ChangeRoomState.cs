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
        IRoom currentRoom;
        IRoom nextRoom;
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
        private List<IBlock> currRoomBlocks;
        private List<IDoor> currRoomDoor;
        private List<IBlock> nextRoomBlocks;
        private List<IDoor> nextRoomDoor;
        private Vector2 startPosition;

        public ChangeRoomState(Game1 game, IDoor door)
        {
            Game = game;
            Link = game.link;
            game.link.RemoveDecorator();
            Player = (IPlayer)game.link;
            Change = false;
            Door = door;
            nextRoomID = door.DoorDestination;
        }
        public void SetUp()
        {
            KeyboardManager.Instance.PushCommandMatrix();
            Player.CurrentState.Sprite.Animation.Stop();
            currentRoom = Game.dungeon.GetCurrentRoom();
            nextRoom = Game.dungeon.GetById(nextRoomID);
            doorDirection = Door.CurrentState.doorDirection;

            currRoomBlocks = new List<IBlock>(currentRoom.blocks);
            currRoomDoor = new List<IDoor>(currentRoom.doors);
            nextRoomBlocks = new List<IBlock>(nextRoom.blocks);
            nextRoomDoor = new List<IDoor>(nextRoom.doors);
            startPosition = nextRoomDoor[0].Position;

            Change = true;
            Link.Position = new Vector2(-1000, -1000);
            Game.dungeon.bombItem.Position = new Vector2(-1000, -1000);
            Game.dungeon.bowArrow.Position = new Vector2(-1000, -1000);
            Game.dungeon.bombItem.Position = new Vector2(-1000, -1000);
            Game.dungeon.movingSword.Position = new Vector2(-1000, -1000);
            Game.dungeon.bombExplosion.Position = new Vector2(-1000, -1000); 
            /*
             * I should be resetting the boomerang here as well, don't want
             * to do this last minute though. Works a little differently 
             * because it has to STOP swinging back to the player
             * and fully reset instead.
             */


            BeginOffset();
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (IEntity block in currRoomBlocks)
            {
                block.Draw(spriteBatch, Color.White);
            }
            foreach (IEntity door in currRoomDoor)
            {
                door.Draw(spriteBatch, Color.White);
            }
            foreach (IEntity block in nextRoomBlocks)
            {
                block.Draw(spriteBatch, Color.White);
            }
            foreach (IEntity door in nextRoomDoor)
            {
                door.Draw(spriteBatch, Color.White);
            }
            
            HudMenu.DungeonHud.Instance.Draw(spriteBatch, Color.White);
            HudMenu.InGameHud.Instance.Draw(spriteBatch, Color.White);
            HudMenu.InventoryHud.Instance.Draw(spriteBatch, Color.White);
            HudMenu.MiniMapHud.Instance.Draw(spriteBatch, Color.White);
            
        }

        public void Update(GameTime gameTime)
        {
            foreach (IEntity block in currRoomBlocks)
            {
                block.Update(gameTime);
            }
            foreach (IEntity door in currRoomDoor)
            {
                door.Update(gameTime);
            }
            foreach (IEntity block in nextRoomBlocks)
            {
                block.Update(gameTime);
            }
            foreach (IEntity door in nextRoomDoor)
            {
                door.Update(gameTime);
            }
            HudMenu.DungeonHud.Instance.Update(gameTime);
            HudMenu.InGameHud.Instance.Update(gameTime);
            HudMenu.InventoryHud.Instance.Update(gameTime);
            HudMenu.MiniMapHud.Instance.Update(gameTime);

            ChangeOffset();

            if (startPosition == nextRoomDoor[0].Position)
            {
                StopAnimation();
            }
        }


        public void BeginOffset()
        {
            Vector2 nextRoomOffset = new Vector2(0, 0);
            switch (doorDirection)
            {
                case DoorDirection.UP:
                    nextRoomOffset = new Vector2(0, (-ROOM_HEIGHT) * Global.Var.SCALE);
                    offsetTotal = -ROOM_HEIGHT * Global.Var.SCALE;
                    break;
                case DoorDirection.DOWN:
                    nextRoomOffset = new Vector2(0, (ROOM_HEIGHT) * Global.Var.SCALE);
                    offsetTotal = ROOM_HEIGHT * Global.Var.SCALE;
                    break;
                case DoorDirection.LEFT:
                    nextRoomOffset = new Vector2(-ROOM_WIDTH * Global.Var.SCALE, 0);
                    offsetTotal = -ROOM_WIDTH * Global.Var.SCALE;
                    break;
                case DoorDirection.RIGHT:
                    nextRoomOffset = new Vector2(ROOM_WIDTH * Global.Var.SCALE, 0);
                    offsetTotal = ROOM_WIDTH * Global.Var.SCALE;
                    break;
            }

            foreach (IEntity block in nextRoomBlocks)
            {
                block.Position = new Vector2(block.Position.X + nextRoomOffset.X, block.Position.Y + nextRoomOffset.Y);
            }
            foreach (IEntity door in nextRoomDoor)
            {
                door.Position = new Vector2(door.Position.X + nextRoomOffset.X, door.Position.Y + nextRoomOffset.Y);
            }
        }
        public void ChangeOffset()
        {
            int offsetX = 0;
            int offsetY = 0;
            switch (doorDirection)
            {
                case DoorDirection.UP:
                    offsetY = SHIFT_AMOUNT * Global.Var.SCALE;
                    break;
                case DoorDirection.DOWN:
                    offsetY = -SHIFT_AMOUNT * Global.Var.SCALE;
                    break;
                case DoorDirection.LEFT:
                    offsetX = SHIFT_AMOUNT * Global.Var.SCALE;
                    break;
                case DoorDirection.RIGHT:
                    offsetX = -SHIFT_AMOUNT * Global.Var.SCALE;
                    break;
            }

            foreach (IEntity block in currRoomBlocks)
            {
                block.Position = new Vector2(block.Position.X + offsetX, block.Position.Y + offsetY);
            }
            foreach (IEntity door in currRoomDoor)
            {
                door.Position = new Vector2(door.Position.X + offsetX, door.Position.Y + offsetY);
            }

            foreach (IEntity block in nextRoomBlocks)
            {
                block.Position = new Vector2(block.Position.X + offsetX, block.Position.Y + offsetY);
            }
            foreach (IEntity door in nextRoomDoor)
            {
                door.Position = new Vector2(door.Position.X + offsetX, door.Position.Y + offsetY);
            }
        }
        public void StopAnimation()
        {
            Vector2 currRoomOffset = new Vector2(0, 0);
            Game.dungeon.SetCurrentRoom(nextRoomID);
            switch (doorDirection)
            {
                case DoorDirection.UP:
                    currRoomOffset = new Vector2(0, (-ROOM_HEIGHT) * Global.Var.SCALE);
                    if (Game.dungeon.CurrentRoom.doors[1].CurrentState.IsBombable || Game.dungeon.CurrentRoom.doors[1].CurrentState.IsLocked)
                        Game.dungeon.CurrentRoom.doors[1].Open();
                    SetLinkPositionDown();
                    break;
                case DoorDirection.DOWN:
                    currRoomOffset = new Vector2(0, (ROOM_HEIGHT) * Global.Var.SCALE);
                    if (Game.dungeon.CurrentRoom.doors[0].CurrentState.IsBombable || Game.dungeon.CurrentRoom.doors[0].CurrentState.IsLocked)
                        Game.dungeon.CurrentRoom.doors[0].Open();
                    SetLinkPositionUp();
                    break;
                case DoorDirection.LEFT:
                    currRoomOffset = new Vector2(-ROOM_WIDTH * Global.Var.SCALE, 0);
                    if (Game.dungeon.CurrentRoom.doors[3].CurrentState.IsBombable || Game.dungeon.CurrentRoom.doors[3].CurrentState.IsLocked)
                        Game.dungeon.CurrentRoom.doors[3].Open();
                    SetLinkPositionRight();
                    break;
                case DoorDirection.RIGHT:
                    currRoomOffset = new Vector2(ROOM_WIDTH * Global.Var.SCALE, 0);
                    if (Game.dungeon.CurrentRoom.doors[2].CurrentState.IsBombable || Game.dungeon.CurrentRoom.doors[2].CurrentState.IsLocked)
                        Game.dungeon.CurrentRoom.doors[2].Open();
                    SetLinkPositionLeft();
                    break;
            }

            foreach (IEntity block in currRoomBlocks)
            {
                block.Position = new Vector2(block.Position.X + currRoomOffset.X, block.Position.Y + currRoomOffset.Y);
            }
            foreach (IEntity door in currRoomDoor)
            {
                door.Position = new Vector2(door.Position.X + currRoomOffset.X, door.Position.Y + currRoomOffset.Y);
            }

            Change = false;

            foreach (IDoor door in nextRoom.doors)
            {
                if (!door.roomEntered)
                {
                    door.roomEntered = true;
                    door.Close();
                }
            }
            HudMenu.DungeonHud.Instance.RoomChange(Game.dungeon);
            HudMenu.MiniMapHud.Instance.UpdateHudLinkLoc(nextRoom.RoomPos);
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
