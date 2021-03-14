using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class StripeBlock : AbstractBlock
    {
        public StripeBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateStripeBlock();
            Position = new Vector2(300, 700);
        }
        public StripeBlock(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateStripeBlock();
            Position = pos;
        }
    }
}