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
        public BombItem(Vector2 position)
        {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Position = position;
        }

        public override void Move() {
            /*Move me*/
        }
        public void UseItem(Player player)
        {
            PlayerCharacter = player;
            //TODO: Fix math to center the bomb
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
