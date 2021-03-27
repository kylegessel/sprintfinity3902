using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using Sprintfinity3902.Sprites.Items;

namespace Sprintfinity3902.SpriteFactories
{
    public class ItemSpriteFactory {
        private Texture2D linkItemSpriteSheet;
        private Texture2D bossSpriteSheet;
        private Texture2D itemSpriteSheet;

        private static ItemSpriteFactory instance;

        private static string LINK_ITEM_FILE_NAME = "Zelda_Link_and_Items_Transparent";
        private static string BOSS_FILE_NAME = "Zelda_Bosses_Transparent";
        private static string ITEM_FILE_NAME = "Zelda_Items_and_Weapons_Transparent";

        public static ItemSpriteFactory Instance {
            get {
                if (instance == null) {
                    instance = new ItemSpriteFactory();
                }
                return instance;
            }
        }
        public void LoadAllTextures(ContentManager content) {
            linkItemSpriteSheet = content.Load<Texture2D>(LINK_ITEM_FILE_NAME);
            bossSpriteSheet = content.Load<Texture2D>(BOSS_FILE_NAME);
            itemSpriteSheet = content.Load<Texture2D>(ITEM_FILE_NAME);
        }

        public ISprite CreateBombItem() {
            return new BombItemSprite(linkItemSpriteSheet);
        }

        public ISprite CreateSmokeItem()
        {
            return new SmokeItemSprite(linkItemSpriteSheet);
        }

        public ISprite CreateMovingSwordHorizontalItem()
        {
            return new MovingSwordHorizontalSprite(linkItemSpriteSheet);
        }

        public ISprite CreateMovingSwordVerticalItem()
        {
            return new MovingSwordVerticalSprite(linkItemSpriteSheet);
        }

        public ISprite CreateArrowHorizontalItem()
        {
            return new ArrowHorizontalSprite(linkItemSpriteSheet);
        }

        public ISprite CreateArrowVerticalItem()
        {
            return new ArrowVerticalSprite(linkItemSpriteSheet);
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

        public ISprite CreateSwordSplitTopLeft()
        {
            return new SwordSplitTopLeftSprite(linkItemSpriteSheet);
        }
        public ISprite CreateSwordSplitTopRight()
        {
            return new SwordSplitTopRightSprite(linkItemSpriteSheet);
        }
        public ISprite CreateSwordSplitBottomLeft()
        {
            return new SwordSplitBottomLeftSprite(linkItemSpriteSheet);
        }
        public ISprite CreateSwordSplitBottomRight()
        {
            return new SwordSplitBottomRightSprite(linkItemSpriteSheet);
        }
        public ISprite CreateBoomerangItem()
        {
            return new BoomerangItemSprite(linkItemSpriteSheet);
        }

        public ISprite CreateFairyItem()
        {
            return new FairyItemSprite(itemSpriteSheet);
        }
    }
}
