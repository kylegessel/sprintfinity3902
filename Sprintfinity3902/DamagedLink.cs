using Sprintfinity3902.Sprites;
using Sprintfinity3902.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Sprintfinity3902.Controllers;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;


namespace Sprintfinity3902.Link
{
    class DamagedLink : ILink
    {
        Game1 game;
        ILink decoratedLink;
        int timer = 1000;

        //Have to include Sprite and position info to satisfy ILink that extends IEntity
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
        
        

        public DamagedLink (ILink decoratedLink, Game1 game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;
        }
        public void Update(GameTime gameTime)
        {
            timer--;
            if(timer == 0)
            {
                RemoveDecorator();
            }
            decoratedLink.Update(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
           // Have an increment and then if else statements to change between red and blue
           //Could pass a color from here all the way down to Animation...
            decoratedLink.Draw(spriteBatch);
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
