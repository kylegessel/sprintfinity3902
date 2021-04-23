using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.States;
using System;

namespace Sprintfinity3902.Entities
{
    public class DigdoggerBoss : AbstractEntity, IEnemy
    {
        private const int UPPER_BOUND = 350;
        private const int LOWER_BOUND = 10;

        private const int LEFT_BOUND = 44;
        private const int RIGHT_BOUND = 185;
        private const int UP_BOUND = 116;
        private const int DOWN_BOUND = 161;

        private const int STUNNED_X_OFFSET = 12;
        private const int STUNNED_Y_OFFSET = 16;

        private const int HEALTH = 5;
        private const int ATTACK = 1;
        private const float SPEED = .35f;
        private const float STUNNED_SPEED = .1f;
        private const int DECORATE_TIME = 5;

        private static int THREE = 3;
        private static int SIX = 6;
        private static int NINE = 9;
        private static int MOD_BOUND = 12;

        private int count;
        private int random;
        public float speed;

        public int EnemyHealth { get; set; }
        public int EnemyAttack { get; set; }
        private bool decorate;
        private int decorateCount;
        private int decorateTime;
        private int counter;

        public Game1 Game;


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


        public DigdoggerBoss(Vector2 pos, Game1 game)
        {
            Game = game;
            Position = pos;
            color = Color.White;

            movingLeft = new DigdoggerMovingLeftState(this);
            movingRight = new DigdoggerMovingRightState(this);
            stunned = new DigdoggerStunnedState(this);

            CurrentState = movingRight;
            CurrentState.Start = true;

            count = 0;
            decorateTime = DECORATE_TIME;
            decorate = false;
            random = new Random().Next(LOWER_BOUND, UPPER_BOUND);
            EnemyHealth = HEALTH;
            EnemyAttack = ATTACK;
            speed = SPEED;
            SetStepSize(speed);
        }

        public override void Update(GameTime gameTime)
        {
            Sprite = CurrentState.Sprite;
            CurrentState.Sprite.Update(gameTime);
            CurrentState.Update();
            Move();
            if(CurrentState != stunned)
            {
                ChangeState();
            }
            if (decorate)
            {
                Decorate();
                if (decorateCount == decorateTime)
                {
                    decorate = false;
                    decorateCount = Global.Var.ZERO;
                    color = Color.White;
                }
                decorateCount++;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Color ignoreColor)
        {
            Vector2 position = Position;
            if(CurrentState == stunned)
            {
                position = new Vector2(Position.X + STUNNED_X_OFFSET * Global.Var.SCALE, Position.Y + STUNNED_Y_OFFSET * Global.Var.SCALE);
            }
            CurrentState.Sprite.Draw(spriteBatch, position, color);
        }

        public void SetState(IEnemyState state)
        {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            if (CurrentState == stunned)
            {
                EnemyHealth = EnemyHealth - damage;
                decorate = true;
                decorateCount = Global.Var.ZERO;
                return EnemyHealth;
            }
            else
            {
                return 1;
            }
        }

        public override void Move()
        {
            CurrentState.Move();
        }

        public override Rectangle GetBoundingRect()
        {
            if(CurrentState == stunned)
            {
                return new Rectangle((int)Position.X + STUNNED_X_OFFSET * Global.Var.SCALE, (int)Position.Y + STUNNED_Y_OFFSET * Global.Var.SCALE, CurrentState.Sprite.Animation.CurrentFrame.Width * Global.Var.SCALE, CurrentState.Sprite.Animation.CurrentFrame.Height * Global.Var.SCALE);
            }
            else if (Sprite != null)
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Sprite.Animation.CurrentFrame.Width * Global.Var.SCALE, Sprite.Animation.CurrentFrame.Height * Global.Var.SCALE);
            }
            else
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Global.Var.TILE_SIZE * Global.Var.SCALE, Global.Var.TILE_SIZE * Global.Var.SCALE);
            }
        }

        private void ChangeState()
        {
            if(count == random)
            {
                random = new Random().Next(LOWER_BOUND, UPPER_BOUND);
                count = -1;
                if (CurrentState == movingLeft)
                    SetState(movingRight);
                else if (CurrentState == movingRight)
                    SetState(movingLeft);
            }

            if(Game.PreviousState == Game.FLUTE)
            {
                speed = STUNNED_SPEED;
                SetState(stunned);
            }
            count++;
        }

        public void Decorate()
        {
            counter = decorateCount % MOD_BOUND;
            if (counter < THREE)
            {
                color = Color.Aqua;
            }
            else if (counter < SIX)
            {
                color = Color.Red;
            }
            else if (counter < NINE)
            {
                color = Color.White;
            }
            else
            {
                color = Color.Blue;
            }
        }
    }
}