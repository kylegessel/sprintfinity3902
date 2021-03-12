using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class ClockItem : AbstractItem
    {
        public ClockItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateClockItem();
            Position = new Vector2(1100, 600);
            ID = IItem.ITEMS.CLOCK;
        }

        public ClockItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateClockItem();
            Position = pos;
            ID = IItem.ITEMS.CLOCK;
        }
    }
}
