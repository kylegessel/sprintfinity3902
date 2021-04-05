using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorBotRoom : AbstractEntity
    {
        public DoorBotRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorBotRoom();
            Position = pos;
        }
    }
}