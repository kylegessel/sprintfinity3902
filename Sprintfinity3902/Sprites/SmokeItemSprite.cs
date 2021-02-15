using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class SmokeItemSprite : AbstractSprite
    { 
        public Texture2D Texture { get; set; }

        private const int SMOKE1_X = 139;
        private const int SMOKE1_Y = 185;
        private const int SMOKE1_WIDTH = 16;
        private const int SMOKE1_HEIGHT = 16;

        private const int SMOKE2_X = 155;
        private const int SMOKE2_Y = 185;
        private const int SMOKE2_WIDTH = 16;
        private const int SMOKE2_HEIGHT = 16;

        private const int SMOKE3_X = 173;
        private const int SMOKE3_Y = 185;
        private const int SMOKE3_WIDTH = 16;
        private const int SMOKE3_HEIGHT = 16;


    public SmokeItemSprite(Texture2D texture)
    {
        SpriteFrame Sprite1 = new SpriteFrame(texture, SMOKE1_X, SMOKE1_Y, SMOKE1_WIDTH, SMOKE1_HEIGHT);
        SpriteFrame Sprite2 = new SpriteFrame(texture, SMOKE2_X, SMOKE2_Y, SMOKE2_WIDTH, SMOKE2_HEIGHT);
        SpriteFrame Sprite3 = new SpriteFrame(texture, SMOKE3_X, SMOKE3_Y, SMOKE3_WIDTH, SMOKE3_HEIGHT);
   
        Texture = texture;

        Animation = new Animation(true);
        Animation.AddFrame(Sprite1, 0);
        Animation.AddFrame(Sprite2, 1 / 8f);
        Animation.AddFrame(Sprite3, 1 / 4f);
        Animation.AddFrame(Sprite1, 1 / 2f);


        }
    }
}
