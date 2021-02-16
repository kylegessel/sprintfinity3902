using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class MovingSwordItem : AbstractEntity
    {
        Player PlayerCharacter;
        Boolean itemUse;
        int itemUseCount;
        ISprite Sprite2;
        IPlayerState firingState;

        public MovingSwordItem(Vector2 position)
        {
            Sprite = ItemSpriteFactory.Instance.CreateMovingSwordVerticalItem();
            Sprite2 = ItemSpriteFactory.Instance.CreateMovingSwordHorizontalItem();
            Position = position;
            itemUse = false;
            itemUseCount = 0;
        }

        public Boolean getItemUse()
        {
            return itemUse;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (firingState != null)
            {
                if (firingState == PlayerCharacter.facingDownAttack)
                {
                    spriteBatch.Draw(Sprite.Animation.CurrentFrame.Sprite.Texture, Position, Sprite.Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 5.0f, SpriteEffects.FlipVertically, 0.0f);
                }
                else if (firingState == PlayerCharacter.facingUpAttack)
                {
                    Sprite.Draw(spriteBatch, Position, Color.White);
                }
                else if (firingState == PlayerCharacter.facingLeftAttack)
                {
                    spriteBatch.Draw(Sprite2.Animation.CurrentFrame.Sprite.Texture, Position, Sprite2.Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 5.0f, SpriteEffects.FlipHorizontally, 0.0f);
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
                    Position = new Vector2(Position.X, Position.Y + 10);
                }
                else if (firingState == PlayerCharacter.facingUpAttack)
                {
                    Position = new Vector2(Position.X, Position.Y - 10);
                }
                else if (firingState == PlayerCharacter.facingLeftAttack)
                {
                    Position = new Vector2(Position.X - 10, Position.Y);
                }
                else if (firingState == PlayerCharacter.facingRightAttack)
                {
                    Position = new Vector2(Position.X + 10, Position.Y);
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
                Position = new Vector2(PlayerCharacter.X + 25, PlayerCharacter.Y + 50);
            }
            else if (firingState == PlayerCharacter.facingUpAttack)
            {
                Position = new Vector2(PlayerCharacter.X + 30, PlayerCharacter.Y - 50);
            }
            else if (firingState == PlayerCharacter.facingLeftAttack)
            {
                Position = new Vector2(PlayerCharacter.X - 20, PlayerCharacter.Y + 25);
            }
            else if (firingState == PlayerCharacter.facingRightAttack)
            {
                Position = new Vector2(PlayerCharacter.X + 50, PlayerCharacter.Y + 25);
            }
            itemUse = true;
        }
    }
}
