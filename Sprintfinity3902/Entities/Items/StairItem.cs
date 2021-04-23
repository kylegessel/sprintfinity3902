using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class StairItem : AbstractItem
    {
        public StairItem()
        {
            Sprite = BlockSpriteFactory.Instance.CreateStairsBlock();
            Position = new Vector2(1000, 600);
        }

        public StairItem(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateStairsBlock();
            Position = pos;
        }

        public override IPickup GetPickup()
        {
            return new TriforcePickup();
        }
    }
}
