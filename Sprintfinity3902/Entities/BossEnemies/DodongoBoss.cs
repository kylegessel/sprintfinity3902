using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.States;
using System;

namespace Sprintfinity3902.Entities
{
    public class DodongoBoss : AbstractEntity, IEnemy
    {
        private const int UPPER_BOUND = 274;
        private const int LOWER_BOUND = 86;

        private const int FORWARD = 1;
        private const int BACKWARD = 2;
        private const int LEFT = 3;
        private const int RIGHT = 4;

        private const int LEFT_BOUND = 34;
        private const int RIGHT_BOUND = 192;
        private const int UP_BOUND = 96;
        private const int DOWN_BOUND = 190;

        private const float SPEED = .65f;

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
        public IEnemyState frontMoving { get; set; }
        public IEnemyState backMoving { get; set; }
        public IEnemyState leftMoving { get; set; }
        public IEnemyState rightMoving { get; set; }
        public IEnemyState frontDamaged { get; set; }
        public IEnemyState backDamaged { get; set; }
        public IEnemyState leftDamaged { get; set; }
        public IEnemyState rightDamaged { get; set; }


        public DodongoBoss(Vector2 pos)
        {
            Position = pos;

            frontMoving = new DodongoFrontMovingState(this);
            backMoving = new DodongoBackMovingState(this);
            leftMoving = new DodongoLeftMovingState(this);
            rightMoving = new DodongoRightMovingState(this);
            frontDamaged = new DodongoFrontDamagedState(this);
            backDamaged = new DodongoBackDamagedState(this);
            leftDamaged = new DodongoLeftDamagedState(this);
            rightDamaged = new DodongoRightDamagedState(this);

            CurrentState = leftMoving;
            CurrentState.Start = true;

            direction = LEFT;
            count = 0;
            speed = SPEED;
            SetStepSize(speed);
        }

        public override void Update(GameTime gameTime)
        {
            if (CollisionDetector.Instance.CollidesWithBomb(GetBoundingRect()))
            {
                CurrentState.Update();
            }
            else
            {
                Move();
            }
            Sprite = CurrentState.Sprite;
            CurrentState.Sprite.Update(gameTime);
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
            return 0;
        }

        public override void Move()
        {
            if (count == 0)
            {
                waitTime = rand.Next(LOWER_BOUND, UPPER_BOUND);
            }
            else if (count == waitTime)
            {
                direction = rand.Next(FORWARD, RIGHT + 1);
                count = 0;
            }

            switch (direction)
            {
                case FORWARD:
                    if(CurrentState != frontMoving) { SetState(frontMoving); }
                    if (Y >= DOWN_BOUND * Global.Var.SCALE)
                    {
                        direction = new Random().Next(BACKWARD, RIGHT+1);
                        count = -1;
                    }
                    else { Y = Y + speed * Global.Var.SCALE; }
                    break;
                case BACKWARD:
                    if (CurrentState != backMoving) { SetState(backMoving); }
                    if (Y <= UP_BOUND * Global.Var.SCALE)
                    {
                        direction = new Random().Next(FORWARD, RIGHT + 1);
                        count = -1;
                    }
                    else { Y = Y - speed * Global.Var.SCALE; }
                    break;
                case LEFT:
                    if (CurrentState != leftMoving) { SetState(leftMoving); }
                    if (X <= LEFT_BOUND * Global.Var.SCALE)
                    {
                        direction = new Random().Next(FORWARD, RIGHT+1);
                        count = -1;
                    }
                    X = X - speed * Global.Var.SCALE;
                    break;
                case RIGHT:
                    if (CurrentState != rightMoving) { SetState(rightMoving); }
                    if (X >= RIGHT_BOUND * Global.Var.SCALE)
                    {
                        direction = new Random().Next(FORWARD, RIGHT+1);
                        count = -1;
                    }
                    X = X + speed * Global.Var.SCALE;
                    break;
            }
            count++;
        }

    }
}