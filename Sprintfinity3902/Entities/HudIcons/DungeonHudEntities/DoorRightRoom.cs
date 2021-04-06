using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorRightRoom : AbstractEntity
    {
        public DoorRightRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorRightRoom();
            Position = pos;
        }
    }
}
