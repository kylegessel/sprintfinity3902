using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ardrey.Sprint0.Sprites
{
    public class LinkUpSprite : ISprite
    {
        public Sprite Sprite1 { get; set; }
        public Sprite Sprite2 { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public Animation Animation { get; set; }
        public AnimationFrame CurrentFrame { get; set; }

        private const int LINK_UP1_POS_X = 71;
        private const int LINK_UP1_POS_Y = 11;
        private const int LINK_UP1_WIDTH = 12;
        private const int LINK_UP1_HEIGHT = 16;

        private const int LINK_UP2_POS_X = 88;
        private const int LINK_UP2_POS_Y = 11;
        private const int LINK_UP2_WIDTH = 12;
        private const int LINK_UP2_HEIGHT = 16;

        public LinkUpSprite(Texture2D texture, Vector2 position)
        {
            Sprite1 = new Sprite(texture, LINK_UP1_POS_X, LINK_UP1_POS_Y, LINK_UP1_WIDTH, LINK_UP1_HEIGHT);
            Sprite2 = new Sprite(texture, LINK_UP2_POS_X, LINK_UP2_POS_Y, LINK_UP2_WIDTH, LINK_UP2_HEIGHT);
            Texture = texture;
            Position = position;

            CurrentPositionX = (int)Position.X;
            CurrentPositionY = (int)Position.Y;
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
                Rectangle destinationRectangle = new Rectangle(CurrentPositionX, CurrentPositionY, 60, 80);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else if (frame2 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite2.X, Sprite2.Y, Sprite2.Width, Sprite2.Height);
                Rectangle destinationRectangle = new Rectangle(CurrentPositionX, CurrentPositionY, 60, 80);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void GetAnimation()
        {
            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1/10f);
            Animation.AddFrame(Sprite1, 1/5f);
            Animation.Play();
        }

    }
}
