using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class Room8Text : AbstractBlock
    {
        public Room8Text(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRoom8Text();
            Position = pos;
        }
    }
}
