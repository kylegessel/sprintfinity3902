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

        private static EnemySpriteFactory instance;

        private static string FILE_NAME = "Zelda_Dungeon_Enemies_Transparent";

        public static EnemySpriteFactory Instance {
            get {
                if (instance == null) {
                    instance = new EnemySpriteFactory();
                }
                return instance;
            }
        }


        public void LoadAllTextures(ContentManager content) {
            enemySpriteSheet = content.Load<Texture2D>(FILE_NAME);
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

    }
}
