using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class SpikeHorizontalMovingForwardState : IEnemyState
    {
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
                if (Spike.X > 111 * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.horizontalMovingBackward);
                    Spike.CurrentState.Start = true;
                }
                else
                {
                    Spike.X = Spike.X + 1.5f * Global.Var.SCALE;
                }
            }
            else if (Spike.Id == 2 || Spike.Id == 4)
            {
                if (Spike.X < 129 * Global.Var.SCALE)
                {
                    Spike.SetState(Spike.horizontalMovingBackward);
                    Spike.CurrentState.Start = true;
                }
                else
                {
                    Spike.X = Spike.X - 1.5f * Global.Var.SCALE;
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
