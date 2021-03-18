using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class InventoryHudEntity : AbstractEntity
    {
        public InventoryHudEntity(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateInventoryHud();
            Position = pos;
        }
    }
}
