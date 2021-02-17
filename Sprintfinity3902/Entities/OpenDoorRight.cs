using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class OpenDoorRight : AbstractEntity
    {
        public OpenDoorRight()
        {
            Sprite = BlockSpriteFactory.Instance.CreateOpenDoorRight();
            Position = new Vector2(300, 700);
        }
    }
}