using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class ClosedDoorTop : AbstractEntity
    {
        public ClosedDoorTop()
        {
            Sprite = BlockSpriteFactory.Instance.CreateClosedDoorTop();
            Position = new Vector2(300, 700);
        }
        public ClosedDoorTop(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateClosedDoorTop();
            Position = pos;
        }
    }
}