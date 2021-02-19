using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BrickBlock : AbstractEntity
    {
        public BrickBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateBrickBlock();
            Position = new Vector2(300, 700);
        }
    }
}