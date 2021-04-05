using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class YellowLinkBlock : AbstractEntity
    {
        public YellowLinkBlock(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateYellowLinkBlock();
            Position = pos;
        }
    }
}