using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class HandEnemy : AbstractEntity
    {
        private int count;
        private int direction;
        private int waitTime;
        public HandEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateHandEnemy();
            Position = new Vector2(300, 700);
        }
        public override void Move()
        {

            if (count == 0)
            {
                waitTime = new Random().Next(60, 220);
                count++;
            }
            else if (count == waitTime)
            {
                direction = new Random().Next(1, 5);
                count = 0;
            }

            if (direction == 1) //Left
            {
                X = X - 1;
            }
            else if (direction == 2) //Right
            {
                X = X + 1;
            }
            else if (direction == 3) //Up
            {
                Y = Y - 1;
            }
            else if (direction == 4) //Down
            {
                Y = Y + 1;
            }
            count++;
        }

        public override void Move() {
            /*Move me*/
        }
    }
}
