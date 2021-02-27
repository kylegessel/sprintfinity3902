using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class WallBottom : AbstractEntity
    {
        public WallBottom()
        {
            Sprite = BlockSpriteFactory.Instance.CreateWallBottom();
            Position = new Vector2(300, 700);
        }
        public WallBottom(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateWallBottom();
            Position = pos;
        }
    }
}