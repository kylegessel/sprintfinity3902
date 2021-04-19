using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class FluteIcon : AbstractEntity
    {
        public FluteIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateFluteIcon();
            Position = pos;
        }
    }
}