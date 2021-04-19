using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class FluteItem : AbstractItem
    {

        public FluteItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateFluteItem();
            Position = pos;
            ID = IItem.ITEMS.FLUTE;
        }

        public override IPickup GetPickup()
        {
            return new FlutePickup();
        }
    }
}
