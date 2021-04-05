using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorTopBotRoom : AbstractEntity
    {
        public DoorTopBotRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorTopBotRoom();
            Position = pos;
        }
    }
}
