﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;

namespace Sprintfinity3902.Entities
{
    public abstract class AbstractEntity : IEntity, ICollidable
    {
        private ISprite _sprite;
        private Vector2 _position;
        private Boolean _collidable = true;
        private Color _color;

        // Does this belong here and can we make better use of it elsewhere?
        // Boggus mentioned a magic numbers cleanup, believe this could be useful.
        public enum Direction
        {
            NONE,
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
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
        public float X
        {
            get
            {
                return Position.X;
            }
            set
            {
                _position.X = value;
            }
        }
        public float Y
        {
            get
            {
                return Position.Y;
            }
            set
            {
                _position.Y = value;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            // These are specific to a class which inherits this Abstract Class, so keep these in in concrete class as override
            /*
             * Move();
             * Attack();
             */
            Move();
        }

        public virtual void Attack()
        {

        }
        public virtual void Move()
        {

        }
        public virtual void SetState(IPlayerState state)
        {
            /* 
             * Do Nothing at all
             * Most Entities will not need a SetState method
             * But they can choose to override this if they do
             */
        }

        public virtual Boolean IsCollidable()
        {
            return _collidable;
        }



        public virtual Rectangle GetBoundingRect()
        {
            //Sprite.Animation.CurrentFrame.Width
            return new Rectangle((int)Position.X, (int)Position.Y, 16 * Global.Var.SCALE, 16 * Global.Var.SCALE);

        }
    }
}
