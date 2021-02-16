using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class GoriyaDownItemState : IState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }

        public GoriyaDownItemState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaDownEnemy();
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

            if (!Goriya.Boomerang.getItemUse())
            {
                Goriya.Boomerang.UseItem(Goriya);
            }
            
        }

        public void Update()
        {
            //NULL
        }

    }
}
