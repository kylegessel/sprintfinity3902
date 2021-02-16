using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class GoriyaRightItemState : IState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }
        public BoomerangItem Boomerang { get; set; }


        private Boolean itemExecuted = false;
        public GoriyaRightItemState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaRightEnemy();
            Sprite.Animation.IsPlaying = false;
        }


        public void Move()
        {
            //NULL
        }

        public void Attack()
        {

            //NULL

        }

        public void UseItem()
        {
            if (!Sprite.Animation.IsPlaying)
            {
                itemExecuted = true;
                Sprite.Animation.PlayOnce();
            }

            if (!Boomerang.getItemUse())
            {
                Boomerang.UseItem(Goriya);
            }
        }

        public void Update()
        {
            if (!Sprite.Animation.IsPlaying && itemExecuted)
            {
                Goriya.SetState(Goriya.facingRight);
                itemExecuted = false;
            }
        }
    }
}
