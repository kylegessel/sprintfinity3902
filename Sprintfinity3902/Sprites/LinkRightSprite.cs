using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class LinkRightSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_RIGHT1_X = 35;
        private const int LINK_RIGHT1_Y = 11;
        private const int LINK_RIGHT1_WIDTH = 15;
        private const int LINK_RIGHT1_HEIGHT = 16;

        private const int LINK_RIGHT2_X = 52;
        private const int LINK_RIGHT2_Y = 12;
        private const int LINK_RIGHT2_WIDTH = 14;
        private const int LINK_RIGHT2_HEIGHT = 15;

        public LinkRightSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, LINK_RIGHT1_X, LINK_RIGHT1_Y, LINK_RIGHT1_WIDTH, LINK_RIGHT1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, LINK_RIGHT2_X, LINK_RIGHT2_Y, LINK_RIGHT2_WIDTH, LINK_RIGHT2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);
        }

       
            
        

    }
}
