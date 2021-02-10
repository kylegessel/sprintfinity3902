using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Sprites;

namespace Sprintfinity3902.Interfaces
{
    public interface ISprite
    {
        Vector2 Position { get; set; }
        int CurrentPositionX { get; set; }
        int CurrentPositionY { get; set; }
        Animation Animation { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);

    }
}
