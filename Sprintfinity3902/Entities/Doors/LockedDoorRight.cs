using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class LockedDoorRight : AbstractEntity
    {
        public LockedDoorRight()
        {
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorRight();
            Position = new Vector2(300, 700);
        }
        public LockedDoorRight(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorRight();
            Position = pos;
        }
    }
}