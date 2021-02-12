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
using Sprintfinity3902.Entities;

namespace Sprintfinity3902.Entities
{
    class DamagedLink : AbstractEntity
    {
        Game1 game;
        Player decoratedLink;
        int timer = 1000;
        private IPlayerState _currentState;

        public IPlayerState CurrentState
        {
            get
            {
                return _currentState;
            }
            set
            {
                _currentState = value;
            }
        }

        public DamagedLink (Player decoratedLink, Game1 game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;
        }
        public override void Update(GameTime gameTime)
        {
            timer--;
            if(timer == 0)
            {
                RemoveDecorator();
            }
            decoratedLink.Update(gameTime);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //CurrentState.Sprite.Draw(spriteBatch, Position);
            decoratedLink.Draw(spriteBatch);
        }
        public override void Move()
        {
            //CurrentState.Move();
            decoratedLink.Move();
        }
        public override void SetState(IPlayerState state)
        {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }
        public void TakeDamage()
        {
            // Does not take damage;
        }
        public void RemoveDecorator()
        {
            game.playerCharacter = decoratedLink;
        }
    }
}
