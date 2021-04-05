using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class RoomInterior : AbstractBlock
    {
        public RoomInterior(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRoomInterior();
            Position = pos;
            //Collidable = false;
        }

        public override Boolean IsCollidable()
        {
            return false;
        }
    }
}
