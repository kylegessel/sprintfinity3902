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

        public BlueBatEnemySprite(Texture2D texture, Vector2 position)
        {
            Sprite1 = new Sprite(texture, BAT1_POS_X, BAT1_POS_Y, BAT1_WIDTH, BAT1_HEIGHT);
            Sprite2 = new Sprite(texture, BAT2_POS_X, BAT2_POS_Y, BAT2_WIDTH, BAT2_HEIGHT);
            Texture = texture;
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void GetAnimation()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
