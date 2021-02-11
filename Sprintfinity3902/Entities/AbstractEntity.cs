using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class AbstractEntity : IEntity
    {
        private ISprite _sprite;
        private Vector2 _position;

        public ISprite Sprite
        {
            get
            {
                return _sprite;
            }
            set
            {
                _sprite = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        public int X
        {
            get
            {
                return (int)Position.X;
            }
            set
            {
                _position.X = value;
                //Position = new Vector2(value, Position.Y);
            }
        }
        public int Y
        {
            get
            {
                return (int)Position.Y;
            }
            set
            {
                _position.Y = value;
                //Position = new Vector2(Position.X, value);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Move();
            Attack();
        }

        public virtual void Move()
        {

        }

        public virtual void Attack()
        {

        }

        public virtual void SetState(IPlayerState state)
        {

        }
    }
}
