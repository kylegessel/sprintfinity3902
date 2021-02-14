using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class LinkUpSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_UP1_POS_X = 71;
        private const int LINK_UP1_POS_Y = 11;
        private const int LINK_UP1_WIDTH = 12;
        private const int LINK_UP1_HEIGHT = 16;

        private const int LINK_UP2_POS_X = 88;
        private const int LINK_UP2_POS_Y = 11;
        private const int LINK_UP2_WIDTH = 12;
        private const int LINK_UP2_HEIGHT = 16;

        public LinkUpSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, LINK_UP1_POS_X, LINK_UP1_POS_Y, LINK_UP1_WIDTH, LINK_UP1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, LINK_UP2_POS_X, LINK_UP2_POS_Y, LINK_UP2_WIDTH, LINK_UP2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);

        }



    }
}
