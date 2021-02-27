using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class LockedDoorTop : AbstractEntity
    {
        public LockedDoorTop()
        {
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorTop();
            Position = new Vector2(300, 700);
        }
        public LockedDoorTop(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorTop();
            Position = pos;
        }
    }
}