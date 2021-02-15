using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class CompassItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int COMPASS_X = 258;
        private const int COMPASS_Y = 1;
        private const int COMPASS_WIDTH = 11;
        private const int COMPASS_HEIGHT = 12;

        public CompassItemSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, COMPASS_X, COMPASS_Y, COMPASS_WIDTH, COMPASS_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
