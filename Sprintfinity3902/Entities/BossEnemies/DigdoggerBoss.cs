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

        private const float SPEED = .5f;

        private Random rand = new Random();
        private int count;
        private int direction;
        private int waitTime;
        private float speed;


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


            CurrentState = movingLeft;
            CurrentState.Start = true;

            count = 0;
            speed = SPEED;
            SetStepSize(speed);
        }

        public override void Update(GameTime gameTime)
        {
            Sprite = CurrentState.Sprite;
            CurrentState.UseItem();
            CurrentState.Sprite.Update(gameTime);
            CurrentState.Update();
            Move();
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

    }
}