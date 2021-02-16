using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public abstract class AbstractEntity : IEntity
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
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
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

        public virtual void SetState(IState state) {
            /* 
             * Do Nothing at all
             * Most Entities will not need a SetState method
             * But they can choose to override this if they do
             */
        }
    }
}
