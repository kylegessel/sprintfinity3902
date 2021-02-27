using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class WallRight : AbstractEntity
    {
        public WallRight()
        {
            Sprite = BlockSpriteFactory.Instance.CreateWallRight();
            Position = new Vector2(300, 700);
        }
        public WallRight(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateWallRight();
            Position = pos;
        }
    }
}