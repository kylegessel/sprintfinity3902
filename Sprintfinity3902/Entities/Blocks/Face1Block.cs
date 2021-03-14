using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Face1Block : AbstractBlock
    {
        public Face1Block()
        {
            Sprite = BlockSpriteFactory.Instance.CreateFace1Block();
            Position = new Vector2(300, 700);
        }
        public Face1Block(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateFace1Block();
            Position = pos;
        }
    }
}
