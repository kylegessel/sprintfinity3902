using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.States;
using System;

namespace Sprintfinity3902.Entities
{
    public class GoriyaEnemy : AbstractEntity {

        private IState _currentState;
        private int waitTime;
        private int count;
        private int direction;
        private bool isMoving;
        private bool isWaiting;
        private bool isThrowing;
        private bool start;
        private int choice;
        

        public IState CurrentState
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

        public IState facingDown { get; set; }
        public IState facingLeft { get; set; }
        public IState facingRight { get; set; }
        public IState facingUp { get; set; }
        public IState facingDownItem { get; set; }
        public IState facingLeftItem { get; set; }
        public IState facingRightItem { get; set; }
        public IState facingUpItem { get; set; }
        public Color color;

        public GoriyaEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaDownEnemy();
            Position = new Vector2(700, 500);
            waitTime = new Random().Next(200);
            count = 0;
            color = Color.White;
            isMoving = false;
            isWaiting = false;
            isThrowing = false;

            facingDown = new GoriyaDownState(this);
            facingLeft = new GoriyaLeftState(this);
            facingRight = new GoriyaRightState(this);
            facingUp = new GoriyaUpState(this);
            facingDownItem = new GoriyaDownItemState(this);
            facingLeftItem = new GoriyaLeftItemState(this);
            facingRightItem = new GoriyaRightItemState(this);
            facingUpItem = new GoriyaUpItemState(this);

            CurrentState = facingLeft;
        }

        public override void SetState(IState state)
        {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }

        public override void Move()
        {
            if (start)
            {
                count = 0;
                start = false;
            }

            if (count == 100)
            {
                isMoving = false;
                CurrentState.Sprite.Animation.Stop();
            }

            if (isMoving)
            {
                CurrentState.Move();
                count++;
            }


        }

        public void UseItem()
        {
            if (start)
            {
                count = 0;
                start = false;

                if (CurrentState == facingDown)
                    CurrentState = facingDownItem;
                else if (CurrentState == facingUp)
                    CurrentState = facingUpItem;
                else if (CurrentState == facingRight)
                    CurrentState = facingRightItem;
                else if (CurrentState == facingLeft)
                    CurrentState = facingLeftItem;
            }

            if (count == 100)
            {
                isThrowing = false;

                if (CurrentState == facingDownItem)
                    CurrentState = facingDown;
                else if (CurrentState == facingUpItem)
                    CurrentState = facingUp;
                else if (CurrentState == facingRightItem)
                    CurrentState = facingRight;
                else if (CurrentState == facingLeftItem)
                    CurrentState = facingLeft;
            }

            if (isThrowing)
            {
                CurrentState.UseItem();
                count++;
            }
        }

        public void Wait()
        {
            if (start)
            {
                count = 0;
                start = false;
            }

            if (count == 30)
            {
                isWaiting = false;
            }

            if (isWaiting)
            {
                count++;
            }

        }

        public override void Update(GameTime gameTime)
        {
            CurrentState.Sprite.Update(gameTime);
            CurrentState.Update();

            // Change values and then call change direction or move accordingly
            if (isMoving)
                Move();
            else if (isThrowing)
                UseItem();
            else if (isWaiting)
                Wait();
            else
                Choose();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            CurrentState.Sprite.Draw(spriteBatch, Position, color);
        }

        public void Choose()
        {
            choice = new Random().Next(1, 5);
            if(choice == 1)
            {
                isMoving = true;
                start = true;
            }
            else if(choice == 2)
            {
                isThrowing = true;
                start = true;
            }
            else if (choice == 3)
            {
                isWaiting = true;
                start = true;
            }
            else if (choice == 4)
            {
                ChangeDirection();
            }
        }

        public void ChangeDirection()
        {
            
                direction = new Random().Next(1, 5);
                if (direction == 1) //Left
                {
                    this.SetState(facingLeft);
                }
                else if (direction == 2) //Right
                {
                    this.SetState(facingRight);
                }
                else if (direction == 3) //Up
                {
                    this.SetState(facingUp);
                }
                else if (direction == 4) //Down
                {
                    this.SetState(facingDown);
                }
            
        }

        public void TakeDamage()
        {
            //Will be needed in future to take away health?
        }
        public void RemoveDecorator()
        {
            //NULL
        }
    }
}
