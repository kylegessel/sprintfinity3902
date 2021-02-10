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

namespace Sprintfinity3902
{
    public class Player : AbstractSprite
    {
        private IPlayerState _currentState;

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


        public Texture2D Texture { get; set; }

        public Player(Texture2D playerSpriteSheet)
        {
            Texture = playerSpriteSheet;
            Position = new Vector2(300, 300);

            CurrentState = new FacingDownState(this);

            facingDown = CurrentState;
            facingLeft = new FacingLeftState(this);
            facingRight = new FacingRightState(this);
            facingUp = new FacingUpState(this);
            facingDownAttack = new FacingDownAttackState(this);

        }


        public void setState(IPlayerState state) {
            Vector2 pos = CurrentState.Sprite.Position;
            CurrentState = state;
            CurrentState.Sprite.Position = pos;
        }

        public void Move() {
            CurrentState.Move();
        }

        public override void Update(GameTime gameTime) {
            CurrentState.Sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            CurrentState.Sprite.Draw(spriteBatch);
        }

    }
}
