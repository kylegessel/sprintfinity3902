using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class GoriyaEnemyDownSprite : ISprite
    {
        public Sprite Sprite { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public Animation Animation { get; set; }
        public AnimationFrame CurrentFrame { get; set; }

        private const int GORIYA_POS_X = 224;
        private const int GORIYA_POS_Y = 11;
        private const int GORIYA_WIDTH = 13;
        private const int GORIYA_HEIGHT = 16;

        public GoriyaEnemyDownSprite(Texture2D texture)
        {
            Sprite = new Sprite(texture, GORIYA_POS_X, GORIYA_POS_Y, GORIYA_WIDTH, GORIYA_HEIGHT);
            Texture = texture;
            Position = new Vector2(700, 500);

            GetAnimation();
        }

        public void Update(GameTime gameTime)
        {
            Animation.Update(gameTime);
            CurrentFrame = Animation.CurrentFrame;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            AnimationFrame frame1 = Animation.GetFrame(0);
            AnimationFrame frame2 = Animation.GetFrame(1);
            AnimationFrame frame3 = Animation.GetFrame(2);

            if (frame1 == CurrentFrame || frame3 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite.X, Sprite.Y, Sprite.Width, Sprite.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 65, 80);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else if (frame2 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite.X, Sprite.Y, Sprite.Width, Sprite.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 65, 80);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                Rectangle sourceRectangle = new Rectangle(Sprite.X, Sprite.Y, Sprite.Width, Sprite.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 65, 80);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }

        }

        public void GetAnimation()
        {
            Animation = new Animation();
            Animation.AddFrame(Sprite, 0);
            Animation.AddFrame(Sprite, 1 / 10f);
            Animation.AddFrame(Sprite, 1 / 5f);
            Animation.Play();
        }
    }
}
