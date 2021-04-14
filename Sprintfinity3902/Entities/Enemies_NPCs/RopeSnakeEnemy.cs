using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.States;
using System;
namespace Sprintfinity3902.Entities
{
    public class RopeSnakeEnemy : AbstractEntity, IEnemy
    {
        private static int LEFT = 1;
        private static int RIGHT = 2;
        private static int UP = 3;
        private static int DOWN = 4;

        private static float NORMSPEED = .4f;
        private static float DARTSPEED = 1.5f;


        private IEnemyState _currentState;
        private int distance;
        

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
        public IEnemyState movingUpFacingLeft { get; set; }
        public IEnemyState movingUpFacingRight { get; set; }
        public IEnemyState movingDownFacingLeft { get; set; }
        public IEnemyState movingDownFacingRight { get; set; }
        public bool done { get; set; }
        public bool dart { get; set; }
        public float Speed { get; set; }
        public float dartDist { get; set; }
        public int direction { get; set; }

        private RopeSnakeAI ropesnakeAI;

        public RopeSnakeEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateRopeSnakeRightEnemy();
            movingRight = new RopeSnakeMovingRightState(this);
            movingLeft = new RopeSnakeMovingLeftState(this);
            movingDownFacingRight = new RopeSnakeMovingDownFacingRightState(this);
            movingDownFacingLeft = new RopeSnakeMovingDownFacingLeftState(this);
            movingUpFacingRight = new RopeSnakeMovingUpFacingRightState(this);
            movingUpFacingLeft = new RopeSnakeMovingUpFacingLeftState(this);
            CurrentState = movingRight;
            Position = pos;
            Speed = NORMSPEED;
            direction = RIGHT;
            ropesnakeAI = new RopeSnakeAI(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (done)
            {
                done = false;
                ChangeDirection();
                CurrentState.Start = true;
            }
                
            else
            {
                CurrentState.Sprite.Update(gameTime);
                CurrentState.Update();
                ropesnakeAI.Update();
            }

            if (dart && dartDist > distance)
                EndDart();
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            CurrentState.Sprite.Draw(spriteBatch, Position, color);
        }

        public void ChangeDirection()
        {
                direction = new Random().Next(LEFT, DOWN + 1);
                if (direction == LEFT)
                    SetState(movingLeft);
                else if (direction == RIGHT)
                    SetState(movingRight);
                else if (direction == UP) /* I may want to base these on previouse state or if they are on a wall */
                {
                    int facing = new Random().Next(LEFT, RIGHT + 1);
                    if (facing == LEFT)
                        SetState(movingUpFacingLeft);
                    else
                        SetState(movingUpFacingRight);
                }
                else if (direction == DOWN)
                {
                    int facing = new Random().Next(LEFT, RIGHT + 1);
                    if (facing == LEFT)
                        SetState(movingDownFacingLeft);
                    else
                        SetState(movingDownFacingRight);
            }
        }

        int IEnemy.HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            return 0;
        }
        public void SetState(IEnemyState state)
        {
            /*Position Logic seems counterintuitive. Whats the reasoning here*/
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }
        public override void Move()
        {
            CurrentState.Move();
        }

        public void BeginDart(int dist)
        {
            dartDist = 0;
            distance = dist;
            dart = true;
            Speed = DARTSPEED;
        }
        public void EndDart()
        {
            Speed = NORMSPEED;
            dart = false;
        }
    }
}
