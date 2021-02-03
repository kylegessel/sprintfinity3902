using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902
{
    public class Enemy
    {
        public ISprite CurrentEnemySprite { get; set; }
        public EnemySpriteFactory EnemyFactory { get; set; }

        public Enemy()
        {
            EnemyFactory = EnemySpriteFactory.Instance;
        }

        public void getEnemy()
        {
            CurrentEnemySprite = EnemyFactory.CreateBlueBatEnemy();
            CurrentEnemySprite.GetAnimation();
        }

    }
}
