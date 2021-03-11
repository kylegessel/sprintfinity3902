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

        private IPlayerState _currentState;

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
            Position = new Vector2(60 * Global.Var.SCALE, 120 * Global.Var.SCALE);
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
            //return new Rectangle(0,0,0,0);
        } 

        public Rectangle getRectangle()
        {
            return new Rectangle((int)X, (int)Y, 16*Global.Var.SCALE, 16 * Global.Var.SCALE);
        }

        /*
        public Rectangle getRectangle()
        {
            return new Rectangle(X, Y, 16 * 5, 16 * 5);
        }
        */

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
