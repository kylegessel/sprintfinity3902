using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class Room8Interior : AbstractBlock
    {
        public Room8Interior(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRoom8Interior();
            Position = pos;
        }
    }
}
