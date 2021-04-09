using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.States;
using System;

namespace Sprintfinity3902.Entities
{
    public class GoriyaEnemy : AbstractEntity, IEnemy
    {

        private static int MOD_BOUND = 12;
        private static int THREE = 3;
        private static int SIX = 6;
        private static int NINE = 9;
        private static int ONE = 1;
        private static int FIVE = 5;
        private static int TWO = 2;
        private static int FOUR = 4;

        private IEnemyState _currentState;
        private int direction;
        public IBoomerang Boomerang;
        private GoriyaAI goriyaAI;

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

        public IEnemyState movingDown { get; set; }
        public IEnemyState movingLeft { get; set; }
        public IEnemyState movingRight { get; set; }
        public IEnemyState movingUp { get; set; }
        public IEnemyState itemDown { get; set; }
        public IEnemyState itemLeft { get; set; }
        public IEnemyState itemRight { get; set; }
        public IEnemyState itemUp { get; set; }
        public IEnemyState idleDown { get; set; }
        public IEnemyState idleLeft { get; set; }
        public IEnemyState idleRight { get; set; }
        public IEnemyState idleUp { get; set; }
        public bool done { get; set; }
        private int health;
        private bool decorate;
        private int decorateCount;
        private int decorateTime;
        private int counter;
        
        public GoriyaEnemy(IEntity boomerang, Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaDownEnemy();
            Position = pos;
            color = Color.White;
            Boomerang = (IBoomerang) boomerang;
            goriyaAI = new GoriyaAI(this);
            health = 3;
            decorate = false;
            movingDown = new GoriyaDownMovingState(this);
            movingLeft = new GoriyaLeftMovingState(this);
            movingRight = new GoriyaRightMovingState(this);
            movingUp = new GoriyaUpMovingState(this);
            itemDown = new GoriyaDownItemState(this);
            itemLeft = new GoriyaLeftItemState(this);
            itemRight = new GoriyaRightItemState(this);
            itemUp = new GoriyaUpItemState(this);
            idleDown = new GoriyaDownIdleState(this);
            idleLeft = new GoriyaLeftIdleState(this);
            idleRight = new GoriyaRightIdleState(this);
            idleUp = new GoriyaUpIdleState(this);

            decorateCount = 0;
            decorateTime = 30;


            CurrentState = movingLeft;
            CurrentState.Start = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (done)
            {
                done = false;
                CurrentState.Start = true;
                goriyaAI.Choose();
            }
            else
            {
                CurrentState.Sprite.Update(gameTime);
                CurrentState.Update();
            }

            if (decorate)
            {
                if(decorateCount == decorateTime)
                {
                    decorate = false;
                    color = Color.White;
                    decorateCount = Global.Var.ZERO;
                }
                else
                {
                    Decorate();
                    decorateCount++;
                }
            }

        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            CurrentState.Sprite.Draw(spriteBatch, Position, this.color);
            Boomerang.Draw(spriteBatch, Color.White);
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

        public void SetState(IEnemyState state)
        {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }

        public void ChangeDirection()
        {
            direction = new Random().Next(ONE, FIVE);
            if (direction == ONE) //Left
                this.SetState(movingLeft);
            else if (direction == TWO) //Right
                this.SetState(movingRight);
            else if (direction == THREE) //Up
                this.SetState(movingUp);
            else if (direction == FOUR) //Down
                this.SetState(movingDown);
        }

        public override void Move()
        {
            CurrentState.Move();
        }

        public void UseItem()
        {
            CurrentState.UseItem();
        }

        public void Wait()
        {
            CurrentState.Wait();
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            health = health - damage;
            decorate = true;
            return health;
        }
    }
}
