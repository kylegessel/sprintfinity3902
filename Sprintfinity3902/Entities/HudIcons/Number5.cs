using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Number5 : AbstractEntity
    {
        public Number5(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateNumber5();
            Position = pos;
        }
    }
}
