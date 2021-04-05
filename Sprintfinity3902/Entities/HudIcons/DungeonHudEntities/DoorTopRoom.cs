using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorTopRoom : AbstractEntity
    {
        public DoorTopRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorTopRoom();
            Position = pos;
        }
    }
}