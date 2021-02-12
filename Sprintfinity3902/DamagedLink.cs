﻿using Sprintfinity3902.Sprites;
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
        Player decoratedLink;
        int timer = 1000;
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
        

        public DamagedLink (Player decoratedLink, Game1 game)
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
            //CurrentState.Sprite.Draw(spriteBatch, Position);
            decoratedLink.Draw(spriteBatch);
        }
        public void Move()
        {
            //CurrentState.Move();
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