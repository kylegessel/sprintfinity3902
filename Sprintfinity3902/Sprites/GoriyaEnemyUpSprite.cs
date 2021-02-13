using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class GoriyaEnemyUpSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int GORIYA_POS_X = 241;
        private const int GORIYA_POS_Y = 11;
        private const int GORIYA_WIDTH = 13;
        private const int GORIYA_HEIGHT = 16;

        public GoriyaEnemyUpSprite(Texture2D texture)
        {
            Sprite Sprite = new Sprite(texture, GORIYA_POS_X, GORIYA_POS_Y, GORIYA_WIDTH, GORIYA_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite, 0);
            Animation.AddFrame(Sprite, 1 / 10f);
            Animation.AddFrame(Sprite, 1 / 5f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) {
            spriteBatch.Draw(Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 5.0f, Animation.CurrentFrame == Animation.GetFrame(1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
