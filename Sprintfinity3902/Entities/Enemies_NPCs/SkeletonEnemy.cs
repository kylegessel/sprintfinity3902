using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class SkeletonEnemy : AbstractEntity
    {
        private Random rd1 = new Random();
        private int count;
        private int direction;
        private int waitTime;
        public SkeletonEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = new Vector2(750, 540);

            direction = rd1.Next(1, 5);
            count = 0;
        }
        public SkeletonEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = pos;

            direction = rd1.Next(1, 5);
            count = 0;
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
                direction = rd1.Next(1, 5);
                count = 0;
            }

            if(direction == 1) //Left
            {
                X = X - 2;
            }
            else if(direction == 2) //Right
            {
                X = X + 2;
            }
            else if(direction == 3) //Up
            {
                Y = Y - 2;
            }
            else if(direction == 4) //Down
            {
                Y = Y + 2;
            }
            count++;
        }
    }
}
