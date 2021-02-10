using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class BlueBatEnemy : AbstractEntity
    {

        private Random rand = new Random();
        private int count;
        // For slowing down in future.
        private int previousDirection;
        private int direction;
        private int waitTime;

        public BlueBatEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateBlueBatEnemy();
            Position = new Vector2(700, 500);

            direction = 0;
            count = 0;
        }

        public override void Move()
        {
            if(count == 0)
            {
                waitTime = rand.Next(500);
            }else if( count == waitTime)
            {
                // States for left, right, up, down, up right, up left, down left, down right.
                direction = rand.Next(1, 9);
                count = 0;
            }

            switch (direction)
            {
                case 1:
                    X = X - 2;
                    break;
                case 2:
                    X = X + 2;
                    break;
                case 3:
                    Y = Y - 2;
                    break;
                case 4:
                    Y = Y + 2;
                    break;
                case 5:
                    X = X + 1;
                    Y = Y + 1;
                    break;
                case 6:
                    X = X - 1;
                    Y = Y + 1;
                    break;
                case 7:
                    X = X - 1;
                    Y = Y - 1;
                    break;
                case 8:
                    X = X + 1;
                    Y = Y - 1;
                    break;
                case 9:
                    break;
            }
            count++;
        }
    }
}
