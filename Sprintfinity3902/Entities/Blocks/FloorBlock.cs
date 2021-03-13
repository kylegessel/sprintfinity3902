using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class FloorBlock : AbstractBlock
    {
        public FloorBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateFloorBlock();
            Position = new Vector2(300, 700);
        }

        public FloorBlock(Vector2 position)
        {
            Sprite = BlockSpriteFactory.Instance.CreateFloorBlock();
            Position = position;
        }
        public override Boolean IsCollidable()
        {
            return false;
        }
    }
}
