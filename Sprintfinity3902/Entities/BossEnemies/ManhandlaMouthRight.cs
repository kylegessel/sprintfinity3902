using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class ManhandlaMouthRight : AbstractEntity, IEnemy
    {
        private static int STARTING_HEALTH = 6;
        private static int TIME_DECORATED = 30;
        private static int MOD_BOUND = 12;
        private static int THREE = 3;
        private static int SIX = 6;
        private static int NINE = 9;
        private const int RANDOM_UP_BOUND = 140;
        private const int RANDOM_DOWN_BOUND = 80;

        private int decorateCount;
        private int decorateTime;
        private bool decorate;
        private int counter;
        private ManhandlaBoss Manhandla;

        public int health { get; set; }
        private IAttack fireAttack;
        private int attackCount;
        private int random;
        public int EnemyHealth { get; set; }
        public int EnemyAttack { get; set; }

        public ManhandlaMouthRight(Vector2 pos, IAttack fire)
        {
            Sprite = EnemySpriteFactory.Instance.CreateManhandlaRightMouth();
            Position = pos;
            fireAttack = fire;
            health = STARTING_HEALTH;
            EnemyHealth = STARTING_HEALTH;
            EnemyAttack = 1;
            decorateTime = TIME_DECORATED;
            decorate = false;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Attack();
            if (decorate)
            {
                Decorate();
                if (decorateCount == decorateTime)
                {
                    decorate = false;
                    decorateCount = Global.Var.ZERO;
                    color = Color.White;
                }
                decorateCount++;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 pos, Color color)
        {
            if (health > 0)
            {
                Position = pos;
                X = X + 17 * Global.Var.SCALE;
                Sprite.Draw(spriteBatch, Position, this.color);
            }
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            health = health - damage;
            decorate = true;
            decorateCount = Global.Var.ZERO;
            if (health <= 0)
            {
                Manhandla.IncreaseSpeed();
            }
            return health;
        }

        public void Decorate()
        {
            counter = decorateCount % MOD_BOUND;
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

        public void GiveManhandla(ManhandlaBoss man)
        {
            Manhandla = man;
        }

        public override void Attack()
        {
            if (attackCount == 0)
            {
                Vector2 startPosition = new Vector2(X + Global.Var.HALF_TILE_SIZE * Global.Var.SCALE, Y + Global.Var.HALF_TILE_SIZE * Global.Var.SCALE);
                fireAttack.StartOver(startPosition);
                fireAttack.StartMoving();
                random = new Random().Next(RANDOM_DOWN_BOUND, RANDOM_UP_BOUND);
            }
            else if (attackCount == random)
            {
                fireAttack.StopMoving();
                attackCount = -1;
            }
            else
            {
                fireAttack.Move();
            }
            attackCount++;
        }
    }
}
