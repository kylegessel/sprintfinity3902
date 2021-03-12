using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Link
{
    class DamagedEntity : IEntity
    {
        IRoom room;
        IEntity decoratedEntity;
        Color Color;
        int counter;
        int timer = 400;
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
        public float X
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
        public float Y
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

        // pass room as well?
        public DamagedEntity(IEntity decoratedEntity, IRoom room)
        {
            this.decoratedEntity = decoratedEntity;
            this.room = room;
            room.enemies.Add(decoratedEntity);
            Color = Color.Red;
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer == 0)
            {

            }
            //Implement logic to determine color
            counter = timer % 12;
            if (counter < 3)
            {
                Color = Color.Aqua;
            }
            else if (counter < 6)
            {
                Color = Color.Red;
            }
            else if (counter < 9)
            {
                Color = Color.White;
            }
            else
            {
                Color = Color.Blue;
            }

            decoratedEntity.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Color Ignorecolor)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch);
        }

        public void Move()
        {
            decoratedEntity.Move();
        }

        public void Attack()
        {
            decoratedEntity.Attack();
        }

        public void SetState(IPlayerState state)
        {
            decoratedEntity.SetState(state);
        }

        public Rectangle GetBoundingRect()
        {
            return decoratedEntity.GetBoundingRect();
        }

        // How do I remove decorator?
        public void RemoveDecorator()
        {
            // game.playerCharacter = decoratedLink;
            room.enemies.Remove(decoratedEntity);
        }
    }
}
