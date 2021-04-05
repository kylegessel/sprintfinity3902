using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class WinLocationIcon : AbstractEntity
    {
        public WinLocationIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateWinLocationIcon();
            Position = pos;
        }
    }
}
