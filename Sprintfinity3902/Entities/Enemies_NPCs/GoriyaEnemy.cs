using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.States;
using System;

namespace Sprintfinity3902.Entities
{
    public class GoriyaEnemy : AbstractEntity
    {

        private IEnemyState _currentState;
        private int direction;
        public BoomerangItem Boomerang;
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
        public Color color;

        public GoriyaEnemy(BoomerangItem boomerang)
        {
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaDownEnemy();
            Position = new Vector2(750, 540);
            color = Color.White;
            Boomerang = boomerang;
            goriyaAI = new GoriyaAI(this);

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

            CurrentState = movingLeft;
            CurrentState.Start = true;
        }
        public GoriyaEnemy(BoomerangItem boomerang, Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaDownEnemy();
            Position = pos;
            color = Color.White;
            Boomerang = boomerang;
            goriyaAI = new GoriyaAI(this);

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
                Boomerang.Update(gameTime);
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            CurrentState.Sprite.Draw(spriteBatch, Position, color);
            Boomerang.Draw(spriteBatch);
        }

        public void SetState(IEnemyState state)
        {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }

        public void ChangeDirection()
        {
            direction = new Random().Next(1, 5);
            if (direction == 1) //Left
                this.SetState(movingLeft);
            else if (direction == 2) //Right
                this.SetState(movingRight);
            else if (direction == 3) //Up
                this.SetState(movingUp);
            else if (direction == 4) //Down
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

    }
}
