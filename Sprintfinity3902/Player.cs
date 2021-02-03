using Sprintfinity3902.Sprites;
using Sprintfinity3902.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902
{
    public class Player
    {
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }

        private Game1 _Game;
        public Texture2D PlayerTexture;
        public Vector2 StartingLocation;
        public ISprite playerSprite;
        public IPlayerState currentState;

        IPlayerState facingDown;
        IPlayerState facingLeft;
        IPlayerState facingRight;
        IPlayerState facingUp;
        public Player(Game1 game, Texture2D playerSpriteSheet)
        {
            _Game = game;
            PlayerTexture = playerSpriteSheet;
            StartingLocation = _Game.startingLocation;

            facingDown = new FacingDownState(this);
            facingLeft = new FacingLeftState(this);
            facingRight = new FacingRightState(this);
            facingUp = new FacingUpState(this);
            currentState = facingDown;
        }

        public void setState(IPlayerState state)
        {
            currentState = state;
        }
        public IPlayerState getFacingDownState()
        {
            return facingDown;
        }
        public IPlayerState getFacingRightState()
        {
            return facingRight;
        }
        public IPlayerState getFacingLeftState()
        {
            return facingLeft;
        }
        public IPlayerState getFacingUpState()
        {
            return facingUp;
        }
        public void Move()
        {
            currentState.Move();
        }
        //public int getPositionX()
        //{
            //return CurrentPositionX;
        //}
        public void Update(GameTime gameTime)
        {
            playerSprite = currentState.Sprite;
            playerSprite.Update(gameTime);
        }
        public void setCurrentPositionX(int position)
        {
            facingDown.Sprite.CurrentPositionX = position;
            facingLeft.Sprite.CurrentPositionX = position;
            facingRight.Sprite.CurrentPositionX = position;
            facingUp.Sprite.CurrentPositionX = position;
        }
        public void setCurrentPositionY(int position)
        {
            facingDown.Sprite.CurrentPositionY = position;
            facingLeft.Sprite.CurrentPositionY = position;
            facingRight.Sprite.CurrentPositionY = position;
            facingUp.Sprite.CurrentPositionY = position;
        }

    }
}
