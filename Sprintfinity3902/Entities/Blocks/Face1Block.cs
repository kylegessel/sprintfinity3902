using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Face1Block : AbstractEntity
    {
        public Face1Block()
        {
            Sprite = BlockSpriteFactory.Instance.CreateFace1Block();
            Position = new Vector2(300, 700);
        }
    }
}
