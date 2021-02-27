using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class HoleDoorRight : AbstractEntity
    {
        public HoleDoorRight()
        {
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorRight();
            Position = new Vector2(300, 700);
        }
        public HoleDoorRight(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorRight();
            Position = pos;
        }
    }
}