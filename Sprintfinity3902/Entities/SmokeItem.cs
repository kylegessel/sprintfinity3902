using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class SmokeItem : AbstractEntity
    {
        public SmokeItem(Vector2 position)
        {
            Sprite = ItemSpriteFactory.Instance.CreateSmokeItem();
            Position = position;
        }
    }
}
