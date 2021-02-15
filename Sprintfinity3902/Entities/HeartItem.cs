using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class HeartItem : AbstractEntity
    {
        public HeartItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateHeartItem();
            Position = new Vector2(300, 600);
        }
    }
}
