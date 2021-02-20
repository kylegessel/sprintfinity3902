using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class RupeeItem : AbstractEntity
    {
        public RupeeItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateRupeeItem();
            Position = new Vector2(200, 600);
        }

        public RupeeItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateRupeeItem();
            Position = pos;
        }
    }
}
