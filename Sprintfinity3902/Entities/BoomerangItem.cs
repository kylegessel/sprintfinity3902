using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using Sprintfinity3902.SpriteFactories;

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
            Position = new Vector2(-1000, -1000);
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
                if (firingState == PlayerCharacter.facingDownItem)
                {
                    Position = new Vector2(Position.X, Position.Y + 10);
                }
                else if (firingState == PlayerCharacter.facingUpItem)
                {
                    Position = new Vector2(Position.X, Position.Y - 10);
                }
                else if (firingState == PlayerCharacter.facingLeftItem)
                {
                    Position = new Vector2(Position.X - 10, Position.Y);
                }
                else if (firingState == PlayerCharacter.facingRightItem)
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
                if (firingState == PlayerCharacter.facingDownItem)
                {
                    Position = new Vector2(Position.X, Position.Y - 10);
                }
                else if (firingState == PlayerCharacter.facingUpItem)
                {
                    Position = new Vector2(Position.X, Position.Y + 10);
                }
                else if (firingState == PlayerCharacter.facingLeftItem)
                {
                    Position = new Vector2(Position.X + 10, Position.Y);
                }
                else if (firingState == PlayerCharacter.facingRightItem)
                {
                    Position = new Vector2(Position.X - 10, Position.Y);
                }
            }

            itemUseCount++;
        }

        public void UseItem(Player player)
        {
            PlayerCharacter = player;
            firingState = PlayerCharacter.CurrentState;

                if (firingState == PlayerCharacter.facingDownItem)
                {
                    Position = new Vector2(PlayerCharacter.X + 20, PlayerCharacter.Y + 80);
                }
                else if (firingState == PlayerCharacter.facingUpItem)
                {
                    Position = new Vector2(PlayerCharacter.X + 15, PlayerCharacter.Y - 50);
                }
                else if (firingState == PlayerCharacter.facingLeftItem)
                {
                    Position = new Vector2(PlayerCharacter.X - 50, PlayerCharacter.Y + 20);
                }
                else if (firingState == PlayerCharacter.facingRightItem)
                {
                    Position = new Vector2(PlayerCharacter.X + 66, PlayerCharacter.Y + 20);
                }
            itemUse = true;
        }
    }
}
