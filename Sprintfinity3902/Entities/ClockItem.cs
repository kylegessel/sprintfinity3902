using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class ClockItem : AbstractEntity
    {
        public ClockItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateClockItem();
            Position = new Vector2(1100, 600);
        }
    }
}
