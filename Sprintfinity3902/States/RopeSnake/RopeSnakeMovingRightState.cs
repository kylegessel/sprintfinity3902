using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class RopeSnakeMovingRightState : IEnemyState
    {
        private static int LOWER_BOUND = 50;
        private static int UPPER_BOUND = 90;
        
        private static int ONE_HUNDRED_SEVENTY_FOUR = 174;
        private static int SEVENTEEN = 17;
        public RopeSnakeEnemy RopeSnake { get; set; }
        public ISprite Sprite { get; set; }
        
        public bool Start { get; set; }

        private int count;
        private int rnd;
        public Rectangle rightRec;
        public Vector2 hitBoxPos;

        public RopeSnakeMovingRightState(RopeSnakeEnemy ropesnake) /*This should be Interface*/
        {
            RopeSnake = ropesnake;
            Sprite = EnemySpriteFactory.Instance.CreateRopeSnakeRightEnemy();
            //Sprite.Animation.IsPlaying = false;
            Start = false;
            count = 0;
            hitBoxPos = RopeSnake.Position;
            rightRec = new Rectangle((int)hitBoxPos.X, (int)hitBoxPos.Y, ONE_HUNDRED_SEVENTY_FOUR * Global.Var.SCALE, SEVENTEEN * Global.Var.SCALE);
        }

        public void Move()
        {
            if (Start)
            {
                count = 0;
                Start = false;
                rnd = new Random().Next(LOWER_BOUND, UPPER_BOUND);
            }

            if ((count >= rnd) && !RopeSnake.dart)
            {
                RopeSnake.done = true;
            }
            else
            {
                if (RopeSnake.dart)
                    RopeSnake.dartDist += RopeSnake.Speed * Global.Var.SCALE;
                RopeSnake.X = RopeSnake.X + RopeSnake.Speed * Global.Var.SCALE;
                count++;
            }
        }
        /*
        public void Dart()
        {
            Speed = DARTSPEED;
            RopeSnake.dart = true;
        }
        */

        public void Update()
        {
            Move();
        }

        public void Wait()
        {
            throw new NotImplementedException();
        }

        public void UseItem()
        {
            throw new NotImplementedException();
        }
    }
}
