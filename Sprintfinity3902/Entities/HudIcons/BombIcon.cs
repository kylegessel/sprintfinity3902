using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BombIcon : AbstractEntity
    {
        public BombIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateBombIcon();
            Position = pos;
        }
    }
}
