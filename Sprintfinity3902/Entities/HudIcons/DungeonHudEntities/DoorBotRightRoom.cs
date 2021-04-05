using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorBotRightRoom : AbstractEntity
    {
        public DoorBotRightRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorBotRightRoom();
            Position = pos;
        }
    }
}
