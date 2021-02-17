using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class ClosedDoorLeft : AbstractEntity
    {
        public ClosedDoorLeft()
        {
            Sprite = BlockSpriteFactory.Instance.CreateClosedDoorLeft();
            Position = new Vector2(300, 700);
        }
    }
}