using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class SwordIcon : AbstractEntity
    {
        public SwordIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateSwordIcon();
            Position = pos;
        }
    }
}
