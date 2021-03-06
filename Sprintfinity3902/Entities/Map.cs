using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class Map : AbstractEntity
    {
        public Map(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateMapSprite();
            Position = pos;
        }
    }
}
