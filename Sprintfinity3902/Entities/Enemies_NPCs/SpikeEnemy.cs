using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.States;

namespace Sprintfinity3902.Entities
{
    public class SpikeEnemy : AbstractEntity
    {
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
        public IEnemyState horizontalMovingForward { get; set; }
        public IEnemyState horizontalMovingBackward { get; set; }
        public IEnemyState verticalMovingForward { get; set; }
        public IEnemyState verticalMovingBackward { get; set; }
        public IEnemyState idleState { get; set; }

        public int Id { get; set; }
        public SpikeEnemy(Vector2 pos, int spikeId)
        {
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Position = pos;
            Id = spikeId;

            horizontalMovingForward = new SpikeHorizontalMovingForwardState(this);
            horizontalMovingBackward = new SpikeHorizontalMovingBackwardState(this);
            verticalMovingForward = new SpikeVerticalMovingForwardState(this);
            verticalMovingBackward = new SpikeVerticalMovingBackwardState(this);
            idleState = new SpikeIdleState(this);

            CurrentState = verticalMovingForward;

        }

        public override void Update(GameTime gameTime)
        {
            CurrentState.Sprite.Update(gameTime);
            CurrentState.Update();
            //Move();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(Id == 1)
            {
                Sprite.Draw(spriteBatch, Position, Color.White);
            }
            else if (Id == 2)
            {
                Sprite.Draw(spriteBatch, Position, Color.Red);
            }
            else if (Id == 3)
            {
                Sprite.Draw(spriteBatch, Position, Color.Blue);
            }
            else if (Id == 4)
            {
                Sprite.Draw(spriteBatch, Position, Color.Green);
            }
        }

        public void SetState(IEnemyState state)
        {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }

        public override void Move()
        {
            CurrentState.Move();
        }

    }
}
