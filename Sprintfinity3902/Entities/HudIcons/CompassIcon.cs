using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class CompassIcon : AbstractEntity
    {
        public CompassIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateCompassIcon();
            Position = pos;
        }
    }
}
