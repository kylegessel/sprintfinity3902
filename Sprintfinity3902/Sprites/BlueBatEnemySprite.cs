using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class BlueBatEnemySprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BAT1_POS_X = 183;
        private const int BAT1_POS_Y = 15;
        private const int BAT1_WIDTH = 16;
        private const int BAT1_HEIGHT = 8;

        private const int BAT2_POS_X = 203;
        private const int BAT2_POS_Y = 15;
        private const int BAT2_WIDTH = 10;
        private const int BAT2_HEIGHT = 10;

        public BlueBatEnemySprite(Texture2D texture)
        {
            Sprite Sprite1 = new Sprite(texture, BAT1_POS_X, BAT1_POS_Y, BAT1_WIDTH, BAT1_HEIGHT);
            Sprite Sprite2 = new Sprite(texture, BAT2_POS_X, BAT2_POS_Y, BAT2_WIDTH, BAT2_HEIGHT);
            Texture = texture;
            Position = new Vector2(500, 500);

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);
        }

    }
}
