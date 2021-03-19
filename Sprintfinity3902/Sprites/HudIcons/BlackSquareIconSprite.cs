﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class BlackSquareIconSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int ICON_X = 435;
        private const int ICON_Y = 35;
        private const int ICON_WIDTH = 8;
        private const int ICON_HEIGHT = 8;

        public BlackSquareIconSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, ICON_X, ICON_Y, ICON_WIDTH, ICON_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
