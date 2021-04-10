using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class GohmaOpenedEyeState : IEnemyState
    {

        private static int LOWER_BOUND = 100;
        private static int UPPER_BOUND = 250;
        public GohmaBoss Gohma { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }

        private int rnd;
        private int count;

        public GohmaOpenedEyeState(GohmaBoss gohma)
        {
            Gohma = gohma;
            Sprite = EnemySpriteFactory.Instance.CreateGohmaOpenedEye();
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
                Gohma.SetState(Gohma.closedEye);
                Gohma.closedEye.Start = true;
            }
            count++;
        }
    }
}