using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BowItem : AbstractEntity
    {
        public BowItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBowItem();
            Position = new Vector2(1000, 600);
        }
    }
}
