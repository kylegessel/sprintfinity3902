using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class Number7 : AbstractEntity
    {
        public Number7(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateNumber7();
            Position = pos;
        }
    }
}
