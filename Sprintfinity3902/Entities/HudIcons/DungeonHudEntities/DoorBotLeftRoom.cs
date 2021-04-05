using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorBotLeftRoom : AbstractEntity
    {
        public DoorBotLeftRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorBotLeftRoom();
            Position = pos;
        }
    }
}
