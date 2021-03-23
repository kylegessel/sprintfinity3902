using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BowIcon : AbstractEntity
    {
        public BowIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateBowIcon();
            Position = pos;
        }
    }
}
