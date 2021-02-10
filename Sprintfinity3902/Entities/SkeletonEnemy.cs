using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class SkeletonEnemy : AbstractEntity
    {
        public SkeletonEnemy(Vector2 startingPosition)
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = startingPosition;
        }
    }
}
