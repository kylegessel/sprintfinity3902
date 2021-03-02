using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class ClosedDoorRight : AbstractEntity
    {
        public ClosedDoorRight()
        {
            Sprite = BlockSpriteFactory.Instance.CreateClosedDoorRight();
            Position = new Vector2(300, 700);
        }
        public ClosedDoorRight(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateClosedDoorRight();
            Position = pos;
        }
    }
}