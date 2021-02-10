using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class GelEnemy : AbstractEntity
    {
        public GelEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateGelEnemy();
            Position = new Vector2(600, 500);
        }
    }
}
