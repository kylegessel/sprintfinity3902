using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorTopLeftRoom : AbstractEntity
    {
        public DoorTopLeftRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorTopLeftRoom();
            Position = pos;
        }
    }
}
