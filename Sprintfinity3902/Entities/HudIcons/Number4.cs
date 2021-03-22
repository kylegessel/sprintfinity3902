using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class Number4 : AbstractEntity
    {
        public Number4(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateNumber4();
            Position = pos;
        }
    }
}
