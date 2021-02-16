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
        IState firingState;

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
            if (firingState == PlayerCharacter.facingDown)
            {
                spriteBatch.Draw(Sprite.Animation.CurrentFrame.Sprite.Texture, Position, Sprite.Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 5.0f, SpriteEffects.FlipVertically, 0.0f);
            }
            else if (firingState == PlayerCharacter.facingUp)
            {
                Sprite.Draw(spriteBatch, Position, Color.White);
            }
            else if (firingState == PlayerCharacter.facingLeft)
            {
                spriteBatch.Draw(Sprite.Animation.CurrentFrame.Sprite.Texture, Position, Sprite.Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 5.0f, SpriteEffects.FlipHorizontally, 0.0f);
            }
            else if (firingState == PlayerCharacter.facingRight)
            {
                Sprite2.Draw(spriteBatch, Position, Color.White);
            }
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (itemUse)
            {
                MoveItem();
            }
        }

        public void MoveItem()
        {
            if (itemUseCount <= 60)
            {
                if (firingState == PlayerCharacter.facingDown)
                {
                    Position = new Vector2(Position.X, Position.Y + 10);
                }
                else if (firingState == PlayerCharacter.facingUp)
                {
                    Position = new Vector2(Position.X, Position.Y - 10);
                }
                else if (firingState == PlayerCharacter.facingLeft)
                {
                    Position = new Vector2(Position.X - 10, Position.Y);
                }
                else if (firingState == PlayerCharacter.facingRight)
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

            if (firingState == PlayerCharacter.facingDown)
            {
                Position = new Vector2(PlayerCharacter.X, PlayerCharacter.Y + 50);
            }
            else if (firingState == PlayerCharacter.facingUp)
            {
                Position = new Vector2(PlayerCharacter.X, PlayerCharacter.Y - 50);
            }
            else if (firingState == PlayerCharacter.facingLeft)
            {
                Position = new Vector2(PlayerCharacter.X - 50, PlayerCharacter.Y);
            }
            else if (firingState == PlayerCharacter.facingRight)
            {
                Position = new Vector2(PlayerCharacter.X + 66, PlayerCharacter.Y);
            }
            itemUse = true;
        }
    }
}
