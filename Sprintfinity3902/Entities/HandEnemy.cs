using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class HandEnemy : AbstractEntity {
        public HandEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateHandEnemy();
            Position = new Vector2(1200, 500);
        }

        public override void Move() {
            /*Move me*/
        }
    }
}
