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
        private static int FOURTEEN = 14;
        private static int THIRTEEN = 13;
        private static int ONE_HUNDRED_TWENTY = 120;
        private static int ONE_HUNDRED_NINETY_THREE = 193;
        private static int INITIAL_HEALTH = 10;

        private IPlayerState _currentState;
        private ICollision.CollisionSide _side;
        private int _bouncingOfEnemyCount;
        private Boolean _bouncingOfEnemy;
        private Boolean _collidable;
        private string lowHealthInstanceID;
        private double _deathSpinCount;
        private LinkMovementManager movementManager;

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
            movementManager = new LinkMovementManager(this);
            color = Color.White;
            _collidable = true;
            SetStepSize(1);
            MaxHealth = INITIAL_HEALTH;
            LinkHealth = MaxHealth;
            lowHealthInstanceID = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_LowHealth), 0.02f, true);
            _deathSpinCount = 0.0;
            SelectedWeapon = IPlayer.SelectableWeapons.NONE;

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
            CurrentState = state;
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
                HudMenu.InGameHud.Instance.UpdateItems(itemcount[IItem.ITEMS.RUPEE], itemcount[IItem.ITEMS.KEY], itemcount[IItem.ITEMS.BOMB]);
            }
            if (itemcount[IItem.ITEMS.BOMB] == 0)
            {
                HudMenu.InventoryHud.Instance.RemoveItemInInventory(IPlayer.SelectableWeapons.BOMB);
                SelectedWeapon = IPlayer.SelectableWeapons.NONE;
                HudMenu.InGameHud.Instance.UpdateSelectedItems(SelectedWeapon);
            }
            if(itemcount[IItem.ITEMS.BOMB] == 0 && itemcount[IItem.ITEMS.BOOMERANG] == 0 && itemcount[IItem.ITEMS.BOW] == 0)
            {
                SelectedWeapon = IPlayer.SelectableWeapons.NONE;
                HudMenu.InGameHud.Instance.UpdateSelectedItems(SelectedWeapon);
            }
        }

        public override void Update(GameTime gameTime) {
            CurrentState.Sprite.Update(gameTime); 
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
                movementManager.MoveLink(_side);
                _bouncingOfEnemyCount++;
            }
            if (_bouncingOfEnemyCount > FIFTEEN)
            {
                _bouncingOfEnemy = false;
                _bouncingOfEnemyCount = 0;
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
            HudMenu.InGameHud.Instance.UpdateHearts(MaxHealth, LinkHealth);
            
            if (LinkHealth <= 0) {
                game.SetState(game.LOSE);
                return;
            }

            if (LinkHealth <= 2) {
                PlayLowHealth();
            }
        }

        public void BounceOfEnemy(ICollision.CollisionSide Side)
        {
            _side = Side;
            _bouncingOfEnemy = true;
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
        private void PlayLowHealth()
        {
            SoundManager.Instance.GetSoundEffectInstance(lowHealthInstanceID).Play();
        }
        public void StopLowHealth()
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
