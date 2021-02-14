using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class HeartContainerItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int HEART_X = 25;
        private const int HEART_Y = 1;
        private const int HEART_WIDTH = 13;
        private const int HEART_HEIGHT = 13;

        public HeartContainerItemSprite(Texture2D texture)
        {
            Sprite sprite1 = new Sprite(texture, HEART_X, HEART_Y, HEART_WIDTH, HEART_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
