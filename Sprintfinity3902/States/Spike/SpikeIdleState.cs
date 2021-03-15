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
                    Spike.X = 32 * Global.Var.SCALE;
                    Spike.Y = 96 * Global.Var.SCALE;
                }
                else if(Spike.Id == 2)
                {
                    Spike.X = 208 * Global.Var.SCALE;
                    Spike.Y = 96 * Global.Var.SCALE;
                }
                else if(Spike.Id == 3)
                {
                    Spike.X = 32 * Global.Var.SCALE;
                    Spike.Y = 192 * Global.Var.SCALE;
                }
                else if(Spike.Id == 4)
                {
                    Spike.X = 208 * Global.Var.SCALE;
                    Spike.Y = 192 * Global.Var.SCALE;
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
