using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorTopBotRightRoom : AbstractEntity
    {
        public DoorTopBotRightRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorTopBotRightRoom();
            Position = pos;
        }
    }
}
