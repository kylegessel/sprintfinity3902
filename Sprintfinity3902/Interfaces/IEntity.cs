using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;

namespace Sprintfinity3902.Interfaces {
    public interface IEntity {
        Vector2 Position {
            get; set;
        }
        public Animation Animation { get; }
        int X {
            get; set;
        }
        int Y {
            get; set;
        }
        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);
    }
}