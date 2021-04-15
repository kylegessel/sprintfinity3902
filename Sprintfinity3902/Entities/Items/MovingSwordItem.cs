using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class MovingSwordItem : AbstractItem, IProjectile
    {

        private static int ONE_THOUSAND = 1000;
        private static int SEVEN = 7;
        private static int FIVE = 5;
        private static int FOUR = 4;
        private static int TEN = 10;
        private static int SIX = 6;
        private static int TWO = 2;
        private static int SIXTY = 60;

        IPlayer PlayerCharacter;
        Boolean itemUse;
        int itemUseCount;
        ISprite Sprite2;
        IPlayerState firingState;
        Direction swordDirection;
        Vector2 currentRect;
        

        public MovingSwordItem(Vector2 position)
        {
            Sprite = ItemSpriteFactory.Instance.CreateMovingSwordVerticalItem();
            Sprite2 = ItemSpriteFactory.Instance.CreateMovingSwordHorizontalItem();
            Position = position;
            itemUse = false;
            itemUseCount = 0;
            ID = IItem.ITEMS.SWORD;
            currentRect = new Vector2(SEVEN * Global.Var.SCALE, Global.Var.TILE_SIZE * Global.Var.SCALE);
        }

        public Boolean getItemUse()
        {
            return itemUse;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (firingState != null)
            {
                if (firingState == PlayerCharacter.facingDownAttack)
                {
                    spriteBatch.Draw(Sprite.Animation.CurrentFrame.Sprite.Texture, Position, Sprite.Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), Global.Var.SCALE, SpriteEffects.FlipVertically, 0.0f);
                }
                else if (firingState == PlayerCharacter.facingUpAttack)
                {
                    Sprite.Draw(spriteBatch, Position, Color.White);
                }
                else if (firingState == PlayerCharacter.facingLeftAttack)
                {
                    spriteBatch.Draw(Sprite2.Animation.CurrentFrame.Sprite.Texture, Position, Sprite2.Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), Global.Var.SCALE, SpriteEffects.FlipHorizontally, 0.0f);
                }
                else if (firingState == PlayerCharacter.facingRightAttack)
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
            if (itemUseCount <= SIXTY)
            {
                if (firingState == PlayerCharacter.facingDownAttack)
                {
                    Position = new Vector2(Position.X, Position.Y + TWO * Global.Var.SCALE);
                }
                else if (firingState == PlayerCharacter.facingUpAttack)
                {
                    Position = new Vector2(Position.X, Position.Y - TWO * Global.Var.SCALE);
                }
                else if (firingState == PlayerCharacter.facingLeftAttack)
                {
                    Position = new Vector2(Position.X - TWO * Global.Var.SCALE, Position.Y);
                }
                else if (firingState == PlayerCharacter.facingRightAttack)
                {
                    Position = new Vector2(Position.X + TWO * Global.Var.SCALE, Position.Y);
                }
            }
            else
            {
                itemUse = false;
                itemUseCount = 0;
                Position = new Vector2(-ONE_THOUSAND, -ONE_THOUSAND);
            }

            itemUseCount++;
        }
        public void UseItem(ILink player)
        {
            PlayerCharacter = (IPlayer)player;
            firingState = PlayerCharacter.CurrentState;

            if (firingState == PlayerCharacter.facingDownAttack)
            {
                Position = new Vector2(PlayerCharacter.X + FIVE * Global.Var.SCALE, PlayerCharacter.Y + TEN * Global.Var.SCALE);
                swordDirection = Direction.DOWN;
                currentRect = new Vector2(SEVEN * Global.Var.SCALE, Global.Var.TILE_SIZE * Global.Var.SCALE);
            }
            else if (firingState == PlayerCharacter.facingUpAttack)
            {
                Position = new Vector2(PlayerCharacter.X + SIX * Global.Var.SCALE, PlayerCharacter.Y - TEN * Global.Var.SCALE);
                swordDirection = Direction.UP;
                currentRect = new Vector2(SEVEN * Global.Var.SCALE, Global.Var.TILE_SIZE * Global.Var.SCALE);
            }
            else if (firingState == PlayerCharacter.facingLeftAttack)
            {
                Position = new Vector2(PlayerCharacter.X - FOUR * Global.Var.SCALE, PlayerCharacter.Y + FIVE * Global.Var.SCALE);
                swordDirection = Direction.LEFT;
                currentRect = new Vector2(Global.Var.TILE_SIZE * Global.Var.SCALE, SEVEN * Global.Var.SCALE);
            }
            else if (firingState == PlayerCharacter.facingRightAttack)
            {
                Position = new Vector2(PlayerCharacter.X + TEN * Global.Var.SCALE, PlayerCharacter.Y + FIVE * Global.Var.SCALE);
                swordDirection = Direction.RIGHT;
                currentRect = new Vector2(Global.Var.TILE_SIZE * Global.Var.SCALE, SEVEN * Global.Var.SCALE);
            }
            itemUse = true;
        }

        public Boolean Collide(int enemyID, IEnemy enemy, IRoom room)
        {
            // Code for removing sword on contact, needs to be replaced.
            room.garbage.Add(new MovingSwordSplitItem(Position));
            Position = new Vector2(-ONE_THOUSAND, -ONE_THOUSAND);
            return enemy.HitRegister(enemyID, 1, 0, this, swordDirection, room) <= 0;
        }

        public void Collide(IRoom room)
        {
            room.garbage.Add(new MovingSwordSplitItem(Position));
            Position = new Vector2(-ONE_THOUSAND, -ONE_THOUSAND);
        }

        public override Rectangle GetBoundingRect()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)currentRect.X, (int)currentRect.Y);
        }
    }
}
