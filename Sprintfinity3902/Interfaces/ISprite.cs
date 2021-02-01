using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Ardrey.Sprint0.Sprites;

namespace Ardrey.Sprint0
{
    public interface ISprite
    {
        Vector2 Position { get; set; }
        int CurrentPositionX { get; set; }
        int CurrentPositionY { get; set; }
        public Animation Animation { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        void GetAnimation();

    }
}
