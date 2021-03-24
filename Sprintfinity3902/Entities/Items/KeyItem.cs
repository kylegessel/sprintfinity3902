using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class KeyItem : AbstractItem
    {
        public KeyItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateKeyItem();
            Position = new Vector2(700, 600);
            ID = IItem.ITEMS.KEY;
        }

        public KeyItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateKeyItem();
            Position = pos;
            ID = IItem.ITEMS.KEY;
        }
    }
}
