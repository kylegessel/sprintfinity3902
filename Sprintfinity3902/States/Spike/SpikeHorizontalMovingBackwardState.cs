using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class SpikeHorizontalMovingBackwardState : IEnemyState
    {

        private static float F_DOT_EIGHT = .8f;
        private static int FORTY = 40;
        private static int TWO_HUNDRED_SEVEN = 207;
        private static int THIRTY_FOUR = 34;

        public ISprite Sprite { get; set; }
        public SpikeEnemy Spike { get; set; }
        public bool Start { get; set; }
        private int count;
        

        public SpikeHorizontalMovingBackwardState(SpikeEnemy spike)
        {
            Spike = spike;
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Start = false;
            count = 0;
        }

        public void Move()
        {

            if (Spike.Id == 1 || Spike.Id == 3)
            {
                if (Spike.X < THIRTY_FOUR * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.idleState);
                    Spike.CurrentState.Start = true;
                }
                else if (count > FORTY)
                {
                    Spike.X = Spike.X - F_DOT_EIGHT * Global.Var.SCALE;
                }
            }
            else if (Spike.Id == 2 || Spike.Id == 4)
            {
                if (Spike.X > TWO_HUNDRED_SEVEN * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.idleState);
                    Spike.CurrentState.Start = true;
                }
                else if (count > FORTY)
                {
                    Spike.X = Spike.X + F_DOT_EIGHT * Global.Var.SCALE;
                }
            }
        }

        public void Update()
        {
            if (Start == true)
            {
                Start = false;
                count = 0;
            }
            if (count > FORTY)
            {
                Move();
            }
            else if (count < FORTY)
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
