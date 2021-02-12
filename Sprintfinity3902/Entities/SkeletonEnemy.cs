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
        private int count;
        private int direction;
        private int waitTime;
        public SkeletonEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = new Vector2(1000, 500);

            direction = new Random().Next(1, 5);
            count = 0;
        }

        public override void Move()
        {
            
            if(count == 0)
            {
                waitTime = new Random().Next(30, 180);
                count++;
            }
            else if(count == waitTime)
            {
                direction = new Random().Next(1, 5);
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
