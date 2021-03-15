using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class GoriyaDownMovingState : IEnemyState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }

        private int count;
        private int rnd;

        public GoriyaDownMovingState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaDownEnemy();
            Sprite.Animation.IsPlaying = false;
            Start = false;
            count = 0;
            rnd = 0;
        }

        public void Move()
        {
            if (Start)
            {
                count = 0;
                Start = false;
                rnd = new Random().Next(80, 150);
                if (!Sprite.Animation.IsPlaying)
                {
                    Sprite.Animation.Play();
                }
            }

            if (count == rnd)
            {
                Goriya.done = true;
            }
            else
            {
                Goriya.Y = Goriya.Y + .2f * Global.Var.SCALE;
                count++;
            }
        }

        public void Wait()
        {
            Goriya.SetState(Goriya.idleDown);
            Goriya.CurrentState.Start = true;
            Goriya.Wait();
        }

        public void UseItem()
        {
            Goriya.SetState(Goriya.itemDown);
            Goriya.CurrentState.Start = true;
            Goriya.UseItem();
        }

        public void Update()
        {
            Move();
        }
    }
}
