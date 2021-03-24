using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BoomerangIcon : AbstractEntity
    {
        public BoomerangIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateBoomerangIcon();
            Position = pos;
        }
    }
}
