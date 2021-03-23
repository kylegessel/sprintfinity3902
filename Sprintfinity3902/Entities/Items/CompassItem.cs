using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class CompassItem : AbstractItem
    {
        public CompassItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateCompassItem();
            Position = new Vector2(500, 600);
            ID = IItem.ITEMS.COMPASS;
        }
        public CompassItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateCompassItem();
            Position = pos;
            ID = IItem.ITEMS.COMPASS;
        }
    }
}
