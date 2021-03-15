using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class GoriyaLeftItemState : IEnemyState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }

        private int count;
        private int rnd;


        public GoriyaLeftItemState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaLeftEnemy();
            Sprite.Animation.IsPlaying = false;
            Start = false;
            count = 0;
            rnd = 0;
        }


        public void Move()
        {
            Goriya.SetState(Goriya.movingLeft);
            Goriya.CurrentState.Start = true;
            Goriya.Move();
        }

        public void Wait()
        {
            Goriya.SetState(Goriya.idleLeft);
            Goriya.CurrentState.Start = true;
            Goriya.Wait();
        }

        public void UseItem()
        {
            if (Start)
            {
                count = 0;
                Start = false;
                Sprite.Animation.Stop();
                rnd = new Random().Next(0, 25);
                if (!Goriya.Boomerang.getItemUse())
                {
                    Goriya.Boomerang.UseItem(Goriya);
                }
            }

            if (count == rnd)
            {
                Goriya.done = true;
                Goriya.Boomerang.doneUsing();
            }
            else
            {
                count++;
            }

        }

        public void Update()
        {
            UseItem();
        }
    }
}
