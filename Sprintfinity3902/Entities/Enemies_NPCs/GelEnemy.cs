using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class GelEnemy : AbstractEntity, IEnemy {

        private Random rand;
        private int moveTime;
        private double count;
        private Direction direction;
        private int health;
        private float speed;
        private Boolean wait;

        public GelEnemy()
        {
            rand = new Random();
            moveTime = 72;
            speed = 2f;
            count = 0;
            SetStepSize(speed);
            health = 1;
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
            health = 1;
            Sprite = EnemySpriteFactory.Instance.CreateGelEnemy();
            Position = pos;
        }

        public override void Update(GameTime gameTime) {
            Sprite.Update(gameTime);
            Move();
        }

        public override void Move() {
            if(count == 0)
            {
                moveTime = 8;
            }else if(count == moveTime)
            {
                direction = intToDirection(rand.Next(1, 5));
                count = 0;
                wait = !wait;
            }

            if (!wait)
            {
                moveTime = 8;
            }

            if (wait)
            {
                moveTime = 72;
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
        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection)
        {
            health = health - damage;
            if (stunLength > 0)
            {
                wait = true;
                direction = Direction.NONE;
            }
            // Typical enemy would have code for projectile direction and causing the enemy to move backwards a few times.
            return health;
        }
    }
}
