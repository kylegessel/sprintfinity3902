using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class HeartFullIcon : AbstractEntity
    {
        public HeartFullIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateHeartFullIcon();
            Position = pos;
        }
    }
}
