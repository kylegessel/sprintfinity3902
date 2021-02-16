using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class HeartItem : AbstractEntity
    {
        public HeartItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateHeartItem();
            Position = new Vector2(300, 600);
        }

        public HeartItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateHeartItem();
            Position = pos;
        }
    }
}
