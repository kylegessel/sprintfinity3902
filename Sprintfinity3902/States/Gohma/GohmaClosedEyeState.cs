using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class GohmaClosedEyeState : IEnemyState
    {

        private const int LOWER_BOUND = 250;
        private const int UPPER_BOUND = 750;
        private const int FIRE_Y_OFFSET = 10;
        private const int RANDOM_UP_BOUND = 140;
        private const int RANDOM_DOWN_BOUND = 80;

        public GohmaBoss Gohma { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }

        private int rnd;
        private int count;

        public GohmaClosedEyeState(GohmaBoss gohma)
        {
            Gohma = gohma;
            Sprite = EnemySpriteFactory.Instance.CreateGohmaClosedEye();
            Start = false;
            count = 0;
            rnd = 0;
        }


        public void Move()
        {

        }

        public void Wait()
        {
            
        }

        public void UseItem()
        {
            if(Gohma.attackCount == 0)
            {
                Vector2 startPosition = new Vector2(Gohma.X + Global.Var.TILE_SIZE * Global.Var.SCALE, Gohma.Y + FIRE_Y_OFFSET * Global.Var.SCALE);
                Gohma.fireAttack.StartOver(startPosition);
                Gohma.fireAttack.StartMoving();
                Gohma.randomFireCount = new Random().Next(RANDOM_DOWN_BOUND, RANDOM_UP_BOUND);
            }
            else if(Gohma.attackCount == Gohma.randomFireCount)
            {
                Gohma.fireAttack.StopMoving();
                Gohma.attackCount = -1;
            }
            else
            {
                Gohma.fireAttack.Move();
            }
            Gohma.attackCount++;
        }

        public void Update()
        {
            if (Start)
            {
                count = 0;
                rnd = new Random().Next(LOWER_BOUND, UPPER_BOUND);
                Start = false;
            }
            if (count == rnd)
            {
                Gohma.SetState(Gohma.openedEye);
                Gohma.openedEye.Start = true;
            }
            count++;
        }
    }
}