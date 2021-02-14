using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class BowItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BOW_X = 144;
        private const int BOW_Y = 0;
        private const int BOW_WIDTH = 8;
        private const int BOW_HEIGHT = 16;

        public BowItemSprite(Texture2D texture)
        {
            Sprite sprite1 = new Sprite(texture, BOW_X, BOW_Y, BOW_WIDTH, BOW_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
