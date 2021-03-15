using System;
using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class StairsBlock : AbstractBlock
    {
        public StairsBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateStairsBlock();
            Position = new Vector2(300, 700);
        }
        public StairsBlock(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateStairsBlock();
            Position = pos;
        }
        public override Boolean IsCollidable()
        {
            return false;
        }
    }
}