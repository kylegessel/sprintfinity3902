using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class GohmaBoss : AbstractEntity
    {
        public GohmaBoss(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateGohmaClosedEye();
            Position = pos;
        }
    }
}
