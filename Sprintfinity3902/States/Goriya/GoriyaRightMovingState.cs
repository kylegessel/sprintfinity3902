using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class GoriyaRightMovingState : IGoriyaState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }

        private int count;
        private int rnd;


        public GoriyaRightMovingState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaRightEnemy();
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
                Goriya.X = Goriya.X + 1;
                count++;
            }
        }

        public void Wait()
        {
            Goriya.SetState(Goriya.idleRight);
            Goriya.CurrentState.Start = true;
            Goriya.Wait();
        }

        public void UseItem()
        {
            Goriya.SetState(Goriya.itemRight);
            Goriya.CurrentState.Start = true;
            Goriya.UseItem();
        }

        public void Update()
        {
            Move();
        }
    }
}
