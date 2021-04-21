using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class GelEnemy : AbstractEntity, IEnemy {

        private static int SEVENTY_TWO = 72;
        private static int EIGHT = 8;
        private static int ONE = 1;
        private static int FIVE = 5;

        private Random rand;
        private int moveTime;
        private double count;
        private Direction direction;
        private int health;
        private float speed;
        private Boolean wait;
        public int EnemyHealth { get; set; }
        public int EnemyAttack { get; set; }

        public GelEnemy()
        {
            rand = new Random();
            moveTime = 72;
            speed = 2f;
            count = 0;
            SetStepSize(speed);
            EnemyHealth = 1;
            Sprite = EnemySpriteFactory.Instance.CreateGelEnemy();
            Position = new Vector2(750, 540);
        }
        public GelEnemy(Vector2 pos)
        {
            rand = new Random();
            moveTime = 72; 
            count = 0;
            speed = 2f;
            SetStepSize(speed);
            EnemyHealth = 1;
            Sprite = EnemySpriteFactory.Instance.CreateGelEnemy();
            Position = pos;
        }

        public override void Update(GameTime gameTime) {
            Sprite.Update(gameTime);
            Move();
        }

        public override void Move() {
            if(count == Global.Var.ZERO)
            {
                moveTime = EIGHT;
            }else if(count == moveTime)
            {
                direction = intToDirection(rand.Next(ONE, FIVE));
                count = Global.Var.ZERO;
                wait = !wait;
            }

            if (!wait)
            {
                moveTime = EIGHT;
            }

            if (wait)
            {
                moveTime = SEVENTY_TWO;
                direction = Direction.NONE;
            }

            switch (direction)
            {
                case (Direction.LEFT):
                    X = X - speed * Global.Var.SCALE;
                    break;
                case (Direction.RIGHT):
                    X = X + speed * Global.Var.SCALE;
                    break;
                case (Direction.UP):
                    Y = Y - speed * Global.Var.SCALE;
                    break;
                case (Direction.DOWN):
                    Y = Y + speed * Global.Var.SCALE;
                    break;
                case (Direction.NONE):
                        break;
            }

            count++;
        }
        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            EnemyHealth = EnemyHealth - damage;
            if (stunLength > Global.Var.ZERO)
            {
                wait = true;
                direction = Direction.NONE;
            }
            // Typical enemy would have code for projectile direction and causing the enemy to move backwards a few times.
            return EnemyHealth;
        }
    }
}
