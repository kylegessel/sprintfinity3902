using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class BombItem : AbstractEntity
    {
        public BombItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Position = new Vector2(500, 500);
        }
    }
}
