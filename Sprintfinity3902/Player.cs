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
        public IPlayerState facingDown { get; set; }
        public IPlayerState facingLeft { get; set; }
        public IPlayerState facingRight { get; set; }
        public IPlayerState facingUp { get; set; }

        public Texture2D PlayerTexture;
        public Vector2 StartingLocation;
        public ISprite playerSprite;
        public IPlayerState currentState;

        public Player(Texture2D playerSpriteSheet)
        {
            PlayerTexture = playerSpriteSheet;
            StartingLocation = new Vector2(363, 195);

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

        public void Move()
        {
            currentState.Move();
        }

        public void Update(GameTime gameTime)
        {
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
