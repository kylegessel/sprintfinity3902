using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class WallLeft : AbstractEntity
    {
        public WallLeft()
        {
            Sprite = BlockSpriteFactory.Instance.CreateWallLeft();
            Position = new Vector2(300, 700);
        }
    }
}