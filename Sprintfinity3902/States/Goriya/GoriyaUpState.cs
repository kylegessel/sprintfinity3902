using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class GoriyaUpState : IState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }

        public GoriyaUpState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaUpEnemy();

            Sprite.Animation.IsPlaying = false;
        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying)
            {
                Sprite.Animation.Play();
            }
            Goriya.Y = Goriya.Y - 1;
        }

        public void Attack()
        {
            // Not implemented
        }

        public void UseItem()
        {
            Goriya.SetState(Goriya.facingUpItem);
            Goriya.UseItem();
        }

        public void Update()
        {

        }
    }
}
