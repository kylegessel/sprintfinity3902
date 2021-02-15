using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class GoriyaEnemy : AbstractEntity {
        public GoriyaEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaDownEnemy();
            Position = new Vector2(700, 500);
        }

        public override void Move() {
            /*Move me*/
        }
    }
}
