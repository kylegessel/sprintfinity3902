using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class OpenDoorTop : AbstractEntity
    {
        public OpenDoorTop()
        {
            Sprite = BlockSpriteFactory.Instance.CreateOpenDoorTop();
            Position = new Vector2(300, 700);
        }
    }
}