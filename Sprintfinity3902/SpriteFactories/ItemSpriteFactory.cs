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
        }

        public IEntity CreateBombItem() {
            return new BombItemSprite(itemSpriteSheet);
        }
    }
}
