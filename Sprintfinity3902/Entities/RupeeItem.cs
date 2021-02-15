using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class RupeeItem : AbstractEntity
    {
        public RupeeItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateRupeeItem();
            Position = new Vector2(200, 600);
        }
    }
}
