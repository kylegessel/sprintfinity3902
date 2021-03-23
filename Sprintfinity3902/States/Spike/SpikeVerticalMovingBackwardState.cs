using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class SpikeVerticalMovingBackwardState : IEnemyState
    {

        private static int FORTY = 40;
        private static float F_DOT_SEVEN = 0.7f;
        private static int ONE_HUNDRED_EIGHTY_NINE = 189;
        private static int NINETY_SEVEN = 97;

        public ISprite Sprite { get; set; }
        public SpikeEnemy Spike { get; set; }
        public bool Start { get; set; }

        private int count;

        public SpikeVerticalMovingBackwardState(SpikeEnemy spike)
        {
            Spike = spike;
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Start = false;
            count = 0;
        }

        public void Move()
        {

            if(Spike.Id == 1 || Spike.Id == 2)
            {
                if (Spike.Y < NINETY_SEVEN * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.idleState);
                    Spike.CurrentState.Start = true;
                }
                else
                {
                    Spike.Y = Spike.Y - F_DOT_SEVEN * Global.Var.SCALE;
                }
            }
            else if(Spike.Id == 3 || Spike.Id == 4)
            {
                if (Spike.Y > ONE_HUNDRED_EIGHTY_NINE * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.idleState);
                    Spike.CurrentState.Start = true;
                }
                else
                {
                    Spike.Y = Spike.Y + F_DOT_SEVEN * Global.Var.SCALE;
                }
            }
        }

        public void Update()
        {
            if(Start == true)
            {
                Start = false;
                count = 0;
            }
            if(count > FORTY)
            {
                Move();
            }
            else if(count < FORTY)
            {
                Wait();
            }
            count++;
        
        }

        public void UseItem()
        {
            throw new NotImplementedException();
        }

        public void Wait()
        {

        }
    }
}
