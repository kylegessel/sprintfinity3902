using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
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
        private Boolean decorated;
        private int enemyID;
        public SkeletonEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = new Vector2(750, 540);
            direction = intToDirection(rd1.Next(1, 5));
            count = 0;
            health = 2;
            speed = 0.4f;
            decorated = false;
            color = Color.White;
        }
        public SkeletonEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = pos;
            direction = intToDirection(rd1.Next(1, 5));
            count = 0;
            health = 2;
            speed = 0.4f;
            decorated = false;
            color = Color.White;
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
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
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

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection)
        {
            health = health - damage;
            this.enemyID = enemyID;
            // This is rough and probably needs to be decorated.
            count = 0;
            waitTime = 30;
            decorated = true;
            direction = projDirection;
            speed = 1f;
            return health;
        }
    }
}
