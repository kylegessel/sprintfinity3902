using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class HandEnemy : AbstractEntity, IEnemy
    {
        private int count;
        private Direction direction;
        private int waitTime;
        private int health;
        private float speed;
        private Boolean decorated;
        private int enemyID;
        public HandEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateHandEnemy();
            Position = new Vector2(750, 540);
            health = 3;
            speed = .2f;
        }
        public HandEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateHandEnemy();
            Position = pos;
            health = 3;
            speed = .2f;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection)
        {
            this.enemyID = enemyID;
            // This is rough and probably needs to be decorated.
            count = 0;
            waitTime = 30;
            decorated = true;
            direction = projDirection;
            speed = 1f;
            return health;
        }

        public override void Move()
        {
            SetStepSize(speed);
            if (count == 0)
            {
                waitTime = new Random().Next(60, 220);
                count++;
            }
            else if (count == waitTime)
            {
                direction = intToDirection(new Random().Next(1, 5));
                speed = 0.2f;
                count = 0;
                if (decorated)
                {
                    CollisionDetector.undecorateList.Add(enemyID);
                    decorated = false;
                }
            }

            if (direction == Direction.LEFT) //Left
            {
                X = X - speed * Global.Var.SCALE;
            }
            else if (direction == Direction.RIGHT) //Right
            {
                X = X + speed * Global.Var.SCALE;
            }
            else if (direction == Direction.UP) //Up
            {
                Y = Y - speed * Global.Var.SCALE;
            }
            else if (direction == Direction.DOWN) //Down
            {
                Y = Y + speed * Global.Var.SCALE;
            }
            count++;
        }
    }
}
