using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class EnemySpriteFactory
    {
        private Texture2D enemySpriteSheet;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            enemySpriteSheet = content.Load<Texture2D>("Zelda_Dungeon_Enemies_Transparent");
        }

        public IEntity CreateBlueBatEnemy()
        {
            return new BlueBatEnemySprite(enemySpriteSheet);
        }

        public IEntity CreateGelEnemy()
        {
            return new GelEnemySprite(enemySpriteSheet);
        }

        public IEntity CreateGoriyaDownEnemy()
        {
            return new GoriyaEnemyDownSprite(enemySpriteSheet);
        }

        public IEntity CreateGoriyaUpEnemy()
        {
            return new GoriyaEnemyUpSprite(enemySpriteSheet);
        }
        public IEntity CreateGoriyaLeftEnemy()
        {
            return new GoriyaEnemyLeftSprite(enemySpriteSheet);
        }

        public IEntity CreateGoriyaRightEnemy()
        {
            return new GoriyaEnemyRightSprite(enemySpriteSheet);
        }
        public IEntity CreateSkeletonEnemy()
        {
            return new SkeletonEnemySprite(enemySpriteSheet);
        }
        public IEntity CreateHandEnemy()
        {
            return new HandEnemySprite(enemySpriteSheet);
        }

    }
}
