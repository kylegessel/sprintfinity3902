using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Number3 : AbstractEntity
    {
        public Number3(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateNumber3();
            Position = pos;
        }
    }
}
