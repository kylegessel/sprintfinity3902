using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class HoleDoorTop : AbstractEntity
    {
        public HoleDoorTop()
        {
            Sprite = BlockSpriteFactory.Instance.CreateHoleDoorTop();
            Position = new Vector2(300, 700);
        }
    }
}
