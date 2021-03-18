using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class InventoryHudSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int HUD_X = 1;
        private const int HUD_Y = 11;
        private const int HUD_WIDTH = 256;
        private const int HUD_HEIGHT = 88;

        public InventoryHudSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, HUD_X, HUD_Y, HUD_WIDTH, HUD_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
