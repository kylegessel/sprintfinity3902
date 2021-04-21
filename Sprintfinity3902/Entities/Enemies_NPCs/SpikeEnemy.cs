using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.States;

namespace Sprintfinity3902.Entities
{
    public class SpikeEnemy : AbstractEntity, IEnemy
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
        public int EnemyHealth { get; set; }
        public int EnemyAttack { get; set; }

        public int Id { get; set; }

        private SpikeAI spikeAI;

        public SpikeEnemy(Vector2 pos, int spikeId)
        {
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Position = pos;
            Id = spikeId;
            spikeAI = new SpikeAI(this);
            EnemyHealth = 1;
            EnemyAttack = 1;

            horizontalMovingForward = new SpikeHorizontalMovingForwardState(this);
            horizontalMovingBackward = new SpikeHorizontalMovingBackwardState(this);
            verticalMovingForward = new SpikeVerticalMovingForwardState(this);
            verticalMovingBackward = new SpikeVerticalMovingBackwardState(this);
            idleState = new SpikeIdleState(this);

            CurrentState = idleState;

        }

        public override void Update(GameTime gameTime)
        {
            CurrentState.Sprite.Update(gameTime);
            CurrentState.Update();
            spikeAI.Update();
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, Color.White);
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

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            return 1;
        }
    }
}
