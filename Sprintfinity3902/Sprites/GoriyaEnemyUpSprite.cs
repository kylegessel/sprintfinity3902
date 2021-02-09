using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class GoriyaEnemyUpSprite : AbstractEntity
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
            Position = new Vector2(800, 500);

            Animation = new Animation();
            Animation.AddFrame(Sprite, 0);
            Animation.AddFrame(Sprite, 1 / 10f);
            Animation.AddFrame(Sprite, 1 / 5f);
            Animation.Play();
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, Position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 5.0f, Animation.CurrentFrame == Animation.GetFrame(1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
