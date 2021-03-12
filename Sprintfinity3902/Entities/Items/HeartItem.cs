using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class HeartItem : AbstractItem
    {
        public HeartItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateHeartItem();
            Position = new Vector2(300, 600);
            ID = IItem.ITEMS.HEART;
        }

        public HeartItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateHeartItem();
            Position = pos;
            ID = IItem.ITEMS.HEART;
        }
    }
}
