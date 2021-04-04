using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class SpottedBlock : AbstractBlock
    {
        public SpottedBlock(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateSpottedBlock();
            Position = pos;
            Collidable = false;
            STATIC = true;
        }
    }
}