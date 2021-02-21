using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class FairyItem : AbstractEntity
    {
        public FairyItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateFairyItem();
            Position = new Vector2(400, 600);
        }

        public FairyItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateFairyItem();
            Position = pos;
        }
    }
}
