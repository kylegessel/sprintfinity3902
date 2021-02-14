using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class ClockItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int CLOCK_X = 58;
        private const int CLOCK_Y = 0;
        private const int CLOCK_WIDTH = 11;
        private const int CLOCK_HEIGHT = 16;

        public ClockItemSprite(Texture2D texture)
        {
            Sprite sprite1 = new Sprite(texture, CLOCK_X, CLOCK_Y, CLOCK_WIDTH, CLOCK_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
