﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class FinalBossMouthCloseSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BOSS_CLOSED_1_POS_X = 51;
        private const int BOSS_CLOSED_1_POS_Y = 11;
        private const int BOSS_CLOSED_1_WIDTH = 24;
        private const int BOSS_CLOSED_1_HEIGHT = 32;

        private const int BOSS_CLOSED_2_POS_X = 76;
        private const int BOSS_CLOSED_2_POS_Y = 11;
        private const int BOSS_CLOSED_2_WIDTH = 24;
        private const int BOSS_CLOSED_2_HEIGHT = 32;

        public FinalBossMouthCloseSprite(Texture2D texture)
        {
            Sprite Sprite1 = new Sprite(texture, BOSS_CLOSED_1_POS_X, BOSS_CLOSED_1_POS_Y, BOSS_CLOSED_1_WIDTH, BOSS_CLOSED_1_HEIGHT);
            Sprite Sprite2 = new Sprite(texture, BOSS_CLOSED_2_POS_X, BOSS_CLOSED_2_POS_Y, BOSS_CLOSED_2_WIDTH, BOSS_CLOSED_2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 2f);
            Animation.AddFrame(Sprite1, 1);
        
        }
    }
}
