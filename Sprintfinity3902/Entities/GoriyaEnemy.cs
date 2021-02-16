using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.States;

namespace Sprintfinity3902.Entities
{
    public class GoriyaEnemy : AbstractEntity {

        private IState _currentState;

        public IState CurrentState
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

        public IState facingDown { get; set; }
        public IState facingLeft { get; set; }
        public IState facingRight { get; set; }
        public IState facingUp { get; set; }
        public IState facingDownItem { get; set; }
        public IState facingLeftItem { get; set; }
        public IState facingRightItem { get; set; }
        public IState facingUpItem { get; set; }
        public Color color;

        public GoriyaEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaDownEnemy();
            Position = new Vector2(700, 500);

            CurrentState = new GoriyaDownState(this);
            facingDown = CurrentState;
            facingLeft = new GoriyaLeftState(this);
            facingRight = new GoriyaRightState(this);
            facingUp = new GoriyaUpState(this);
            facingDownItem = new GoriyaDownItemState(this);
            facingLeftItem = new GoriyaLeftItemState(this);
            facingRightItem = new GoriyaRightItemState(this);
            facingUpItem = new GoriyaUpItemState(this);
        }

        public override void SetState(IState state)
        {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }

        public override void Move()
        {
            CurrentState.Move();
        }

        public override void Attack()
        {
            CurrentState.Attack();
        }

        public void UseItem()
        {
            CurrentState.UseItem();
        }

        public override void Update(GameTime gameTime)
        {
            CurrentState.Sprite.Update(gameTime);
            CurrentState.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            CurrentState.Sprite.Draw(spriteBatch, Position, color);
        }
        public void TakeDamage()
        {
            //Will be needed in future to take away health?
        }
        public void RemoveDecorator()
        {
            //NULL
        }
    }
}
