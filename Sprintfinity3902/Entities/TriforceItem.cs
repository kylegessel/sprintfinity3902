using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class TriforceItem : AbstractEntity
    {
        public TriforceItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateTriforceItem();
            Position = new Vector2(900, 600);
        }

        public TriforceItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateTriforceItem();
            Position = pos;
        }
    }
}
