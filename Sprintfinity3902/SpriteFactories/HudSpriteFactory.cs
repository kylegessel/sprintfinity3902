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
        public ISprite CreateCompassIcon()
        {
            return new CompassIconSprite(hudSpriteSheet);
        }
        public ISprite CreateMapIcon()
        {
            return new MapIconSprite(hudSpriteSheet);
        }

        /*Add rooms for Dungeon Hud*/
        public ISprite CreateDoorRightRoom()
        {
            return new DoorRightRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorLeftRoom()
        {
            return new DoorLeftRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorLeftRightRoom()
        {
            return new DoorLeftRightRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorBotRoom()
        {
            return new DoorBotRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorBotRightRoom()
        {
            return new DoorBotRightRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorBotLeftRoom()
        {
            return new DoorBotLeftRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorBotLeftRightRoom()
        {
            return new DoorBotLeftRightRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorTopRoom()
        {
            return new DoorTopRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorTopRightRoom()
        {
            return new DoorTopRightRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorTopLeftRoom()
        {
            return new DoorTopLeftRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorTopLeftRightRoom()
        {
            return new DoorTopLeftRightRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorTopBotRoom()
        {
            return new DoorTopBotRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorTopBotRightRoom()
        {
            return new DoorTopBotRightRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorTopBotLeftRoom()
        {
            return new DoorTopBotLeftRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateDoorAllSidesRoom()
        {
            return new DoorAllSidesRoomSprite(hudSpriteSheet);
        }
        public ISprite CreateYellowLinkBlock()
        {
            return new YellowLinkBlockSprite(hudSpriteSheet);
        }
        public ISprite CreateMiniRoomIcon()
        {
            return new MiniRoomIconSprite(hudSpriteSheet);
        }
        public ISprite CreateGreenLinkLocationIcon()
        {
            return new GreenLinkLocationSprite(hudSpriteSheet);
        }
        public ISprite CreateWinLocationIcon()
        {
            return new WinLocationSprite(hudSpriteSheet);
        }
        public ISprite CreateFluteIcon()
        {
            return new FluteIconSprite(hudSpriteSheet);
        }
    }
}
