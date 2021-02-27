using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class BoomerangItem : AbstractEntity
    {

        Player PlayerCharacter;
        GoriyaEnemy Goriya;
        Boolean ItemUse;
        Boolean PlayerUse;
        Boolean GoriyaUse;
        int MoveUseCount;
        IPlayerState FiringStatePlayer;
        IGoriyaState FiringStateGoriya;
        IEntity Entity;
        float XDiff;
        float YDiff;
        float BoomerangOutChange;
        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        Direction FireDirection;
        public BoomerangItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBoomerangItem();
            Position = new Vector2(-1000, -1000);
            ItemUse = false;
            MoveUseCount = 1;
        }

        public Boolean getItemUse()
        {
            return ItemUse;
        }

        public void doneUsing()
        {
            GoriyaUse = false;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (ItemUse)
            {
                MoveItem();
            }
        }

        public void MoveItem()
        {
            // Calculate how far away the boomerang presently is.
            XDiff = Position.X - Entity.Position.X;
            YDiff = Position.Y - Entity.Position.Y;

            if (MoveUseCount <= 60)
            {
                // Calcuate how much we want the boomerang to change by, slowing down over time.
                BoomerangOutChange = (13 - (MoveUseCount / 6));
                if (FireDirection == Direction.Down)
                {
                    Position = new Vector2(Position.X, Position.Y + BoomerangOutChange);
                }
                else if (FireDirection == Direction.Up)
                {
                    Position = new Vector2(Position.X, Position.Y - BoomerangOutChange);
                }
                else if (FireDirection == Direction.Left)
                {
                    Position = new Vector2(Position.X - BoomerangOutChange, Position.Y);
                }
                else if (FireDirection == Direction.Right)
                {
                    Position = new Vector2(Position.X + BoomerangOutChange, Position.Y);
                }
                // When the boomerang returns, reset to initial position.
            }
            else if ((Math.Abs(Entity.Position.X - Position.X) <= 80) && (Math.Abs(Entity.Position.Y - Position.Y) <= 80))
            {
                ItemUse = false;
                MoveUseCount = 0;
                Position = new Vector2(-1000, -1000);
                if (PlayerUse)
                {
                    PlayerCharacter.UseItem();
                }
                else if (GoriyaUse)
                {
                    Goriya.UseItem();
                }
            }
            else
            {
                // Calculate the new position based on how many times the MoveItem function has been called.
                Position = new Vector2(Position.X - (XDiff / (120 - MoveUseCount)), Position.Y - (YDiff / (120 - MoveUseCount)));
            }

            MoveUseCount++;
        }

        public void UseItem(Player player)
        {
            PlayerCharacter = player;
            FiringStatePlayer = PlayerCharacter.CurrentState;
            Entity = PlayerCharacter;

            if (FiringStatePlayer == PlayerCharacter.facingDownItem)
            {
                Position = new Vector2(PlayerCharacter.X + 20, PlayerCharacter.Y + 80);
                FireDirection = Direction.Down;
            }
            else if (FiringStatePlayer == PlayerCharacter.facingUpItem)
            {
                Position = new Vector2(PlayerCharacter.X + 15, PlayerCharacter.Y - 50);
                FireDirection = Direction.Up;
            }
            else if (FiringStatePlayer == PlayerCharacter.facingLeftItem)
            {
                Position = new Vector2(PlayerCharacter.X - 50, PlayerCharacter.Y + 20);
                FireDirection = Direction.Left;
            }
            else if (FiringStatePlayer == PlayerCharacter.facingRightItem)
            {
                Position = new Vector2(PlayerCharacter.X + 66, PlayerCharacter.Y + 20);
                FireDirection = Direction.Right;
            }
            ItemUse = true;
            PlayerUse = true;
            GoriyaUse = false;
        }

        public void UseItem(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            FiringStateGoriya = Goriya.CurrentState;
            Entity = Goriya;

            if (FiringStateGoriya == Goriya.itemDown)
            {
                Position = new Vector2(Goriya.X + 20, Goriya.Y + 80);
                FireDirection = Direction.Down;
            }
            else if (FiringStateGoriya == Goriya.itemUp)
            {
                Position = new Vector2(Goriya.X + 15, Goriya.Y - 50);
                FireDirection = Direction.Up;
            }
            else if (FiringStateGoriya == Goriya.itemLeft)

            {
                Position = new Vector2(Goriya.X - 50, Goriya.Y + 20);
                FireDirection = Direction.Left;
            }
            else if (FiringStateGoriya == Goriya.itemRight)
            {
                Position = new Vector2(Goriya.X + 66, Goriya.Y + 20);
                FireDirection = Direction.Right;
            }
            ItemUse = true;
            PlayerUse = false;
            GoriyaUse = true;
        }
    }
}
