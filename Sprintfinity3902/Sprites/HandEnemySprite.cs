using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class HandEnemySprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int HAND1_POS_X = 393;
        private const int HAND1_POS_Y = 11;
        private const int HAND1_WIDTH = 16;
        private const int HAND1_HEIGHT = 16;

        private const int HAND2_POS_X = 410;
        private const int HAND2_POS_Y = 12;
        private const int HAND2_WIDTH = 14;
        private const int HAND2_HEIGHT = 15;

        public HandEnemySprite(Texture2D texture)
        {
            Sprite Sprite1 = new Sprite(texture, HAND1_POS_X, HAND1_POS_Y, HAND1_WIDTH, HAND1_HEIGHT);
            Sprite Sprite2 = new Sprite(texture, HAND2_POS_X, HAND2_POS_Y, HAND2_WIDTH, HAND2_HEIGHT);
            Texture = texture;
            Position = new Vector2(1200, 500);

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 4f);
            Animation.AddFrame(Sprite1, 1 / 2f);
        }
    }
}
