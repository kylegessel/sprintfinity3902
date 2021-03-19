﻿using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class MiniMapEntity : AbstractEntity
    {
        public MiniMapEntity(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateMiniMap();
            Position = pos;
        }
    }
}