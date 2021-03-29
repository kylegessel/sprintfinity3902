using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BowItem : AbstractItem
    {
        public BowItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBowItem();
            Position = new Vector2(1000, 600);
            ID = IItem.ITEMS.BOW;
        }

        public BowItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateBowItem();
            Position = pos;
            ID = IItem.ITEMS.BOW;
        }

        public override IPickup GetPickup()
        {
            return new BowPickup();
        }
    }
}
