using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.States;
using System;
using System.Collections.Generic;

namespace Sprintfinity3902.Link
{
    public class Player : AbstractEntity, ILink
    {
        int MAX_HEALTH = 6; //May want this as global variable for other logic in future. (Like projectiles/ getting more health)
        private IPlayerState _currentState;
        private ICollision.CollisionSide _side;
        private int _bouncingOfEnemyCount;
        private Boolean _bouncingOfEnemy;
        private Boolean _collidable;
        private int linkHealth;

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

        private Dictionary<IItem.ITEMS, int> itemcount;

        public Player()
        {
            Position = new Vector2(120 * Global.Var.SCALE, 193 * Global.Var.SCALE);
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
            _collidable = true;
            SetStepSize(1);
            linkHealth = MAX_HEALTH;

            itemcount = new Dictionary<IItem.ITEMS, int>();
        }

        public void pickup(IItem.ITEMS item) {
            if (itemcount.ContainsKey(item)) {
                itemcount[item]++;
                return ;
            }
            itemcount.Add(item, 1);
        }

        public void useItem(IItem.ITEMS item) {
            if (itemcount.ContainsKey(item) && itemcount[item] > 0) {
                itemcount[item]--;
                return ;
            } 
            // Not enough quantity or any
            /* TODO: Implmt err control */
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
            if (_bouncingOfEnemyCount > 15)
            {
                StopMoving();
            }
            //return new Rectangle(0,0,0,0);
        }

        public void StopMoving()
        {
            _bouncingOfEnemy = false;
            _bouncingOfEnemyCount = 0;
            //resume animation
            //allow move commands to start again
        }

        //Will probably need to insert logic to prevent going through walls.
        public void MoveLink()
        {
                //If you change the scaler to something larger than 1 Link can get pushed back through walls. 
                //start moving
                if (_side == ICollision.CollisionSide.BOTTOM)
                {
                    //Will want this to be an animation. So slower!
                    this.Y += (float)1.5 * Global.Var.SCALE;
                }
                else if (_side == ICollision.CollisionSide.LEFT)
                {
                    this.X -= (float)1.5 * Global.Var.SCALE;
                }
                else if (_side == ICollision.CollisionSide.TOP)
                {
                    this.Y -= (float)1.5 * Global.Var.SCALE;
                }
                else
                {
                    this.X += (float)1.5 * Global.Var.SCALE;
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
            _collidable = false;
            linkHealth--;
        }

        public void BounceOfEnemy(ICollision.CollisionSide Side)
        {
            _side = Side;
            _bouncingOfEnemy = true;
            /*
             * May need to:
             * Pause animation;
             * Stop accepting move input keys for link
             */

        }
        public void RemoveDecorator()
        {
            _collidable = true;
        }
        public override Boolean IsCollidable()
        {
            return _collidable;
        }
    }
}
