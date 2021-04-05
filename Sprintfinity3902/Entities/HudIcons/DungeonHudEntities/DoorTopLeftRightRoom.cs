using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorTopLeftRightRoom : AbstractEntity
    {
        public DoorTopLeftRightRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorTopLeftRightRoom();
            Position = pos;
        }
    }
}
