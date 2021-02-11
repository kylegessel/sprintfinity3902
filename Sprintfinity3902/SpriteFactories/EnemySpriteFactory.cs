using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.SpriteFactories {
    public class EnemySpriteFactory {
        private Texture2D enemySpriteSheet;
        private Texture2D bossSpriteSheet;

        private static EnemySpriteFactory instance;

        public static EnemySpriteFactory Instance {
            get {
                if (instance == null) {
                    instance = new EnemySpriteFactory();
                }
                return instance;
            }
        }


        public void LoadAllTextures(ContentManager content) {
            enemySpriteSheet = content.Load<Texture2D>("Zelda_Dungeon_Enemies_Transparent");
            bossSpriteSheet = content.Load<Texture2D>("Zelda_Bosses_Transparent");
        }

        public ISprite CreateBlueBatEnemy() {
            return new BlueBatEnemySprite(enemySpriteSheet);
        }

        public ISprite CreateGelEnemy() {
            return new GelEnemySprite(enemySpriteSheet);
        }

        public ISprite CreateGoriyaDownEnemy() {
            return new GoriyaEnemyDownSprite(enemySpriteSheet);
        }

        public ISprite CreateGoriyaUpEnemy() {
            return new GoriyaEnemyUpSprite(enemySpriteSheet);
        }
        public ISprite CreateGoriyaLeftEnemy() {
            return new GoriyaEnemyLeftSprite(enemySpriteSheet);
        }

        public ISprite CreateGoriyaRightEnemy() {
            return new GoriyaEnemyRightSprite(enemySpriteSheet);
        }
        public ISprite CreateSkeletonEnemy() {
            return new SkeletonEnemySprite(enemySpriteSheet);
        }
        public ISprite CreateHandEnemy() {
            return new HandEnemySprite(enemySpriteSheet);
        }
        public ISprite CreateFinalBossClosed()
        {
            return new FinalBossMouthCloseSprite(bossSpriteSheet);
        }
        public ISprite CreateFinalBossOpened()
        {
            return new FinalBossMouthOpenSprite(bossSpriteSheet);
        }

    }
}
