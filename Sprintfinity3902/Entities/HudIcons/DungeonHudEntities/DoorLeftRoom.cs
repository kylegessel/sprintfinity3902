using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorLeftRoom : AbstractEntity
    {
        public DoorLeftRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorLeftRoom();
            Position = pos;
        }
    }
}

