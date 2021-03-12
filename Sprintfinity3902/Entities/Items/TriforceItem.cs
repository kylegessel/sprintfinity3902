using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class TriforceItem : AbstractItem
    {
        public TriforceItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateTriforceItem();
            Position = new Vector2(900, 600);
            ID = IItem.ITEMS.TRIFORCE;
        }

        public TriforceItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateTriforceItem();
            Position = pos;
            ID = IItem.ITEMS.TRIFORCE;
        }
    }
}
