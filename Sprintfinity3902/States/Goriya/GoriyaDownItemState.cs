using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class GoriyaDownItemState : IGoriyaState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }

        private int count;

        public GoriyaDownItemState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaDownEnemy();
            Sprite.Animation.IsPlaying = false;
            Start = false;
            count = 0;
        }


        public void Move()
        {
            Goriya.SetState(Goriya.movingDown);
            Goriya.CurrentState.Start = true;
            Goriya.Move();
        }

        public void Wait()
        {
            Goriya.SetState(Goriya.idleDown);
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

            if (count == 120)
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
