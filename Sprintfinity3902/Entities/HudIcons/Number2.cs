using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Number2 : AbstractEntity
    {
        public Number2(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateNumber2();
            Position = pos;
        }
    }
}
