using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BombStaticItem : AbstractItem
    {
        public BombStaticItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Position = new Vector2(700, 600);
            ID = IItem.ITEMS.BOMB;
        }

        public BombStaticItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Position = pos;
            ID = IItem.ITEMS.BOMB;
        }

        public override IPickup GetPickup()
        {
            return new BombPickup();
        }
    }
}
