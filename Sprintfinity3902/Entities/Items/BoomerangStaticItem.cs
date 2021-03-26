using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BoomerangStaticItem : AbstractItem
    {
        public BoomerangStaticItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBoomerangStaticItem();
            Position = new Vector2(700, 600);
            ID = IItem.ITEMS.BOOMERANG;
        }

        public BoomerangStaticItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateBoomerangStaticItem();
            Position = pos;
            ID = IItem.ITEMS.BOOMERANG;
        }

        public override IPickup GetPickup()
        {
            return new BoomerangPickup();
        }
    }
}
