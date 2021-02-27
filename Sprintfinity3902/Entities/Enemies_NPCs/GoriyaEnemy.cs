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

        private IGoriyaState _currentState;
        private int direction;
        public BoomerangItem Boomerang;
        private GoriyaAI goriyaAI;

        public IGoriyaState CurrentState
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

        public IGoriyaState movingDown { get; set; }
        public IGoriyaState movingLeft { get; set; }
        public IGoriyaState movingRight { get; set; }
        public IGoriyaState movingUp { get; set; }
        public IGoriyaState itemDown { get; set; }
        public IGoriyaState itemLeft { get; set; }
        public IGoriyaState itemRight { get; set; }
        public IGoriyaState itemUp { get; set; }
        public IGoriyaState idleDown { get; set; }
        public IGoriyaState idleLeft { get; set; }
        public IGoriyaState idleRight { get; set; }
        public IGoriyaState idleUp { get; set; }
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

        public void SetState(IGoriyaState state)
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
