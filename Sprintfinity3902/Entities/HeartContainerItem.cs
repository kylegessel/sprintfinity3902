using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class HeartContainerItem : AbstractEntity
    {
        public HeartContainerItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateHeartContainerItem();
            Position = new Vector2(400, 600);
        }
    }
}
