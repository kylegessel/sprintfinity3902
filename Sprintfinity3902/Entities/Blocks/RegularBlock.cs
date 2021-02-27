using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class RegularBlock :AbstractEntity
    {
        public RegularBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateRegularBlock();
            Position = new Vector2(300, 700);
        }

        public RegularBlock(Vector2 position)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRegularBlock();
            Position = position;
        }
    }
}
