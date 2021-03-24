using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class LetterX : AbstractEntity
    {
        public LetterX(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateLetterX();
            Position = pos;
        }
    }
}
