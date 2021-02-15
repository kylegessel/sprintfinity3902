using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class MapItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int MAP_X = 88;
        private const int MAP_Y = 0;
        private const int MAP_WIDTH = 8;
        private const int MAP_HEIGHT = 16;

        public MapItemSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, MAP_X, MAP_Y, MAP_WIDTH, MAP_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
