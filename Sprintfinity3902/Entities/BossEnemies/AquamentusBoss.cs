using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class AquamentusBoss : AbstractEntity, IEnemy
    {

        private static int EIGHTY_FIVE = 85;
        private static int THIRTY = 30;
        private static int FIVE = 5;
        private static int ONE = 1;
        private static int ONE_HUNDRED_FORTY_FIVE = 145;
        private static int TWO =  2;
        private static float F_DOT_FIFTEEN = .15f;
        private static int ONE_HUNDRED_EIGHTY = 180;
        private static int FOUR  = 4;
        private static int THREE  = 3;
        private static int SIXTY = 60;
        private static int ONE_HUNDRED_TWENTY = 120;
        private static int SIX = 6;
        private static int MOD_BOUND = 12;
        private static int NINE = 9;

        private ISprite ClosedMouth;
        private ISprite OpenedMouth;
        public IAttack fireAttackUp;
        public IAttack fireAttackCenter;
        public IAttack fireAttackDown;
        private int decorateCount;
        private int decorateTime;
        private int directionCount;
        private int direction;
        private int attackCount;
        private int attack;
        private int waitTime;
        private int attackTime;
        private int health;
        private int counter;
        private bool decorate;
        private Random rd;
        private string bossScreamInstanceID;

        public int EnemyHealth { get; set; }
        public int EnemyAttack { get; set; }

        public AquamentusBoss(Vector2 pos, IAttack up, IAttack center, IAttack down)
        {
            ClosedMouth = EnemySpriteFactory.Instance.CreateFinalBossClosed();
            OpenedMouth = EnemySpriteFactory.Instance.CreateFinalBossOpened();
            Sprite = ClosedMouth;
            fireAttackUp = up;
            fireAttackCenter = center;
            fireAttackDown = down;
            Position = pos;
            color = Color.White;
            health = FIVE;

            decorateTime = THIRTY;
            decorate = false;

            rd = new Random();

            EnemyHealth = FIVE;
            EnemyAttack = ONE;

            direction = rd.Next(ONE, FOUR);
            directionCount = Global.Var.ZERO;

            attack = rd.Next(ONE, THREE);
            attackTime = EIGHTY_FIVE;

            bossScreamInstanceID = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_Boss_Scream1), 0.02f, false);
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Move();
            if (decorate) Decorate();
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, this.color);                
        }
        public void Decorate()
        {
            counter = directionCount % MOD_BOUND;
            if (counter < THREE)
            {
                color = Color.Aqua;
            }
            else if (counter < SIX)
            {
                color = Color.Red;
            }
            else if (counter < NINE)
            {
                color = Color.White;
            }
            else
            {
                color = Color.Blue;
            }
        }

        public override bool IsCollidable()
        {
            return false;
        }

        public override void Move()
        {
            // Movement of dragon
            if (directionCount == 0)
            {
                waitTime = rd.Next(SIXTY, ONE_HUNDRED_TWENTY);
                directionCount++;
            }
            else if (directionCount == waitTime)
            {
                direction = rd.Next(ONE, FOUR);
                if (attack == ONE)
                    attack = TWO;
                else
                    attack = rd.Next(ONE, THREE);
                directionCount = -1;
            }

            // Handle Movement
            if (direction == ONE && X > ONE_HUNDRED_FORTY_FIVE*Global.Var.SCALE) //Forward
                X = X - F_DOT_FIFTEEN*Global.Var.SCALE;
            else if (direction == TWO && X < ONE_HUNDRED_EIGHTY*Global.Var.SCALE) //Backward
                X = X + F_DOT_FIFTEEN*Global.Var.SCALE;
            
            directionCount++;

            // Handle Attack
            if (attack == ONE)
            {
                Sprite = OpenedMouth;
                attackCount = Global.Var.ZERO;
                fireAttackUp.StartOver(Position);
                fireAttackCenter.StartOver(Position);
                fireAttackDown.StartOver(Position);
                fireAttackUp.StartMoving();
                fireAttackCenter.StartMoving();
                fireAttackDown.StartMoving();
                SoundManager.Instance.GetSoundEffectInstance(bossScreamInstanceID).Play();
            }
            else if (attackCount == attackTime)
            {
                Sprite = ClosedMouth;
                fireAttackUp.StopMoving();
                fireAttackCenter.StopMoving();
                fireAttackDown.StopMoving();

            }
            attackCount++;

            // Handle decorate
            if (decorate)
            {
                if(decorateCount == decorateTime)
                {
                    decorate = false;
                    decorateCount = Global.Var.ZERO;
                    color = Color.White;
                }
                decorateCount++;
            }
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            health = health - damage;
            decorate = true;
            decorateCount = Global.Var.ZERO;
            return health;
        }
    }
}
