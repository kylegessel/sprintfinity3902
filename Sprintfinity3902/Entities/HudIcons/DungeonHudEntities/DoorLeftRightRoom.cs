using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorLeftRightRoom : AbstractEntity
    {
        public DoorLeftRightRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorLeftRightRoom();
            Position = pos;
        }
    }
}
