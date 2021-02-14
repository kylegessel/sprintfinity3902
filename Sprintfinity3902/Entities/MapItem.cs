using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class MapItem : AbstractEntity
    {
        public MapItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateMapItem();
            Position = new Vector2(600, 600);
        }
    }
}
