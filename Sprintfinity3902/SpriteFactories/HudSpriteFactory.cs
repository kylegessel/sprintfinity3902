using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;

namespace Sprintfinity3902.SpriteFactories
{
    public class HudSpriteFactory
    {
        private Texture2D hudSpriteSheet;

        private static HudSpriteFactory instance;

        private static string HUD_FILE_NAME = "Zelda_HudElements_Transparent";

        public static HudSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HudSpriteFactory();
                }
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            hudSpriteSheet = content.Load<Texture2D>(HUD_FILE_NAME);
        }

        //HUD MENUS
        public ISprite CreateInGameHud()
        {
            return new InGameHudSprite(hudSpriteSheet);
        }

        public ISprite CreateDungeonHud()
        {
            return new DungeonHudSprite(hudSpriteSheet);
        }

        public ISprite CreateInventoryHud()
        {
            return new InventoryHudSprite(hudSpriteSheet);
        }

        public ISprite CreateMiniMap()
        {
            return new MiniMapSprite(hudSpriteSheet);
        }

        //HUD ICONS
        public ISprite CreateBlackSquareIcon()
        {
            return new BlackSquareIconSprite(hudSpriteSheet);
        }
        public ISprite CreateOrangeSquareIcon()
        {
            return new OrangeSquareIconSprite(hudSpriteSheet);
        }
            
        public ISprite CreateBlackLongIcon()
        {
            return new BlackLongIconSprite(hudSpriteSheet);
        }
        public ISprite CreateHeartFullIcon()
        {
            return new HeartFullIconSprite(hudSpriteSheet);
        }
        public ISprite CreateHeartHalfIcon()
        {
            return new HeartHalfIconSprite(hudSpriteSheet);
        }
        public ISprite CreateHeartEmptyIcon()
        {
            return new HeartEmptyIconSprite(hudSpriteSheet);
        }
        public ISprite CreateNumber1()
        {
            return new Number1Sprite(hudSpriteSheet);
        }
        public ISprite CreateNumber2()
        {
            return new Number2Sprite(hudSpriteSheet);
        }
        public ISprite CreateNumber3()
        {
            return new Number3Sprite(hudSpriteSheet);
        }
        public ISprite CreateNumber4()
        {
            return new Number4Sprite(hudSpriteSheet);
        }
        public ISprite CreateNumber5()
        {
            return new Number5Sprite(hudSpriteSheet);
        }
        public ISprite CreateNumber6()
        {
            return new Number6Sprite(hudSpriteSheet);
        }
        public ISprite CreateNumber7()
        {
            return new Number7Sprite(hudSpriteSheet);
        }
        public ISprite CreateNumber8()
        {
            return new Number8Sprite(hudSpriteSheet);
        }
        public ISprite CreateNumber9()
        {
            return new Number9Sprite(hudSpriteSheet);
        }
        public ISprite CreateNumber0()
        {
            return new Number0Sprite(hudSpriteSheet);
        }
        public ISprite CreateLetterX()
        {
            return new LetterXSprite(hudSpriteSheet);
        }
        public ISprite CreateSwordIcon()
        {
            return new SwordIconSprite(hudSpriteSheet);
        }
        public ISprite CreateItemSelectIcon()
        {
            return new ItemSelectIconSprite(hudSpriteSheet);
        }
        public ISprite CreateBoomerangIcon()
        {
            return new BoomerangIconSprite(hudSpriteSheet);
        }
        public ISprite CreateBombIcon()
        {
            return new BombIconSprite(hudSpriteSheet);
        }
        public ISprite CreateBowIcon()
        {
            return new BowIconSprite(hudSpriteSheet);
        }
    }
}
