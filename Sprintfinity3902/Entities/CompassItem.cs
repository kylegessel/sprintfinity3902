using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class CompassItem : AbstractEntity
    {
        public CompassItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateCompassItem();
            Position = new Vector2(500, 600);
        }
    }
}
