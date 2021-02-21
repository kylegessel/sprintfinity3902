using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites.Items
{
    public class FairyItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int FAIRY1_X = 40;
        private const int FAIRY1_Y = 0;
        private const int FAIRY1_WIDTH = 8;
        private const int FAIRY1_HEIGHT = 16;

        private const int FAIRY2_X = 48;
        private const int FAIRY2_Y = 0;
        private const int FAIRY2_WIDTH = 8;
        private const int FAIRY2_HEIGHT = 16;

        public FairyItemSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, FAIRY1_X, FAIRY1_Y, FAIRY1_WIDTH, FAIRY1_HEIGHT);
            SpriteFrame sprite2 = new SpriteFrame(texture, FAIRY2_X, FAIRY2_Y, FAIRY2_WIDTH, FAIRY2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
            Animation.AddFrame(sprite2, 1 / 16f);
            Animation.AddFrame(sprite1, 1 / 8f);
        }
    }
}
