using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class HeartEmptyIcon : AbstractEntity
    {
        public HeartEmptyIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateHeartEmptyIcon();
            Position = pos;
        }
    }
}