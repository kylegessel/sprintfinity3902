using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class GreenLinkLocationIcon : AbstractEntity
    {
        public GreenLinkLocationIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateGreenLinkLocationIcon();
            Position = pos;
        }
    }
}
