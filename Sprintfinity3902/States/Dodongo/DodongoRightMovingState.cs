using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class DodongoRightMovingState : IEnemyState
    {
        public DodongoBoss Dodongo { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }

        public DodongoRightMovingState(DodongoBoss dodongo)
        {
            Dodongo = dodongo;
            Sprite = EnemySpriteFactory.Instance.CreateDodongoRightMoving();
            Start = false;
        }


        public void Move()
        {

        }

        public void Wait()
        {

        }

        public void UseItem()
        {

        }

        public void Update()
        {
            Dodongo.SetState(Dodongo.rightDamaged);
        }
    }
}