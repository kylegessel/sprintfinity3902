using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class RopeSnakeMovingLeftState : IEnemyState
    {
        private static int LOWER_BOUND = 40;
        private static int UPPER_BOUND = 240;
        public RopeSnakeEnemy RopeSnake { get; set; }
        public ISprite Sprite { get; set; }
        //public float Speed { get; set; }
        public bool Start { get; set; }
        private int count;
        private int rnd;

        public RopeSnakeMovingLeftState(RopeSnakeEnemy ropesnake) /*This should be Interface*/
        {
            RopeSnake = ropesnake;
            Sprite = EnemySpriteFactory.Instance.CreateRopeSnakeLeftEnemy();
            //Sprite.Animation.IsPlaying = false;
            count = 0;
            Start = false;
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
                RopeSnake.X = RopeSnake.X - RopeSnake.Speed * Global.Var.SCALE;
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
