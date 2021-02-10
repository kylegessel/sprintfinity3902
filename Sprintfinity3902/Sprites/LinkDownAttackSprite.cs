using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class LinkDownAttackSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_DATTACK1_POS_X = 1;
        private const int LINK_DATTACK1_POS_Y = 47;
        private const int LINK_DATTACK1_WIDTH = 16;
        private const int LINK_DATTACK1_HEIGHT = 27;

        private const int LINK_DATTACK2_POS_X = 18;
        private const int LINK_DATTACK2_POS_Y = 47;
        private const int LINK_DATTACK2_WIDTH = 16;
        private const int LINK_DATTACK2_HEIGHT = 27;

        private const int LINK_DATTACK3_POS_X = 35;
        private const int LINK_DATTACK3_POS_Y = 47;
        private const int LINK_DATTACK3_WIDTH = 16;
        private const int LINK_DATTACK3_HEIGHT = 27;

        private const int LINK_DATTACK4_POS_X = 53;
        private const int LINK_DATTACK4_POS_Y = 47;
        private const int LINK_DATTACK4_WIDTH = 16;
        private const int LINK_DATTACK4_HEIGHT = 27;

        public LinkDownAttackSprite(Texture2D texture)
        {
            Sprite Sprite1 = new Sprite(texture, LINK_DATTACK1_POS_X, LINK_DATTACK1_POS_Y, LINK_DATTACK1_WIDTH, LINK_DATTACK1_HEIGHT);
            Sprite Sprite2 = new Sprite(texture, LINK_DATTACK2_POS_X, LINK_DATTACK2_POS_Y, LINK_DATTACK2_WIDTH, LINK_DATTACK2_HEIGHT);
            Sprite Sprite3 = new Sprite(texture, LINK_DATTACK3_POS_X, LINK_DATTACK3_POS_Y, LINK_DATTACK3_WIDTH, LINK_DATTACK3_HEIGHT);
            Sprite Sprite4 = new Sprite(texture, LINK_DATTACK4_POS_X, LINK_DATTACK4_POS_Y, LINK_DATTACK4_WIDTH, LINK_DATTACK4_HEIGHT);
            Texture = texture;

            Animation = new Animation(false);
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 32f);
            Animation.AddFrame(Sprite3, 1 / 24f);
            Animation.AddFrame(Sprite4, 1 / 16f);
            Animation.AddFrame(Sprite1, 1 / 8f);
            Animation.PlayOnce();
        }

    }
}
