using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
namespace Sprintfinity3902.Sprites
{
    public class MovingSwordVerticalSprite : AbstractSprite
    {
        public Texture2D Texture { get; private set; }

        private const int SWORD1_POS_X = 1;
        private const int SWORD1_POS_Y = 154;
        private const int SWORD1_WIDTH = 7;
        private const int SWORD1_HEIGHT = 16;

        private const int SWORD2_POS_X = 71;
        private const int SWORD2_POS_Y = 154;
        private const int SWORD2_WIDTH = 7;
        private const int SWORD2_HEIGHT = 16;

        public MovingSwordVerticalSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, SWORD1_POS_X, SWORD1_POS_Y, SWORD1_WIDTH, SWORD1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, SWORD2_POS_X, SWORD2_POS_Y, SWORD2_WIDTH, SWORD2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 32f);
            Animation.AddFrame(Sprite1, 1 / 16f);
        }
    }
}
