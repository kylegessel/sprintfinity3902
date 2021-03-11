using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class SwordHitboxItem : AbstractEntity
    {
        Player PlayerCharacter;
        Boolean itemUse;
        int itemUseCount;
        IPlayerState firingState;
        Vector2 currentRect;

        public SwordHitboxItem(Vector2 position)
        {
            Position = position;
            currentRect = new Vector2(7, 12);
            itemUse = false;
            itemUseCount = 0;
        }

        public Boolean getItemUse()
        {
            return itemUse;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {


            /*
            
            
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
            */
        }

        public override void Update(GameTime gameTime)
        {
            //Sprite.Update(gameTime);
            //Sprite2.Update(gameTime);
            if (itemUse)
            {
                MoveItem();
            }
        }

        public void MoveItem()
        {
            if (itemUseCount <= 5) //this time amount needs to be tweaked.
            {


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
                Position = new Vector2(PlayerCharacter.X + 5 * Global.Var.SCALE, PlayerCharacter.Y + 16 * Global.Var.SCALE);
                //currentRect = new Vector2(7, 12);

            }
            else if (firingState == PlayerCharacter.facingUpAttack)
            {
                Position = new Vector2(PlayerCharacter.X + 6 * Global.Var.SCALE, PlayerCharacter.Y - 12 * Global.Var.SCALE);
                //currentRect = new Vector2(7, 12);
            }
            else if (firingState == PlayerCharacter.facingLeftAttack)
            {
                Position = new Vector2(PlayerCharacter.X - 12 * Global.Var.SCALE, PlayerCharacter.Y + 5 * Global.Var.SCALE);
                //currentRect = new Vector2(12, 7);
            }
            else if (firingState == PlayerCharacter.facingRightAttack)
            {
                Position = new Vector2(PlayerCharacter.X + 16 * Global.Var.SCALE, PlayerCharacter.Y + 5 * Global.Var.SCALE);
                //currentRect = new Vector2(12, 7);
            }
            itemUse = true;
        }

        //public override Rectangle GetBoundingRect()
        //{

        //   return new Rectangle((int)Position.X, (int)Position.Y, (int)currentRect.X, (int)currentRect.Y);
        //}

    }
}
