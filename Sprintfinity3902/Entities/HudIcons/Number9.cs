using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Number9 : AbstractEntity
    {
        public Number9(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateNumber9();
            Position = pos;
        }
    }
}
