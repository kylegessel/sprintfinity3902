using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.States;
using System;

namespace Sprintfinity3902.Entities
{
    public class DigdoggerBoss : AbstractEntity, IEnemy
    {
        private const int UPPER_BOUND = 300;
        private const int LOWER_BOUND = 100;

        private const int LEFT_BOUND = 44;
        private const int RIGHT_BOUND = 185;
        private const int UP_BOUND = 116;
        private const int DOWN_BOUND = 161;

        private const float SPEED = .35f;

        private int count;
        private int random;
        private int direction;
        private int waitTime;
        public float speed;


        private IEnemyState _currentState;
        public IEnemyState CurrentState
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
        public IEnemyState movingLeft { get; set; }
        public IEnemyState movingRight { get; set; }
        public IEnemyState stunned { get; set; }


        public DigdoggerBoss(Vector2 pos)
        {
            Position = pos;

            movingLeft = new DigdoggerMovingLeftState(this);
            movingRight = new DigdoggerMovingRightState(this);

            CurrentState = movingRight;
            CurrentState.Start = true;

            count = 0;
            random = new Random().Next(10, 350);
            speed = SPEED;
            SetStepSize(speed);
        }

        public override void Update(GameTime gameTime)
        {
            Sprite = CurrentState.Sprite;
            CurrentState.Sprite.Update(gameTime);
            CurrentState.Update();
            Move();
            ChangeState();
            
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            CurrentState.Sprite.Draw(spriteBatch, Position, color);
        }

        public void SetState(IEnemyState state)
        {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            int i = 1;
            if (proj.GetType().Equals(typeof(ArrowItem)) && CurrentState == stunned)
            {
                i = 0;
            }
            return i;
        }

        public override void Move()
        {
            CurrentState.Move();
        }    

        private void ChangeState()
        {
            if(count == random)
            {
                random = new Random().Next(50, 350);
                count = -1;
                if (CurrentState == movingLeft)
                    SetState(movingRight);
                else if (CurrentState == movingRight)
                    SetState(movingLeft);
            }
            count++;
        }

    }
}