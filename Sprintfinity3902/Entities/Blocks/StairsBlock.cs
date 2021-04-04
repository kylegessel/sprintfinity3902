using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class StairsBlock : AbstractBlock
    {
        public StairsBlock(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateStairsBlock();
            Position = pos;
            Collidable = false;
            STATIC = true;
        }
    }
}