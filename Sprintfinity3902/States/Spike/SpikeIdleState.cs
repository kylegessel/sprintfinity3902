using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class SpikeIdleState : IEnemyState
    {
        private static int TWO_HUNDRED_EIGHT = 208;
        private static int NINETY_SIX = 96;
        private static int ONE_HUNDRED_NINETY_TWO = 192;
        private static int THIRTY_TWO = 32;

        public ISprite Sprite { get; set; }
        public SpikeEnemy Spike { get; set; }
        public bool Start { get; set; }

        public SpikeIdleState(SpikeEnemy spike)
        {
            Spike = spike;
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Start = false;
        }

        public void Move()
        {
            if (Start == true)
            {
                if(Spike.Id == 1)
                {
                    Spike.X = THIRTY_TWO * Global.Var.SCALE;
                    Spike.Y = NINETY_SIX * Global.Var.SCALE;
                }
                else if(Spike.Id == 2)
                {
                    Spike.X = TWO_HUNDRED_EIGHT * Global.Var.SCALE;
                    Spike.Y = NINETY_SIX * Global.Var.SCALE;
                }
                else if(Spike.Id == 3)
                {
                    Spike.X = THIRTY_TWO * Global.Var.SCALE;
                    Spike.Y = ONE_HUNDRED_NINETY_TWO * Global.Var.SCALE;
                }
                else if(Spike.Id == 4)
                {
                    Spike.X = TWO_HUNDRED_EIGHT * Global.Var.SCALE;
                    Spike.Y = ONE_HUNDRED_NINETY_TWO * Global.Var.SCALE;
                }
                Start = false;
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
