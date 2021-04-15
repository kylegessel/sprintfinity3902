using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class DigdoggerMovingLeftState : IEnemyState
    {
        public DigdoggerBoss Digdogger { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }
        private int rand;

        public DigdoggerMovingLeftState(DigdoggerBoss digDogger)
        {
            Digdogger = digDogger;
            Sprite = EnemySpriteFactory.Instance.CreateDigdoggerLeft();
            Start = false;
            rand = 0;
        }


        public void Move()
        {
            rand = new Random().Next(1, 5);
            if(rand == 1)
            {
                Sprite = EnemySpriteFactory.Instance.CreateDigdoggerRight();
                Digdogger.X = Digdogger.X + Digdogger.speed * Global.Var.SCALE;
            }
            else if(rand >= 3)
            {
                Sprite = EnemySpriteFactory.Instance.CreateDigdoggerLeft();
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

        }
    }
}