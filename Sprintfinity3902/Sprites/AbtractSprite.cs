using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites {
    public abstract class AbstractSprite : ISprite {

        private Animation _animation;
        private Vector2 _position;

        public Animation Animation {
            get {
                return _animation;
            }
            set {
                _animation = value;
            }
        }
        public Vector2 Position {
            get {
                return _position;
            }
            set {
                _position = value;
            }
        }
        public int X {
            get {
                return (int)Position.X;
            }
            set {
                _position.X = value;
                //Position = new Vector2(value, Position.Y);
            }
        }
        public int Y {
            get {
                return (int)Position.Y;
            }
            set {
                _position.Y = value;
                //Position = new Vector2(Position.X, value);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position) {
            Animation.Draw(spriteBatch, position);
        }

        public virtual void Update(GameTime gameTime) {
            Animation.Update(gameTime);
        }
    }
}