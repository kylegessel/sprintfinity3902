using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class SpikeVerticalMovingBackwardState : IEnemyState
    {
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
                if (Spike.Y < 97 * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.idleState);
                    Spike.CurrentState.Start = true;
                }
                else
                {
                    Spike.Y = Spike.Y - .5f * Global.Var.SCALE;
                }
            }
            else if(Spike.Id == 3 || Spike.Id == 4)
            {
                if (Spike.Y > 189 * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.idleState);
                    Spike.CurrentState.Start = true;
                }
                else
                {
                    Spike.Y = Spike.Y + .5f * Global.Var.SCALE;
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
            if(count > 40)
            {
                Move();
            }
            else if(count < 40)
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
