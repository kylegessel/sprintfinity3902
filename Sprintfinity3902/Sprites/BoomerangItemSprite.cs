using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;


namespace Sprintfinity3902.Sprites
{
    class BoomerangItemSprite : ISprite
    {
        public Sprite Sprite1 { get; set; }
        public Sprite Sprite2 { get; set; }
        public Sprite Sprite3 { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public Animation Animation { get; set; }
        public AnimationFrame CurrentFrame { get; set; }

        private const int BOOMERANG_POS1_X = 65;
        private const int BOOMERANG_POS1_Y = 189;
        private const int BOOMERANG_WIDTH1 = 5;
        private const int BOOMERANG_HEIGHT1 = 8;

        private const int BOOMERANG_POS2_X = 74;
        private const int BOOMERANG_POS2_Y = 189;
        private const int BOOMERANG_WIDTH2 = 8;
        private const int BOOMERANG_HEIGHT2 = 8;

        private const int BOOMERANG_POS3_X = 82;
        private const int BOOMERANG_POS3_Y = 192;
        private const int BOOMERANG_WIDTH3 = 8;
        private const int BOOMERANG_HEIGHT3 = 5;

        public BoomerangItemSprite(Texture2D texture)
        {
            Sprite1 = new Sprite(texture, BOOMERANG_POS1_X, BOOMERANG_POS1_Y, BOOMERANG_WIDTH1, BOOMERANG_HEIGHT1);
            Sprite2 = new Sprite(texture, BOOMERANG_POS2_X, BOOMERANG_POS2_Y, BOOMERANG_WIDTH2, BOOMERANG_HEIGHT2);
            Sprite3 = new Sprite(texture, BOOMERANG_POS3_X, BOOMERANG_POS3_Y, BOOMERANG_WIDTH3, BOOMERANG_HEIGHT3);
            Texture = texture;
            Position = new Vector2(750, 250);

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
            AnimationFrame frame4 = Animation.GetFrame(3);

            if (frame1 == CurrentFrame || frame4 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite1.X, Sprite1.Y, Sprite1.Width, Sprite1.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 25, 40);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else if (frame2 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite2.X, Sprite2.Y, Sprite2.Width, Sprite2.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 40, 40);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else if(frame3 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite3.X, Sprite3.Y, Sprite3.Width, Sprite3.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 40, 25);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else {
                Rectangle sourceRectangle = new Rectangle(Sprite1.X, Sprite1.Y, Sprite1.Width, Sprite1.Height);
                Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 25, 40);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
        }

        public void GetAnimation()
        {
            Animation = new Animation();
            Animation.AddFrame(Sprite1, 1/4f);
            Animation.AddFrame(Sprite2, 2/4f);
            Animation.AddFrame(Sprite3, 3/4f);
            Animation.AddFrame(Sprite1, 4/4f);
            Animation.Play();
        }
    }
}
