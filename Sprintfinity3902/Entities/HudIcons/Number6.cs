using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Number6 : AbstractEntity
    {
        public Number6(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateNumber6();
            Position = pos;
        }
    }
}
