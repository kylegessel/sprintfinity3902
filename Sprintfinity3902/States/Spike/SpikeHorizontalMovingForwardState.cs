using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class SpikeHorizontalMovingForwardState : IEnemyState
    {
        private static int ONE_HUNDRED_TWENTY_NINE = 129;
        private static float F_ONE_DOT_FIVE = 1.25f;
        private static int ONE_HUNDRED_ELEVEN = 111;

        public ISprite Sprite { get; set; }
        public SpikeEnemy Spike { get; set; }
        public bool Start { get; set; }

        public SpikeHorizontalMovingForwardState(SpikeEnemy spike)
        {
            Spike = spike;
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Start = false;
        }

        public void Move()
        {
            if (Start == true)
                Start = false;

            if (Spike.Id == 1 || Spike.Id == 3)
            {
                if (Spike.X > ONE_HUNDRED_ELEVEN * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.horizontalMovingBackward);
                    Spike.CurrentState.Start = true;
                }
                else
                {
                    Spike.X = Spike.X + F_ONE_DOT_FIVE * Global.Var.SCALE;
                }
            }
            else if (Spike.Id == 2 || Spike.Id == 4)
            {
                if (Spike.X < ONE_HUNDRED_TWENTY_NINE * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.horizontalMovingBackward);
                    Spike.CurrentState.Start = true;
                }
                else
                {
                    Spike.X = Spike.X - F_ONE_DOT_FIVE * Global.Var.SCALE;
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
