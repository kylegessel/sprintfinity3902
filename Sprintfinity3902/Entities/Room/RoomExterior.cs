using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class RoomExterior : AbstractEntity
    {
        public RoomExterior(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRoomExterior();
            Position = pos;
        }
    }
}
