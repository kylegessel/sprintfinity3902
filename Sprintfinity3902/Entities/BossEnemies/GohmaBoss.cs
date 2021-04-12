using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.States;
using System;

namespace Sprintfinity3902.Entities
{
    public class GohmaBoss : AbstractEntity, IEnemy
    {
        private const int UPPER_BOUND = 300;
        private const int LOWER_BOUND = 100;

        private const int FORWARD = 1;
        private const int BACKWARD = 2;
        private const int LEFT = 3;
        private const int RIGHT = 4;

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
        public IEnemyState closedEye { get; set; }
        public IEnemyState openedEye { get; set; }
        public IAttack fireAttack { get; set; }
        public int attackCount { get; set; }

        public GohmaBoss(Vector2 pos)
        {
            Position = pos;

            closedEye = new GohmaClosedEyeState(this);
            openedEye = new GohmaOpenedEyeState(this);

            CurrentState = closedEye;
            CurrentState.Start = true;

            direction = LEFT;
            count = 0;
            attackCount = 0;
            speed = SPEED;
            SetStepSize(speed);
        }

        public GohmaBoss(Vector2 pos, IAttack fire)
        {
            Position = pos;

            fireAttack = fire;
            attackCount = 0;

            closedEye = new GohmaClosedEyeState(this);
            openedEye = new GohmaOpenedEyeState(this);

            CurrentState = closedEye;
            CurrentState.Start = true;

            direction = LEFT;
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
            if (proj.GetType().Equals(typeof(ArrowItem)) && CurrentState == openedEye)
            {
                i = 0;
            }
            return i;
        }

        public override void Move()
        {
            if (count == 0)
            {
                waitTime = rand.Next(LOWER_BOUND, UPPER_BOUND);
            }
            else if (count == waitTime)
            {
                direction = rand.Next(FORWARD, RIGHT+1);
                count = 0;
            }

            if (X <= LEFT_BOUND * Global.Var.SCALE)
            {
                direction = RIGHT;
            }
            else if (X >= RIGHT_BOUND * Global.Var.SCALE)
            {
                direction = LEFT;
            }

            switch (direction)
            {
                // Moving forward
                case FORWARD:
                    if (Y > DOWN_BOUND * Global.Var.SCALE)
                    {
                        direction = BACKWARD;
                        count = -1;
                    }
                    else { Y = Y + speed * Global.Var.SCALE; }
                    break;
                // Moving backward
                case BACKWARD:
                    if (Y < UP_BOUND * Global.Var.SCALE)
                    {
                        direction = new Random().Next(LEFT, RIGHT + 1);
                        count = -1;
                    }
                    else { Y = Y - speed * Global.Var.SCALE; }
                    break;
                // Moving left
                case LEFT:
                    X = X - speed * Global.Var.SCALE;
                    break;
                // Moving right
                case RIGHT:
                    X = X + speed * Global.Var.SCALE;
                    break;
            }
            count++;
        }

    }
}
