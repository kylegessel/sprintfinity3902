using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Collision;

namespace Sprintfinity3902.Entities
{
    public class MovingSwordItem : AbstractItem, IProjectile
    {
        Player PlayerCharacter;
        Boolean itemUse;
        int itemUseCount;
        ISprite Sprite2;
        IPlayerState firingState;
        Direction swordDirection;

        public MovingSwordItem(Vector2 position)
        {
            Sprite = ItemSpriteFactory.Instance.CreateMovingSwordVerticalItem();
            Sprite2 = ItemSpriteFactory.Instance.CreateMovingSwordHorizontalItem();
            Position = position;
            itemUse = false;
            itemUseCount = 0;
            ID = IItem.ITEMS.SWORD;
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
            if (itemUseCount <= 60)
            {
                if (firingState == PlayerCharacter.facingDownAttack)
                {
                    Position = new Vector2(Position.X, Position.Y + 2 * Global.Var.SCALE);
                }
                else if (firingState == PlayerCharacter.facingUpAttack)
                {
                    Position = new Vector2(Position.X, Position.Y - 2 * Global.Var.SCALE);
                }
                else if (firingState == PlayerCharacter.facingLeftAttack)
                {
                    Position = new Vector2(Position.X - 2 * Global.Var.SCALE, Position.Y);
                }
                else if (firingState == PlayerCharacter.facingRightAttack)
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

            if (firingState == PlayerCharacter.facingDownAttack)
            {
                Position = new Vector2(PlayerCharacter.X + 5 * Global.Var.SCALE, PlayerCharacter.Y + 10 * Global.Var.SCALE);
                swordDirection = Direction.DOWN;
            }
            else if (firingState == PlayerCharacter.facingUpAttack)
            {
                Position = new Vector2(PlayerCharacter.X + 6 * Global.Var.SCALE, PlayerCharacter.Y - 10 * Global.Var.SCALE);
                swordDirection = Direction.UP;
            }
            else if (firingState == PlayerCharacter.facingLeftAttack)
            {
                Position = new Vector2(PlayerCharacter.X - 4 * Global.Var.SCALE, PlayerCharacter.Y + 5 * Global.Var.SCALE);
                swordDirection = Direction.LEFT;
            }
            else if (firingState == PlayerCharacter.facingRightAttack)
            {
                Position = new Vector2(PlayerCharacter.X + 10 * Global.Var.SCALE, PlayerCharacter.Y + 5 * Global.Var.SCALE);
                swordDirection = Direction.RIGHT;
            }
            itemUse = true;
        }

        public Boolean Collide(int enemyID, IEnemy enemy, IRoom room)
        {
            // Code for removing sword on contact, needs to be replaced.
            Position = new Vector2(-1000, -1000);
            CollisionDetector.decorateList.Add(enemyID);
            return enemy.HitRegister(enemyID, 1, 0, swordDirection, room) <= 0;
        }
    }
}
