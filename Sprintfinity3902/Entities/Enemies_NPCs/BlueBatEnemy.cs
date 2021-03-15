using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class BlueBatEnemy : AbstractEntity
    {

        private Random rand = new Random();
        private int count;
        private int direction;
        private int waitTime;

        public BlueBatEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateBlueBatEnemy();
            Position = new Vector2(750, 540);
            direction = 0;
            count = 0;
        }
        public BlueBatEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateBlueBatEnemy();
            Position = pos;
            direction = 0;
            count = 0;
        }

        public override bool IsCollidable()
        {
            return false;
        }

        public override void Move()
        {
            if(count == 0)
            {
                waitTime = rand.Next(40, 200);
            }else if( count == waitTime)
            {
                // States for left, right, up, down, up right, up left, down left, down right.
               direction = rand.Next(1, 9);
                // If the Sprite animation was previously stopped, begin playing it again.
                if (!Sprite.Animation.IsPlaying) {
                    Sprite.Animation.Play();
                }

               count = 0;
            }

            switch (direction)
            {
                case 1:
                    X = X - .4f * Global.Var.SCALE;
                    break;
                case 2:
                    X = X + .4f * Global.Var.SCALE;
                    break;
                case 3:
                    Y = Y - .4f * Global.Var.SCALE;
                    break;
                case 4:
                    Y = Y + .4f * Global.Var.SCALE;
                    break;
                case 5:
                    X = X + .4f * Global.Var.SCALE;
                    Y = Y + .4f * Global.Var.SCALE;
                    break;
                case 6:
                    X = X - .4f * Global.Var.SCALE;
                    Y = Y + .4f * Global.Var.SCALE;
                    break;
                case 7:
                    X = X - .4f * Global.Var.SCALE;
                    Y = Y - .4f * Global.Var.SCALE;
                    break;
                case 8:
                    X = X + .4f * Global.Var.SCALE;
                    Y = Y - .4f * Global.Var.SCALE;
                    break;
                case 9:
                    // Stop animation when not moving.
                    Sprite.Animation.Stop();
                    break;
            }
            count++;
        }


    }
}
