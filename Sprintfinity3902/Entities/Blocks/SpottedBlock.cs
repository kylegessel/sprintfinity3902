using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class SpottedBlock : AbstractBlock
    {
        public SpottedBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateSpottedBlock();
            Position = new Vector2(300, 700);
        }
        public SpottedBlock(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateSpottedBlock();
            Position = pos;
        }

        public override Boolean IsCollidable()
        {
            return false;
        }
    }
}