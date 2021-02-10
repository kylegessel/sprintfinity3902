using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class GoriyaEnemyRightSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int GORIYA1_POS_X = 257;
        private const int GORIYA1_POS_Y = 11;
        private const int GORIYA1_WIDTH = 13;
        private const int GORIYA1_HEIGHT = 16;

        private const int GORIYA2_POS_X = 275;
        private const int GORIYA2_POS_Y = 12;
        private const int GORIYA2_WIDTH = 14;
        private const int GORIYA2_HEIGHT = 15;

        public GoriyaEnemyRightSprite(Texture2D texture)
        {
            Sprite Sprite1 = new Sprite(texture, GORIYA1_POS_X, GORIYA1_POS_Y, GORIYA1_WIDTH, GORIYA1_HEIGHT);
            Sprite Sprite2 = new Sprite(texture, GORIYA2_POS_X, GORIYA2_POS_Y, GORIYA2_WIDTH, GORIYA2_HEIGHT);
            Texture = texture;
            Position = new Vector2(1000, 500);

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);
        }

    }
}
