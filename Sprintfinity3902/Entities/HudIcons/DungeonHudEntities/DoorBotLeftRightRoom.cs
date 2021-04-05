using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorBotLeftRightRoom : AbstractEntity
    {
        public DoorBotLeftRightRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorBotLeftRightRoom();
            Position = pos;
        }
    }
}
