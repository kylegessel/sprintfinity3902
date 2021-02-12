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
    public class Player : AbstractEntity
    {

        private IPlayerState _currentState;
        Game1 game;

        public IPlayerState CurrentState {
            get {
                return _currentState;
            }
            set {
                _currentState = value;
            }
        }
        public IPlayerState facingDown { get; set; }
        public IPlayerState facingLeft { get; set; }
        public IPlayerState facingRight { get; set; }
        public IPlayerState facingUp { get; set; }
        public IPlayerState facingDownAttack { get; set; }
        public Player link { get; set; }
        //Not sure if I need the Above
        public Player(Player link, Game1 game)
        {
            Position = new Vector2(300, 300);
            CurrentState = new FacingDownState(this);
            facingDown = CurrentState;
            facingLeft = new FacingLeftState(this);
            facingRight = new FacingRightState(this);
            facingUp = new FacingUpState(this);
            facingDownAttack = new FacingDownAttackState(this);
            this.game = game;
            this.link = link;

        }


        public override void SetState(IPlayerState state) {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }

        public override void Move() {
            CurrentState.Move();
        }

        public override void Update(GameTime gameTime) {
            CurrentState.Sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            CurrentState.Sprite.Draw(spriteBatch, Position);
        }
        public void TakeDamage()
        {
            
        }
        public void RemoveDecorator()
        {
            //Not in Damaged State
        }

    }
}
