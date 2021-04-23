using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Bomb5Item : AbstractItem
    {
        public Bomb5Item()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBomb5Item();
            Position = new Vector2(700, 600);
            ID = IItem.ITEMS.BOMB;
        }

        public Bomb5Item(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateBomb5Item();
            Position = pos;
            ID = IItem.ITEMS.BOMB;
        }

        public override IPickup GetPickup()
        {
            return new Bomb5Pickup();
        }
    }
}
