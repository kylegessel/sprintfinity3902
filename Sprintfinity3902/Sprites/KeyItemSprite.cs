using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class KeyItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int KEY_X = 240;
        private const int KEY_Y = 0;
        private const int KEY_WIDTH = 8;
        private const int KEY_HEIGHT = 16;

        public KeyItemSprite(Texture2D texture)
        {
            Sprite sprite1 = new Sprite(texture, KEY_X, KEY_Y, KEY_WIDTH, KEY_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
