using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class WallTop: AbstractEntity
    {
        public WallTop()
        {
            Sprite = BlockSpriteFactory.Instance.CreateWallTop();
            Position = new Vector2(300, 700);
        }
        public WallTop(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateWallTop();
            Position = pos;
        }
    }
}