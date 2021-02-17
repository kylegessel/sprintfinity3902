using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class LockedDoorLeft : AbstractEntity
    {
        public LockedDoorLeft()
        {
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorLeft();
            Position = new Vector2(300, 700);
        }
    }
}