using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class SkeletonEnemy : AbstractEntity
    {
        /*It's not good practice to assign variable outside constructor unless 'static' or 'const'*/

        private Random rd1 = new Random();
        private int count;
        private int direction;
        private int waitTime;
        public SkeletonEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = new Vector2(500, 500);

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
                waitTime = rd1.Next(240);
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
