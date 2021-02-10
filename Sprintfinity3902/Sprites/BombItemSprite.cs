using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;


namespace Sprintfinity3902.Sprites
{
    class BombItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; private set; }

        private const int BOMB_POS_X = 129;
        private const int BOMB_POS_Y = 185;
        private const int BOMB_WIDTH = 8;
        private const int BOMB_HEIGHT = 14;

        public BombItemSprite(Texture2D texture)
        {
            Sprite Sprite1 = new Sprite(texture, BOMB_POS_X, BOMB_POS_Y, BOMB_WIDTH, BOMB_HEIGHT);
            Texture = texture;
            Position = new Vector2(750, 250);
            Animation = new Animation();
            Animation.AddFrame(Sprite1, 1 / 10f);

        }
    }
}
