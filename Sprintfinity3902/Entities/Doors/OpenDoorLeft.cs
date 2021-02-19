using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class OpenDoorLeft : AbstractEntity
    {
        public OpenDoorLeft()
        {
            Sprite = BlockSpriteFactory.Instance.CreateOpenDoorLeft();
            Position = new Vector2(300, 700);
        }
    }
}
