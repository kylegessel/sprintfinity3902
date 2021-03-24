using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Number8 : AbstractEntity
    {
        public Number8(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateNumber8();
            Position = pos;
        }
    }
}

