using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class GoriyaEnemyRightSprite : ISprite
    {
        public Sprite Sprite1 { get; set; }
        public Sprite Sprite2 { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public Animation Animation { get; set; }
        public AnimationFrame CurrentFrame { get; set; }

        private const int GORIYA1_POS_X = 257;
        private const int GORIYA1_POS_Y = 11;
        private const int GORIYA1_WIDTH = 13;
        private const int GORIYA1_HEIGHT = 16;

        private const int GORIYA2_POS_X = 275;
        private const int GORIYA2_POS_Y = 12;
        private const int GORIYA2_WIDTH = 14;
        private const int GORIYA2_HEIGHT = 15;

        public GoriyaEnemyRightSprite(Texture2D texture)
        {
            Sprite1 = new Sprite(texture, GORIYA1_POS_X, GORIYA1_POS_Y, GORIYA1_WIDTH, GORIYA1_HEIGHT);
            Sprite2 = new Sprite(texture, GORIYA2_POS_X, GORIYA2_POS_Y, GORIYA2_WIDTH, GORIYA2_HEIGHT);
            Texture = texture;
            Position = new Vector2(1000, 500);

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
                Rectangle sourceRectangle = new Rectangle(Sprite1.X, Sprite1.Y, Sprite1.Width, Sprite1.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 65, 80);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else if (frame2 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite2.X, Sprite2.Y, Sprite2.Width, Sprite2.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 70, 75);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                Rectangle sourceRectangle = new Rectangle(Sprite1.X, Sprite1.Y, Sprite1.Width, Sprite1.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 65, 80);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }

        }

        public void GetAnimation()
        {
            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);
            Animation.Play();
        }
    }
}
