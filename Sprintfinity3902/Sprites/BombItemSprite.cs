using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;


namespace Sprintfinity3902.Sprites
{
    class BombItemSprite : ISprite
    {
        public Sprite Sprite1 { get; set; }
        public Sprite Sprite2 { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public Animation Animation { get; set; }
        public AnimationFrame CurrentFrame { get; set; }

        private const int BOMB_POS_X = 129;
        private const int BOMB_POS_Y = 185;
        private const int BOMB_WIDTH = 8;
        private const int BOMB_HEIGHT = 14;

        public BombItemSprite(Texture2D texture)
        {
            Sprite1 = new Sprite(texture, BOMB_POS_X, BOMB_POS_Y, BOMB_WIDTH, BOMB_HEIGHT);
            Texture = texture;
            Position = new Vector2(750, 250);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Rectangle sourceRectangle = new Rectangle(Sprite1.X, Sprite1.Y, Sprite1.Width, Sprite1.Height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 40, 70);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void GetAnimation()
        {
        }
    }
}
