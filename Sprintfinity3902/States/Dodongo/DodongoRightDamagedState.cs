using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class DodongoRightDamagedState : IEnemyState
    {
        public DodongoBoss Dodongo { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }

        public DodongoRightDamagedState(DodongoBoss dodongo)
        {
            Dodongo = dodongo;
            Sprite = EnemySpriteFactory.Instance.CreateDodongoRightDamaged();
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

        }
    }
}