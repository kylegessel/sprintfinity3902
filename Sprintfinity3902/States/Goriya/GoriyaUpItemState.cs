using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class GoriyaUpItemState : IGoriyaState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }

        private int count;

        public GoriyaUpItemState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaUpEnemy();
            Sprite.Animation.IsPlaying = false;
            Start = false;
            count = 0;
        }


        public void Move()
        {
            Goriya.SetState(Goriya.movingUp);
            Goriya.CurrentState.Start = true;
            Goriya.Move();
        }

        public void Wait()
        {
            Goriya.SetState(Goriya.idleUp);
            Goriya.CurrentState.Start = true;
            Goriya.Wait();
        }

        public void UseItem()
        {
            if (Start)
            {
                count = 0;
                Start = false;
                if (!Goriya.Boomerang.getItemUse())
                {
                    Goriya.Boomerang.UseItem(Goriya);
                }
            }

            if (count == 100)
                Goriya.done = true;
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
