using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class FloorBlock : AbstractEntity
    {
        public FloorBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateFloorBlock();
            Position = new Vector2(300, 700);
        }

        public FloorBlock(Vector2 position)
        {
            Sprite = BlockSpriteFactory.Instance.CreateFloorBlock();
            Position = position;
        }
    }
}
