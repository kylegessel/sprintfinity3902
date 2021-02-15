using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class BombItem : AbstractEntity {

        Player PlayerCharacter;
        Boolean itemUse;
        int itemUseCount;
        SmokeItem Smoke;
        public BombItem(Vector2 position, SmokeItem smoke)
        {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Position = position;
            // Figure out a better implementation of the smoke to get all 5 displaying.
            Smoke = smoke;
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
                ExplodeBomb();
            }
        }

        public void ExplodeBomb()
        {
            if(itemUseCount == 60)
            {
                Smoke.Position = new Vector2(Position.X - 8, Position.Y - 2);
                Position = new Vector2(-1000, -1000);
            }
            else if(itemUseCount > 120)
            {
                Smoke.Sprite.Animation.Play();
                itemUse = false;
                itemUseCount = 0;
                Smoke.Position = new Vector2(-1000, -1000);
            }
            itemUseCount++;
        }

        public void UseItem(Player player)
        {
            PlayerCharacter = player;
            itemUse = true;
            
            if (PlayerCharacter.CurrentState == PlayerCharacter.facingDown)
            {
                Position = new Vector2(player.X, player.Y + 50);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingUp)
            {
                Position = new Vector2(player.X, player.Y - 50);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingLeft)
            {
                Position = new Vector2(player.X - 50, player.Y);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingRight)
            {
                Position = new Vector2(player.X + 66, player.Y);
            }
        }
    }
}
