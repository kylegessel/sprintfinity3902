using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BlueRupeeItem : AbstractItem
    {
        public BlueRupeeItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBlueRupeeItem();
            Position = new Vector2(200, 600);
            ID = IItem.ITEMS.RUPEE;
        }

        public BlueRupeeItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateBlueRupeeItem();
            Position = pos;
            ID = IItem.ITEMS.RUPEE;
        }

        public override IPickup GetPickup()
        {
            return new BlueRupeePickup();
        }
    }
}
