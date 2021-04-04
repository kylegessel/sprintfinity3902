using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Face2Block : AbstractBlock
    {
        public Face2Block()
        {
            Sprite = BlockSpriteFactory.Instance.CreateFace2Block();
            Position = new Vector2(300, 700);
            STATIC = true;
        }
        public Face2Block(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateFace2Block();
            Position = pos;
            STATIC = true;
        }
    }
}
