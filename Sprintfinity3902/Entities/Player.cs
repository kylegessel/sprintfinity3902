using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.States;

namespace Sprintfinity3902.Link
{
    public class Player : AbstractEntity, ILink
    {

        private IState _currentState;

        public IState CurrentState {
            get {
                return _currentState;
            }
            set {
                _currentState = value;
            }
        }
        public IState facingDown { get; set; }
        public IState facingLeft { get; set; }
        public IState facingRight { get; set; }
        public IState facingUp { get; set; }
        public IState facingDownAttack { get; set; }
        public IState facingLeftAttack { get; set; }
        public IState facingRightAttack { get; set; }
        public IState facingUpAttack { get; set; }
        public IState facingDownItem { get; set; }
        public IState facingLeftItem { get; set; }
        public IState facingRightItem { get; set; }
        public IState facingUpItem { get; set; }
        public Color color;

        public Player()
        {
            Position = new Vector2(300, 300);
            CurrentState = new FacingDownState(this);
            facingDown = CurrentState;
            facingLeft = new FacingLeftState(this);
            facingRight = new FacingRightState(this);
            facingUp = new FacingUpState(this);
            facingDownAttack = new FacingDownAttackState(this);
            facingLeftAttack = new FacingLeftAttackState(this);
            facingRightAttack = new FacingRightAttackState(this);
            facingUpAttack = new FacingUpAttackState(this);
            facingDownItem = new FacingDownItemState(this);
            facingLeftItem = new FacingLeftItemState(this);
            facingRightItem = new FacingRightItemState(this);
            facingUpItem = new FacingUpItemState(this);
            color = Color.White;
        }

        public override void SetState(IState state) {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }

        public override void Move() {
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

        public override void Update(GameTime gameTime) {
            CurrentState.Sprite.Update(gameTime);
            CurrentState.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color) {
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
