using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class Room14Interior : AbstractBlock
    {
        public Room14Interior(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRoom14Interior();
            Position = pos;
        }
    }
}
