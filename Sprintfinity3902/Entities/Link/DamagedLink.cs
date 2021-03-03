using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Link
{
    class DamagedLink : ILink
    {
        Game1 game;
        Player decoratedLink;
        Color linkColor;
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
        

        public DamagedLink (Player decoratedLink,Game1 game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;
            linkColor = Color.Red;
        }
        public void Update(GameTime gameTime)
        {
            timer--;
            if(timer == 0)
            {
                RemoveDecorator();
            }
            //Implement logic to determine color
            counter = timer % 12;
            if (counter < 3)
            {
                linkColor = Color.Aqua;
            }
            else if (counter < 6)
            {
                linkColor = Color.Red;
            }
            else if (counter < 9)
            {
                linkColor = Color.White;
            }
            else
            {
                linkColor = Color.Blue;
            }

            decoratedLink.Update(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch, Color Ignorecolor)
        {
            decoratedLink.Draw(spriteBatch, linkColor);
        }
        public void Move()
        {
            decoratedLink.Move();
        }
        public void SetState(IPlayerState state)
        {
            decoratedLink.SetState(state);
        }
        public void TakeDamage()
        {
            //doesn't take damage in damagedLink
        }
        public void RemoveDecorator()
        {
            game.playerCharacter = decoratedLink;
        }
    }
}
