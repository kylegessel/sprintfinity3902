using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class LinkUpIdleSprite : ISprite
    {
        public Sprite Sprite1 { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public Animation Animation { get; set; }
        public AnimationFrame CurrentFrame { get; set; }

        private const int LINK_DOWN1_POS_X = 1;
        private const int LINK_DOWN1_POS_Y = 11;
        private const int LINK_DOWN1_WIDTH = 15;
        private const int LINK_DOWN1_HEIGHT = 16;

        public LinkUpIdleSprite(Texture2D texture, Vector2 position)
        {
            Sprite1 = new Sprite(texture, LINK_DOWN1_POS_X, LINK_DOWN1_POS_Y, LINK_DOWN1_WIDTH, LINK_DOWN1_HEIGHT);
            Texture = texture;
            Position = position;

            CurrentPositionX = (int)Position.X;
            CurrentPositionY = (int)Position.Y;
        }

        public void Update(GameTime gameTime)
        {
            /*
            Animation.Update(gameTime);
            CurrentFrame = Animation.CurrentFrame;
            */
            //Nothing to do
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Rectangle sourceRectangle = new Rectangle(Sprite1.X, Sprite1.Y, Sprite1.Width, Sprite1.Height);
            Rectangle destinationRectangle = new Rectangle(CurrentPositionX, CurrentPositionY, 75, 80);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void GetAnimation()
        {
            /*
            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);
            Animation.Play();
            */
            //There is no Animation
        }

    }
}