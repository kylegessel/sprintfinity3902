using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class MapIcon : AbstractEntity
    {
        public MapIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateMapIcon();
            Position = pos;
        }
    }
}
