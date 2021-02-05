using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class LinkDownAttackSprite : ISprite
    {
        public Sprite Sprite1 { get; set; }
        public Sprite Sprite2 { get; set; }
        public Sprite Sprite3 { get; set; }
        public Sprite Sprite4 { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public Animation Animation { get; set; }
        public AnimationFrame CurrentFrame { get; set; }

        private const int LINK_DATTACK1_POS_X = 1;
        private const int LINK_DATTACK1_POS_Y = 47;
        private const int LINK_DATTACK1_WIDTH = 16;
        private const int LINK_DATTACK1_HEIGHT = 27;

        private const int LINK_DATTACK2_POS_X = 18;
        private const int LINK_DATTACK2_POS_Y = 47;
        private const int LINK_DATTACK2_WIDTH = 16;
        private const int LINK_DATTACK2_HEIGHT = 27;

        private const int LINK_DATTACK3_POS_X = 35;
        private const int LINK_DATTACK3_POS_Y = 47;
        private const int LINK_DATTACK3_WIDTH = 16;
        private const int LINK_DATTACK3_HEIGHT = 27;

        private const int LINK_DATTACK4_POS_X = 53;
        private const int LINK_DATTACK4_POS_Y = 47;
        private const int LINK_DATTACK4_WIDTH = 16;
        private const int LINK_DATTACK4_HEIGHT = 27;

        public LinkDownAttackSprite(Texture2D texture, Vector2 position)
        {
            Sprite1 = new Sprite(texture, LINK_DATTACK1_POS_X, LINK_DATTACK1_POS_Y, LINK_DATTACK1_WIDTH, LINK_DATTACK1_HEIGHT);
            Sprite2 = new Sprite(texture, LINK_DATTACK2_POS_X, LINK_DATTACK2_POS_Y, LINK_DATTACK2_WIDTH, LINK_DATTACK2_HEIGHT);
            Sprite3 = new Sprite(texture, LINK_DATTACK3_POS_X, LINK_DATTACK3_POS_Y, LINK_DATTACK3_WIDTH, LINK_DATTACK3_HEIGHT);
            Sprite4 = new Sprite(texture, LINK_DATTACK4_POS_X, LINK_DATTACK4_POS_Y, LINK_DATTACK4_WIDTH, LINK_DATTACK4_HEIGHT);
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
            AnimationFrame frame4 = Animation.GetFrame(3);
            AnimationFrame frame5 = Animation.GetFrame(0);

            if (frame1 == CurrentFrame || frame5 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite1.X, Sprite1.Y, Sprite1.Width, Sprite1.Height);
                Rectangle destinationRectangle = new Rectangle(CurrentPositionX, CurrentPositionY, Sprite1.Width*5, Sprite1.Height*5);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else if (frame2 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite2.X, Sprite2.Y, Sprite2.Width, Sprite2.Height);
                Rectangle destinationRectangle = new Rectangle(CurrentPositionX, CurrentPositionY, Sprite2.Width*5, Sprite2.Height*5);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else if (frame3 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite2.X, Sprite2.Y, Sprite3.Width, Sprite3.Height);
                Rectangle destinationRectangle = new Rectangle(CurrentPositionX, CurrentPositionY, Sprite3.Width*5, Sprite3.Height*5);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else if (frame4 == CurrentFrame)
            {
                Rectangle sourceRectangle = new Rectangle(Sprite4.X, Sprite4.Y, Sprite4.Width, Sprite4.Height);
                Rectangle destinationRectangle = new Rectangle(CurrentPositionX, CurrentPositionY, Sprite4.Width*5, Sprite4.Height*5);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }

        }

        public void GetAnimation()
        {
            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 32f);
            Animation.AddFrame(Sprite3, 1 / 24f);
            Animation.AddFrame(Sprite4, 1 / 16f);
            Animation.AddFrame(Sprite1, 1 / 8f);
            Animation.Play();
        }

    }
}
