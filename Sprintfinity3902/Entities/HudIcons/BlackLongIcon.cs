using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BlackLongIcon : AbstractEntity
    {
        public BlackLongIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateBlackLongIcon();
            Position = pos;
        }
    }
}
