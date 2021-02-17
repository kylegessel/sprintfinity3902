using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Face2Block : AbstractEntity
    {
        public Face2Block()
        {
            Sprite = BlockSpriteFactory.Instance.CreateFace2Block();
            Position = new Vector2(500, 700);
        }
    }
}
