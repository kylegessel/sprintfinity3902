using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class HoleDoorLeft : AbstractEntity
    {
        public HoleDoorLeft()
        {
            Sprite = BlockSpriteFactory.Instance.CreateHoleDoorLeft();
            Position = new Vector2(300, 700);
        }
    }
}