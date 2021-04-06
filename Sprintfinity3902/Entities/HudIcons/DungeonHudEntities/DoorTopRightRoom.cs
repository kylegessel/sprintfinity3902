using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorTopRightRoom : AbstractEntity
    {
        public DoorTopRightRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorTopRightRoom();
            Position = pos;
        }
    }
}
