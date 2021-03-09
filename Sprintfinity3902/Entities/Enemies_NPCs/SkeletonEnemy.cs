using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class SkeletonEnemy : AbstractEntity, IEnemy
    {
        private Random rd1 = new Random();
        private int count;
        private Direction direction;
        private int waitTime;
        private int health;
        private float speed;
        public SkeletonEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = new Vector2(750, 540);
            direction = intToDirection(rd1.Next(1, 5));
            count = 0;
            health = 2;
            speed = 0.4f;
        }
        public SkeletonEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = pos;
            direction = intToDirection(rd1.Next(1, 5));
            count = 0;
            health = 2;
            speed = 0.4f;
        }

        public Direction intToDirection(int dir)
        {
            switch (rd1.Next(1, 5))
            {
                case 1:
                    return Direction.LEFT;
                case 2:
                    return Direction.RIGHT;
                case 3:
                    return Direction.UP;
                case 4:
                    return Direction.DOWN;
            }
            return Direction.NONE;
        }
        public override void Update(GameTime gameTime) {
            Sprite.Update(gameTime);
            Move();
        }

        public override void Move()
        {
            
            if(count == 0)
            {
                waitTime = rd1.Next(40, 240);
                count++;
            }
            else if(count == waitTime)
            {
                direction = intToDirection(rd1.Next(1, 5));
                count = 0;
                speed = 0.4f;
            }

            if (direction == Direction.LEFT) //Left
            {
                X = X - speed * Global.Var.SCALE;
            }
            else if(direction == Direction.RIGHT) //Right
            {
                X = X + speed * Global.Var.SCALE;
            }
            else if(direction == Direction.UP) //Up
            {
                Y = Y - speed * Global.Var.SCALE;
            }
            else if(direction == Direction.DOWN) //Down
            {
                Y = Y + speed * Global.Var.SCALE;
            }
            count++;
        }

        public int HitRegister(int damage, int stunLength, Direction projDirection)
        {
            health = health - damage;
            // This is rough and probably needs to be decorated.
            count = 0;
            waitTime = 30;
            direction = projDirection;
            speed = 1f;
            return health;
        }
    }
}
