using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902
{
    public class Enemy
    {
        private Game1 _Game;
        public ISprite CurrentEnemy { get; set; }
        public EnemySpriteFactory EnemyFactory { get; set; }

        public Enemy(Game1 game)
        {
            _Game = game;
            EnemyFactory = EnemySpriteFactory.Instance;
        }

        public void getEnemy()
        {
            CurrentEnemy = EnemyFactory.CreateBlueBatEnemy();
        }

    }
}
