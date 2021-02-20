﻿using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class StairsBlock : AbstractEntity
    {
        public StairsBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateStairsBlock();
            Position = new Vector2(300, 700);
        }
    }
}