using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class RoomInterior : AbstractBlock
    {
        public RoomInterior(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRoomInterior();
            Position = pos;
        }

        public override Boolean IsCollidable()
        {
            return false;
        }
    }
}
