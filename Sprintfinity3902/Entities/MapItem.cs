using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class MapItem : AbstractEntity
    {
        public MapItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateMapItem();
            Position = new Vector2(600, 600);
        }

        public MapItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateMapItem();
            Position = pos;
        }
    }
}
