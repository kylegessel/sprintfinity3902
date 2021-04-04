using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class FloorBlock : AbstractBlock
    {

        public FloorBlock(Vector2 position)
        {
            Sprite = BlockSpriteFactory.Instance.CreateFloorBlock();
            Position = position;
            Collidable = false;
        }
    }
}
