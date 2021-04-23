using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class SpikeVerticalMovingForwardState : IEnemyState
    {
        private static int ONE_HUNDRED_THIRTY_FIVE = 135;
        private static int ONE_HUNDRED_FIFTY_TWO = 152;
        private static float F_ONE_DOT_FIVE = 1.25f;

        public ISprite Sprite { get; set; }
        public SpikeEnemy Spike { get; set; }
        public bool Start { get; set; }

        public SpikeVerticalMovingForwardState(SpikeEnemy spike)
        {
            Spike = spike;
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Start = false;
        }

        public void Move()
        {
            if (Start == true)
                Start = false;

            if(Spike.Id == 1 || Spike.Id == 2)
            {
                if(Spike.Y > ONE_HUNDRED_THIRTY_FIVE * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.verticalMovingBackward);
                    Spike.CurrentState.Start = true;
                }
                else
                {
                    Spike.Y = Spike.Y + F_ONE_DOT_FIVE * Global.Var.SCALE;
                }
            }
            else if(Spike.Id == 3 || Spike.Id == 4)
            {
                if (Spike.Y < ONE_HUNDRED_FIFTY_TWO * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.verticalMovingBackward);
                    Spike.CurrentState.Start = true;
                }
                else
                {
                    Spike.Y = Spike.Y - F_ONE_DOT_FIVE * Global.Var.SCALE;
                }
            }

        }

        public void Update()
        {
            Move();
        }

        public void UseItem()
        {
            throw new NotImplementedException();
        }

        public void Wait()
        {
            throw new NotImplementedException();
        }
    }
}
