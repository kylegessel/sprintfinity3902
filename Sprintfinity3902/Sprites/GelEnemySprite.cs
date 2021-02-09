using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class GelEnemySprite : AbstractEntity
    {
        public Texture2D Texture { get; set; }

        private const int GEL1_POS_X = 1;
        private const int GEL1_POS_Y = 16;
        private const int GEL1_WIDTH = 8;
        private const int GEL1_HEIGHT = 8;

        private const int GEL2_POS_X = 11;
        private const int GEL2_POS_Y = 15;
        private const int GEL2_WIDTH = 6;
        private const int GEL2_HEIGHT = 9;

        public GelEnemySprite(Texture2D texture)
        {
            Sprite Sprite1 = new Sprite(texture, GEL1_POS_X, GEL1_POS_Y, GEL1_WIDTH, GEL1_HEIGHT);
            Sprite Sprite2 = new Sprite(texture, GEL2_POS_X, GEL2_POS_Y, GEL2_WIDTH, GEL2_HEIGHT);
            Texture = texture;
            Position = new Vector2(600, 500);

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 24f);
            Animation.AddFrame(Sprite1, 1 / 12f);
            Animation.Play();
        }

    }
}
