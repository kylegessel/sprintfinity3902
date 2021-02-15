using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class LinkRightAttackSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_RATTACK1_POS_X = 1;
        private const int LINK_RATTACK1_POS_Y = 78;
        private const int LINK_RATTACK1_WIDTH = 15;
        private const int LINK_RATTACK1_HEIGHT = 15;

        private const int LINK_RATTACK2_POS_X = 18;
        private const int LINK_RATTACK2_POS_Y = 78;
        private const int LINK_RATTACK2_WIDTH = 27;
        private const int LINK_RATTACK2_HEIGHT = 15;

        private const int LINK_RATTACK3_POS_X = 46;
        private const int LINK_RATTACK3_POS_Y = 78;
        private const int LINK_RATTACK3_WIDTH = 23;
        private const int LINK_RATTACK3_HEIGHT = 15;

        private const int LINK_RATTACK4_POS_X = 70;
        private const int LINK_RATTACK4_POS_Y = 77;
        private const int LINK_RATTACK4_WIDTH = 19;
        private const int LINK_RATTACK4_HEIGHT = 16;

        public LinkRightAttackSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, LINK_RATTACK1_POS_X, LINK_RATTACK1_POS_Y, LINK_RATTACK1_WIDTH, LINK_RATTACK1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, LINK_RATTACK2_POS_X, LINK_RATTACK2_POS_Y, LINK_RATTACK2_WIDTH, LINK_RATTACK2_HEIGHT);
            SpriteFrame Sprite3 = new SpriteFrame(texture, LINK_RATTACK3_POS_X, LINK_RATTACK3_POS_Y, LINK_RATTACK3_WIDTH, LINK_RATTACK3_HEIGHT);
            SpriteFrame Sprite4 = new SpriteFrame(texture, LINK_RATTACK4_POS_X, LINK_RATTACK4_POS_Y, LINK_RATTACK4_WIDTH, LINK_RATTACK4_HEIGHT);
            Texture = texture;

            Animation = new Animation(false);
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 32f);
            Animation.AddFrame(Sprite3, 2 / 8f);
            Animation.AddFrame(Sprite4, 3 / 8f);
            Animation.AddFrame(Sprite1, 4 / 8f);
            Animation.PlayOnce();
        }
    }
}
