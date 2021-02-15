using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class TriforceItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int TRIFORCE_G_X = 275;
        private const int TRIFORCE_G_Y = 3;
        private const int TRIFORCE_G_WIDTH = 10;
        private const int TRIFORCE_G_HEIGHT = 10;

        private const int TRIFORCE_B_X = 275;
        private const int TRIFORCE_B_Y = 19;
        private const int TRIFORCE_B_WIDTH = 10;
        private const int TRIFORCE_B_HEIGHT = 10;

        public TriforceItemSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, TRIFORCE_G_X, TRIFORCE_G_Y, TRIFORCE_G_WIDTH, TRIFORCE_G_HEIGHT);
            SpriteFrame sprite2 = new SpriteFrame(texture, TRIFORCE_B_X, TRIFORCE_B_Y, TRIFORCE_B_WIDTH, TRIFORCE_B_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
            Animation.AddFrame(sprite2, 1/4f);
            Animation.AddFrame(sprite1, 1/2f);
        }
    }
}
