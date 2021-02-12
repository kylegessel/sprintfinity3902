using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.SpriteFactories {
    public class ItemSpriteFactory {
        private Texture2D itemSpriteSheet;
        private Texture2D bossSpriteSheet;

        private static ItemSpriteFactory instance;

        public static ItemSpriteFactory Instance {
            get {
                if (instance == null) {
                    instance = new ItemSpriteFactory();
                }
                return instance;
            }
        }
        public void LoadAllTextures(ContentManager content) {
            itemSpriteSheet = content.Load<Texture2D>("Zelda_Link_and_Items_Transparent");
            bossSpriteSheet = content.Load<Texture2D>("Zelda_Bosses_Transparent");
        }

        public ISprite CreateBombItem() {
            return new BombItemSprite(itemSpriteSheet);
        }

        public ISprite CreateFireAttack()
        {
            return new FireAttackSprite(bossSpriteSheet);
        }

        public ISprite CreateBoomerangItem()
        {
            return new BoomerangItemSprite(itemSpriteSheet);
        }
    }
}
