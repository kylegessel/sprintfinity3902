using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class StripeBlock : AbstractEntity
    {
        public StripeBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateStripeBlock();
            Position = new Vector2(300, 700);
        }
    }
}