using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class BoomerangItem : AbstractEntity
    {

        Player PlayerCharacter;
        Boolean itemUse;
        int itemUseCount;
        IPlayerState firingState;
        public BoomerangItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBoomerangItem();
            Position = new Vector2(500, 400);
            itemUse = false;
            itemUseCount = 0;
        }

        public Boolean getItemUse()
        {
            return itemUse;
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
            else if (itemUseCount == 120)
            {
                itemUse = false;
                itemUseCount = 0;
                Position = new Vector2(-1000, -1000);
            }
            else
            {
                // TODO: Implement return to player function
                Position = new Vector2(Position.X - 10, Position.Y);

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
