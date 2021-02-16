using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class GoriyaLeftState : IState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }

        public GoriyaLeftState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaLeftEnemy();

            Sprite.Animation.IsPlaying = false;
        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying)
            {
                Sprite.Animation.Play();
            }
            Goriya.X = Goriya.X - 1;
        }

        public void Attack()
        {
            // Not implemented
        }

        public void UseItem()
        {
            Goriya.SetState(Goriya.facingLeftItem);
            Goriya.UseItem();
        }

        public void Update()
        {

        }
    }
}
