using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.States;
using System;

namespace Sprintfinity3902.Link
{
    public class Player : AbstractEntity, ILink
    {

        private IPlayerState _currentState;
        private ICollision.CollisionSide _side;
        private int _bouncingOfEnemyCount;
        private Boolean _bouncingOfEnemy;

        public IPlayerState CurrentState {
            get {
                return _currentState;
            }
            set {
                _currentState = value;
            }
        }
        public IPlayerState facingDown { get; set; }
        public IPlayerState facingLeft { get; set; }
        public IPlayerState facingRight { get; set; }
        public IPlayerState facingUp { get; set; }
        public IPlayerState facingDownAttack { get; set; }
        public IPlayerState facingLeftAttack { get; set; }
        public IPlayerState facingRightAttack { get; set; }
        public IPlayerState facingUpAttack { get; set; }
        public IPlayerState facingDownItem { get; set; }
        public IPlayerState facingLeftItem { get; set; }
        public IPlayerState facingRightItem { get; set; }
        public IPlayerState facingUpItem { get; set; }

        public Color color;

        public Player()
        {
            Position = new Vector2(60 *Global.Var.SCALE, 120*Global.Var.SCALE);
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

        public override void SetState(IPlayerState state) {
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
            CurrentState.Sprite.Update(gameTime);  //can this pass out size?
            CurrentState.Update();

            if (_bouncingOfEnemy)
            {
                MoveLink();
                _bouncingOfEnemyCount++;
            }
            if (_bouncingOfEnemyCount > 20)
            {
                StopMoving();
            }
            //return new Rectangle(0,0,0,0);
        }

        public void StopMoving()
        {
            _bouncingOfEnemy = false;
            //resume animation
            //allow move commands to start again
        }
        public void MoveLink()
        {
                //start moving

                if (_side == ICollision.CollisionSide.BOTTOM)
                {
                    //Will want this to be an animation. So slower!
                    this.Y -= Global.Var.SCALE;
                }
                else if (_side == ICollision.CollisionSide.LEFT)
                {
                    this.X -= Global.Var.SCALE;
                }
                else if (_side == ICollision.CollisionSide.TOP)
                {
                    this.Y += Global.Var.SCALE;
                }
                else
                {
                    this.X -=  Global.Var.SCALE;
                }
        }
        public Rectangle getRectangle()
        {
            return new Rectangle((int)X, (int)Y, 16*Global.Var.SCALE, 16 * Global.Var.SCALE);
        }

        public void Draw(SpriteBatch spriteBatch, Color color) {
            CurrentState.Sprite.Draw(spriteBatch, Position, color);
        }
        public void TakeDamage()
        {
            /*
            BecomeInvincible();
            if (!_invincible) //Do nothing if he is invincible
            {
                //TODO: Remove Health from Link
            }
            */
        }

        public void BounceOfEnemy(ICollision.CollisionSide Side)
        {
            _side = Side;
            //Pause animation;
            //Stop accepting move input keys for link
            _bouncingOfEnemy = true;
        }
        public void RemoveDecorator()
        {
            //NULL
        }
    }
}
