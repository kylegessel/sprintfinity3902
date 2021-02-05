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
            enemySpriteSheet = content.Load<Texture2D>("Zelda - Dungeon Enemies - Transparent");
        }

        public ISprite CreateBlueBatEnemy()
        {
            return new BlueBatEnemySprite(enemySpriteSheet);
        }

        public ISprite CreateGelEnemy()
        {
            return new GelEnemySprite(enemySpriteSheet);
        }

        public ISprite CreateGoriyaDownEnemy()
        {
            return new GoriyaEnemyDownSprite(enemySpriteSheet);
        }

        public ISprite CreateGoriyaUpEnemy()
        {
            return new GoriyaEnemyUpSprite(enemySpriteSheet);
        }
        public ISprite CreateGoriyaLeftEnemy()
        {
            return new GoriyaEnemyLeftSprite(enemySpriteSheet);
        }

        public ISprite CreateGoriyaRightEnemy()
        {
            return new GoriyaEnemyRightSprite(enemySpriteSheet);
        }
        public ISprite CreateSkeletonEnemy()
        {
            return new SkeletonEnemySprite(enemySpriteSheet);
        }
        public ISprite CreateHandEnemy()
        {
            return new HandEnemySprite(enemySpriteSheet);
        }

    }
}
