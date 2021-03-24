using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BlackSquareIcon : AbstractEntity
    {
        public BlackSquareIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateBlackSquareIcon();
            Position = pos;
        }
    }
}
