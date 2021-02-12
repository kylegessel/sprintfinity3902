using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    class DamagedLinkDownSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_DOWN1_POS_X = 35;
        private const int LINK_DOWN1_POS_Y = 230;
        private const int LINK_DOWN1_WIDTH = 15;
        private const int LINK_DOWN1_HEIGHT = 16;

        private const int LINK_DOWN2_POS_X = 35;
        private const int LINK_DOWN2_POS_Y = 230;
        private const int LINK_DOWN2_WIDTH = 13;
        private const int LINK_DOWN2_HEIGHT = 16;

        public DamagedLinkDownSprite(Texture2D texture)
        {
            Sprite Sprite1 = new Sprite(texture, LINK_DOWN1_POS_X, LINK_DOWN1_POS_Y, LINK_DOWN1_WIDTH, LINK_DOWN1_HEIGHT);
            Sprite Sprite2 = new Sprite(texture, LINK_DOWN2_POS_X, LINK_DOWN2_POS_Y, LINK_DOWN2_WIDTH, LINK_DOWN2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);
        }

    }
}
