using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using Sprintfinity3902.States;
using System;
using System.Collections.Generic;

namespace Sprintfinity3902.Link
{
    public class Player : AbstractEntity, IPlayer
    {
        /*MAGIC NUMBERS REFACTOR*/
        private static int FIFTEEN = 15;
        private static int TWO_HUNDRED_TWENTY_FOUR  =  224;
        private static int THIRTY_TWO = 32;
        private static int ONE_HUNDRED_NINETY_FOUR = 194;
        private static int NINETY_SIX = 96;
        private static float F_ONE_DOT_FIVE = 1.5f;
        private static int FOURTEEN = 14;
        private static int THIRTEEN = 13;
        private static int ONE_HUNDRED_TWENTY = 120;
        private static int ONE_HUNDRED_NINETY_THREE = 193;
        private static int INITIAL_HEALTH = 6;

        private IPlayerState _currentState;
        private ICollision.CollisionSide _side;
        private int _bouncingOfEnemyCount;
        private Boolean _bouncingOfEnemy;
        private Boolean _collidable;
        private string lowHealthInstanceID;
        private double _deathSpinCount;

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
        public bool heartChanged { get; set; }
        public bool itemPickedUp { get; set; }

        public IPlayer.SelectableWeapons SelectedWeapon { get; set; }

        public int MaxHealth { get; set; }
        public int LinkHealth { get; set; }

        public Dictionary<IItem.ITEMS, int> itemcount { get; set; }

        private Game1 game;

        public Player(Game1 _game)
        {
            game = _game;
            Position = new Vector2(ONE_HUNDRED_TWENTY * Global.Var.SCALE, ONE_HUNDRED_NINETY_THREE * Global.Var.SCALE);
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
            MaxHealth = INITIAL_HEALTH;
            LinkHealth = MaxHealth;
            heartChanged = true;
            itemPickedUp = false;
            lowHealthInstanceID = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_LowHealth), 0.02f, true);
            _deathSpinCount = 0.0;

            itemcount = new Dictionary<IItem.ITEMS, int>();
            foreach (IItem.ITEMS item in Enum.GetValues(typeof(IItem.ITEMS)))
            {
                itemcount.Add(item, 0);
            }
        }

        public void Pickup(IItem item) {


            IPickup itemPickup = item.GetPickup();
            bool win = itemPickup.Pickup(this);

            if (win)
            {
                game.SetState(game.WIN);
            }
        }

        public void SetState(IPlayerState state) {
            if (state.Equals(CurrentState)) return;
            //Vector2 pos = Position;
            CurrentState = state;
            //Position = pos;
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

        public void UseItem(IItem.ITEMS item)
        {

            CurrentState.UseItem();
            if (itemcount.ContainsKey(item) && itemcount[item] > 0)
            {
                itemcount[item]--;
                itemPickedUp = true;
            }
        }

        public override void Update(GameTime gameTime) {
            CurrentState.Sprite.Update(gameTime);  //can this pass out size?
            CurrentState.Update();

            if (_deathSpinCount != 0.0) { 
                _deathSpinCount += gameTime.ElapsedGameTime.TotalMilliseconds;

                switch (((int)(_deathSpinCount / 100.0)) % 4) {
                    case 0:
                        SetState(facingDown);
                        break;
                    case 1:
                        SetState(facingRight);
                        break;
                    case 2:
                        SetState(facingUp);
                        break;
                    case 3:
                        SetState(facingLeft);
                        break;
                }
                return;
            }

            if (_bouncingOfEnemy)
            {
                MoveLink();
                _bouncingOfEnemyCount++;
            }
            if (_bouncingOfEnemyCount > FIFTEEN)
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
            int top = NINETY_SIX * Global.Var.SCALE;
            int bot = ONE_HUNDRED_NINETY_FOUR * Global.Var.SCALE;
            int left = THIRTY_TWO * Global.Var.SCALE;
            int right = TWO_HUNDRED_TWENTY_FOUR * Global.Var.SCALE;
            //If you change the scaler to something larger than 1 Link can get pushed back through walls. 
            //start moving
            if (_side == ICollision.CollisionSide.BOTTOM)
            {
                //Will want this to be an animation. So slower!
                this.Y += F_ONE_DOT_FIVE * Global.Var.SCALE;
                if (this.Y > bot) this.Y = bot;
            }
            else if (_side == ICollision.CollisionSide.LEFT)
            {
                this.X -= F_ONE_DOT_FIVE * Global.Var.SCALE;
                if (this.X < left) this.X = left;
            }
            else if (_side == ICollision.CollisionSide.TOP)
            {
                this.Y -= F_ONE_DOT_FIVE * Global.Var.SCALE;
                if (this.Y < top) this.Y = top;
            }
            else
            {
                this.X += F_ONE_DOT_FIVE * Global.Var.SCALE;
                if (this.X > right) this.X = right;
            }
        }
        public override Rectangle GetBoundingRect()
        {
            //Choose a consistent hitbox for link so that his sword is never counted as a hurtbox.
            return new Rectangle((int)X+Global.Var.SCALE, (int)Y+Global.Var.SCALE, FOURTEEN * Global.Var.SCALE, THIRTEEN * Global.Var.SCALE);
        }

        public override void Draw(SpriteBatch spriteBatch, Color color) {
            CurrentState.Sprite.Draw(spriteBatch, Position, color);
        }
        public void TakeDamage()
        {
            _collidable = false;
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Link_Hurt).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            LinkHealth--;
            heartChanged = true;
            
            if (LinkHealth <= 0) {
                game.SetState(game.LOSE);
                return;
            }

            if (LinkHealth <= 2) {
                playLowHealth();
            }
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
            game.playerCharacter = this;
        }
        public override Boolean IsCollidable()
        {
            return _collidable;
        }
        private void playLowHealth()
        {
            SoundManager.Instance.GetSoundEffectInstance(lowHealthInstanceID).Play();
        }
        private void stopLowHealth()
        {
            SoundManager.Instance.GetSoundEffectInstance(lowHealthInstanceID).Stop();
        }

        public void DeathSpin(bool end)
        {
            if (end) SetState(facingDown);
            _deathSpinCount = end ? 0.0 : 0.01;
        }
    }
}
