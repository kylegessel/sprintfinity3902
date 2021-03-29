using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class ArrowItem : AbstractItem, IProjectile
    {
        Player PlayerCharacter;
        Boolean itemUse;
        int itemUseCount;
        ISprite Sprite2;
        IPlayerState firingState;
        Direction arrowDirection;
        Vector2 currentRect;

        public ArrowItem(Vector2 position)
        {
            Sprite = ItemSpriteFactory.Instance.CreateArrowVerticalItem();
            Sprite2 = ItemSpriteFactory.Instance.CreateArrowHorizontalItem();
            Position = position;
            itemUse = false;
            itemUseCount = 0;
            // TODO: Change when items fully implemented.
            ID = 0;
            currentRect = new Vector2(5 * Global.Var.SCALE, 16 * Global.Var.SCALE);
        }

        public Boolean getItemUse()
        {
            return itemUse;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (firingState != null)
            {
                if (arrowDirection == Direction.DOWN)
                {
                    spriteBatch.Draw(Sprite.Animation.CurrentFrame.Sprite.Texture, Position, Sprite.Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), Global.Var.SCALE, SpriteEffects.FlipVertically, 0.0f);
                }
                else if (arrowDirection == Direction.UP)
                {
                    Sprite.Draw(spriteBatch, Position, Color.White);
                }
                else if (arrowDirection == Direction.LEFT)
                {
                    spriteBatch.Draw(Sprite2.Animation.CurrentFrame.Sprite.Texture, Position, Sprite2.Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), Global.Var.SCALE, SpriteEffects.FlipHorizontally, 0.0f);
                }
                else if (arrowDirection == Direction.RIGHT)
                {
                    Sprite2.Draw(spriteBatch, Position, Color.White);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Sprite2.Update(gameTime);
            if (itemUse)
            {
                MoveItem();
            }
        }

        public void MoveItem()
        {
            if (itemUseCount <= 60)
            {
                if (arrowDirection == Direction.DOWN)
                {
                    Position = new Vector2(Position.X, Position.Y + 2 * Global.Var.SCALE);
                }
                else if (arrowDirection == Direction.UP)
                {
                    Position = new Vector2(Position.X, Position.Y - 2 * Global.Var.SCALE);
                }
                else if (arrowDirection == Direction.LEFT)
                {
                    Position = new Vector2(Position.X - 2 * Global.Var.SCALE, Position.Y);
                }
                else if (arrowDirection == Direction.RIGHT)
                {
                    Position = new Vector2(Position.X + 2 * Global.Var.SCALE, Position.Y);
                }
            }
            else
            {
                itemUse = false;
                itemUseCount = 0;
                Position = new Vector2(-1000, -1000);
            }

            itemUseCount++;
        }
        public void UseItem(Player player)
        {
            PlayerCharacter = player;
            firingState = PlayerCharacter.CurrentState;
            if (firingState == PlayerCharacter.facingDownItem)
            {
                Position = new Vector2(PlayerCharacter.X + 5 * Global.Var.SCALE, PlayerCharacter.Y + 10 * Global.Var.SCALE);
                arrowDirection = Direction.DOWN;
                currentRect = new Vector2(5 * Global.Var.SCALE, 16 * Global.Var.SCALE);
            }
            else if (firingState == PlayerCharacter.facingUpItem)
            {
                Position = new Vector2(PlayerCharacter.X + 6 * Global.Var.SCALE, PlayerCharacter.Y - 10 * Global.Var.SCALE);
                arrowDirection = Direction.UP;
                currentRect = new Vector2(5 * Global.Var.SCALE, 16 * Global.Var.SCALE);
            }
            else if (firingState == PlayerCharacter.facingLeftItem)
            {
                Position = new Vector2(PlayerCharacter.X - 4 * Global.Var.SCALE, PlayerCharacter.Y + 5 * Global.Var.SCALE);
                arrowDirection = Direction.LEFT;
                currentRect = new Vector2(16 * Global.Var.SCALE, 5 * Global.Var.SCALE);
            }
            else if (firingState == PlayerCharacter.facingRightItem)
            {
                Position = new Vector2(PlayerCharacter.X + 10 * Global.Var.SCALE, PlayerCharacter.Y + 5 * Global.Var.SCALE);
                arrowDirection = Direction.RIGHT;
                currentRect = new Vector2(16 * Global.Var.SCALE, 5 * Global.Var.SCALE);
            }
            itemUse = true;
        }

        public Boolean Collide(int enemyID, IEnemy enemy, IRoom room)
        {
            Position = new Vector2(-1000, -1000);
            return enemy.HitRegister(enemyID, 1, 0, arrowDirection, room) <= 0;
        }

        public void Collide(IRoom room)
        {
            Position = new Vector2(-1000, -1000);
        }

        public override Rectangle GetBoundingRect()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)currentRect.X, (int)currentRect.Y);
        }
    }
}
