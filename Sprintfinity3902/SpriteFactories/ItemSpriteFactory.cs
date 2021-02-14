using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.SpriteFactories {
    public class ItemSpriteFactory {
        private Texture2D linkItemSpriteSheet;
        private Texture2D bossSpriteSheet;
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
            linkItemSpriteSheet = content.Load<Texture2D>("Zelda_Link_and_Items_Transparent");
            bossSpriteSheet = content.Load<Texture2D>("Zelda_Bosses_Transparent");
            itemSpriteSheet = content.Load<Texture2D>("Zelda_Items_and_Weapons_Transparent");
        }

        public ISprite CreateBombItem() {
            return new BombItemSprite(linkItemSpriteSheet);
        }

        public ISprite CreateFireAttack()
        {
            return new FireAttackSprite(bossSpriteSheet);
        }

        public ISprite CreateRupeeItem()
        {
            return new RupeeItemSprite(itemSpriteSheet);
        }

        public ISprite CreateHeartItem()
        {
            return new HeartItemSprite(itemSpriteSheet);
        }

        public ISprite CreateHeartContainerItem()
        {
            return new HeartContainerItemSprite(itemSpriteSheet);
        }

        public ISprite CreateCompassItem()
        {
            return new CompassItemSprite(itemSpriteSheet);
        }

        public ISprite CreateMapItem()
        {
            return new MapItemSprite(itemSpriteSheet);
        }
        public ISprite CreateKeyItem()
        {
            return new KeyItemSprite(itemSpriteSheet);
        }
        public ISprite CreateTriforceItem()
        {
            return new TriforceItemSprite(itemSpriteSheet);
        }
        public ISprite CreateBowItem()
        {
            return new BowItemSprite(itemSpriteSheet);
        }
        public ISprite CreateClockItem()
        {
            return new ClockItemSprite(itemSpriteSheet);
        }
    }
}
