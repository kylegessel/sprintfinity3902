using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorTopBotLeftRoom : AbstractEntity
    {
        public DoorTopBotLeftRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorTopBotLeftRoom();
            Position = pos;
        }
    }
}
