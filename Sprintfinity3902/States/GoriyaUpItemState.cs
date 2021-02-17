using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class GoriyaUpItemState : IState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }

        public GoriyaUpItemState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaUpEnemy();
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
