using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DoorAllSidesRoom : AbstractEntity
    {
        public DoorAllSidesRoom(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDoorAllSidesRoom();
            Position = pos;
        }
    }
}
