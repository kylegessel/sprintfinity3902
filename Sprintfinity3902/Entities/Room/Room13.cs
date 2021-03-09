using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class Room13 : AbstractEntity
    {
        public Room13(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRoom13();
            Position = pos;
        }
    }
}
