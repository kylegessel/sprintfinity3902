using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class DigdoggerStunnedState : IEnemyState
    {
        public DigdoggerBoss Digdogger { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }
        private int rand;
        private int count;

        public DigdoggerStunnedState(DigdoggerBoss digDogger)
        {
            Digdogger = digDogger;
            Sprite = EnemySpriteFactory.Instance.CreateDigdoggerStunned();
            Start = false;
            rand = 0;
            count = 0;
        }


        public void Move()
        {
            rand = new Random().Next(1, 5);
            if (rand == 1)
            {
                Digdogger.X = Digdogger.X + Digdogger.speed * Global.Var.SCALE;
            }
            else if (rand >= 3)
            {
                Digdogger.X = Digdogger.X - Digdogger.speed * Global.Var.SCALE;
            }
            else
            {

            }

            if (rand >= 1 && rand < 3)
            {
                Digdogger.Y = Digdogger.Y + Digdogger.speed * Global.Var.SCALE;
            }
            else if (rand >= 5)
            {
                Digdogger.Y = Digdogger.Y - Digdogger.speed * Global.Var.SCALE;
            }
            else
            {

            }

        }

        public void Wait()
        {

        }

        public void UseItem()
        {

        }

        public void Update()
        {
            if(count == 250)
            {
                Digdogger.Game.PreviousState = Digdogger.Game.PAUSED;
                Digdogger.speed = .35f;
                Digdogger.SetState(Digdogger.movingLeft);
                count = 0;
            }
            count++;
        }
    }
}