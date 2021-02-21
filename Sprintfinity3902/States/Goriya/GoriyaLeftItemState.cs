using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class GoriyaLeftItemState : IState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }

        public GoriyaLeftItemState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaLeftEnemy();
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
