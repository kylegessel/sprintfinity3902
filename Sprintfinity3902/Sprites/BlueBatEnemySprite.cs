using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class BlueBatEnemySprite : ISprite
    {
        public Sprite Sprite1 { get; set; }
        public Sprite Sprite2 { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public Animation Animation { get; set; }
        public AnimationFrame CurrentFrame { get; set; }

        private const int BAT1_POS_X = 183;
        private const int BAT1_POS_Y = 15;
        private const int BAT1_WIDTH = 16;
        private const int BAT1_HEIGHT = 8;

        private const int BAT2_POS_X = 203;
        private const int BAT2_POS_Y = 15;
        private const int BAT2_WIDTH = 10;
        private const int BAT2_HEIGHT = 10;

        public BlueBatEnemySprite(Texture2D texture)
        {
            Sprite1 = new Sprite(texture, BAT1_POS_X, BAT1_POS_Y, BAT1_WIDTH, BAT1_HEIGHT);
            Sprite2 = new Sprite(texture, BAT2_POS_X, BAT2_POS_Y, BAT2_WIDTH, BAT2_HEIGHT);
            Texture = texture;
            Position = new Vector2(500, 500);
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
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 80, 40);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else if (frame2 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite2.X, Sprite2.Y, Sprite2.Width, Sprite2.Height);
                Rectangle destinationRectangle = new Rectangle(515, 500, 50, 50);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                Rectangle sourceRectangle = new Rectangle(Sprite2.X, Sprite2.Y, Sprite2.Width, Sprite2.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 50, 50);
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
