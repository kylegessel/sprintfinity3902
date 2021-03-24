using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Number0 : AbstractEntity
    {
        public Number0(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateNumber0();
            Position = pos;
        }
    }
}
