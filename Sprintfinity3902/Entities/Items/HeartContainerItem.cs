using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class HeartContainerItem : AbstractItem
    {
        public HeartContainerItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateHeartContainerItem();
            Position = new Vector2(400, 600);
            ID = IItem.ITEMS.HEART;
        }

        public HeartContainerItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateHeartContainerItem();
            Position = pos;
            ID = IItem.ITEMS.HEART;
        }

        public override IPickup GetPickup()
        {
            return new HeartContainerPickup();
        }
    }
}
