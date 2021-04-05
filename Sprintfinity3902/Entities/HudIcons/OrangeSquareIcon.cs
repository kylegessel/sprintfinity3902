using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class OrangeSquareIcon : AbstractEntity
    {
        public OrangeSquareIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateOrangeSquareIcon();
            Position = pos;
        }
    }
}
