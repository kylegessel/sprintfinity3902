using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class HeartItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int HEART_R_X = 0;
        private const int HEART_R_Y = 0;
        private const int HEART_R_WIDTH = 7;
        private const int HEART_R_HEIGHT = 8;

        private const int HEART_B_X = 0;
        private const int HEART_B_Y = 8;
        private const int HEART_B_WIDTH = 7;
        private const int HEART_B_HEIGHT = 8;

        public HeartItemSprite(Texture2D texture)
        {
            Sprite sprite1 = new Sprite(texture, HEART_R_X, HEART_R_Y, HEART_R_WIDTH, HEART_R_HEIGHT);
            Sprite sprite2 = new Sprite(texture, HEART_B_X, HEART_B_Y, HEART_B_WIDTH, HEART_B_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
            Animation.AddFrame(sprite2, 1 / 2f);
            Animation.AddFrame(sprite1, 1);
        }
    }
}
