using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class RopeSnakeMovingDownFacingLeftState : IEnemyState
    {
        private static int LOWER_BOUND = 50;
        private static int UPPER_BOUND = 90;

        private static int ONE_HUNDRED_SEVENTY_FOUR = 174;
        private static int SEVENTEEN = 17;
        public RopeSnakeEnemy RopeSnake { get; set; }
        public ISprite Sprite { get; set; }
       // public float Speed { get; set; }
        public bool Start { get; set; }
        private int count;
        private int rnd;

        public Rectangle downRec;
        public Vector2 hitBoxPos;

        public RopeSnakeMovingDownFacingLeftState(RopeSnakeEnemy ropesnake) /*This should be Interface*/
        {
            RopeSnake = ropesnake;
            Sprite = EnemySpriteFactory.Instance.CreateRopeSnakeLeftEnemy();
            //Sprite.Animation.IsPlaying = false;
            count = 0;
            Start = false;
            //hitBoxPos = RopeSnake.Position;
            //downRec = new Rectangle((int)hitBoxPos.X, (int)hitBoxPos.Y, ONE_HUNDRED_SEVENTY_FOUR * Global.Var.SCALE, SEVENTEEN * Global.Var.SCALE);
        }

        public void Move()
        {
            if (Start)
            {
                count = 0;
                Start = false;
                rnd = new Random().Next(LOWER_BOUND, UPPER_BOUND);
            }

            if ( (count >= rnd) && !RopeSnake.dart )
            {
                RopeSnake.done = true;
            }
            else
            {
                if (RopeSnake.dart)
                    RopeSnake.dartDist += RopeSnake.Speed * Global.Var.SCALE;
                RopeSnake.Y = RopeSnake.Y + RopeSnake.Speed * Global.Var.SCALE;
                count++;
            }
            
        }

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