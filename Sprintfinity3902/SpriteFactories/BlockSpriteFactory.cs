using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;

namespace Sprintfinity3902.SpriteFactories
{
    public class BlockSpriteFactory
    {
        private Texture2D blockSpriteSheet;
        private Texture2D[] floorSpriteSheets;

        private Texture2D eagleDungeonSprite;
        private Texture2D titleScreenSpriteSheet;

        private static BlockSpriteFactory instance;

        private static string FLOOR_1_FILE_NAME = "Zelda_Dungeon_Tileset_Transparent";
        private static string FLOOR_2_FILE_NAME = "Zelda_Dungeon_Tileset_Green_Transparent";
        private static string FLOOR_3_FILE_NAME = "Zelda_Dungeon_Tileset_Yellow_Transparent";
        private static string FLOOR_4_FILE_NAME = "Zelda_Dungeon_Tileset_Red_Transparent";
        private static string FLOOR_5_FILE_NAME = "Zelda_Dungeon_Tileset_Gray_Transparent";

        //private static string BLOCK_FILE_NAME = "Zelda_Dungeon_Tileset_Green_Transparent";
        private static string EAGLE_FILE_NAME = "Zelda_Eagle-Map";
        private static string TITLE_SCREEN_SPRITE = "Zelda_FullTitleScreen_Transparent";

        public static BlockSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BlockSpriteFactory();
                }
                return instance;
            }
        }

        /* Blocks */
        public void LoadAllTextures(ContentManager content)
        {
            floorSpriteSheets = new Texture2D[5];
            floorSpriteSheets[0] = content.Load<Texture2D>(FLOOR_1_FILE_NAME);
            floorSpriteSheets[1] = content.Load<Texture2D>(FLOOR_2_FILE_NAME);
            floorSpriteSheets[2] = content.Load<Texture2D>(FLOOR_3_FILE_NAME);
            floorSpriteSheets[3] = content.Load<Texture2D>(FLOOR_4_FILE_NAME);
            floorSpriteSheets[4] = content.Load<Texture2D>(FLOOR_5_FILE_NAME);

            eagleDungeonSprite = content.Load<Texture2D>(EAGLE_FILE_NAME);
            titleScreenSpriteSheet = content.Load<Texture2D>(TITLE_SCREEN_SPRITE);
            blockSpriteSheet = floorSpriteSheets[0];
        }

        public void UpdateFloorSheet()
        {
            blockSpriteSheet = floorSpriteSheets[Global.Var.floor-1];
        }

        public ISprite CreateRegularBlock()
        {
            return new RegularBlockSprite(blockSpriteSheet);
        }

        public ISprite CreateFloorBlock()
        {
            return new FloorBlockSprite(blockSpriteSheet);
        }
        public ISprite CreateFace1Block()
        {
            return new Face1BlockSprite(blockSpriteSheet);
        }
        public ISprite CreateFace2Block()
        {
            return new Face2BlockSprite(blockSpriteSheet);
        }
        public ISprite CreateStairsBlock()
        {
            return new StairsBlockSprite(blockSpriteSheet);
        }
        public ISprite CreateBrickBlock()
        {
            return new BrickBlockSprite(blockSpriteSheet);
        }
        public ISprite CreateStripeBlock()
        {
            return new StripeBlockSprite(blockSpriteSheet);
        }
        public ISprite CreateBlackBlock()
        {
            return new BlackBlockSprite(blockSpriteSheet);
        }
        public ISprite CreateSpottedBlock()
        {
            return new SpottedBlockSprite(blockSpriteSheet);
        }
        public ISprite CreateDarkBlueBlock()
        {
            return new DarkBlueBlockSprite(blockSpriteSheet);
        }

        /*Doors*/
        public ISprite CreateOpenDoorLeft()
        {
            return new OpenDoorLeftSprite(blockSpriteSheet);
        }
        public ISprite CreateOpenDoorRight()
        {
            return new OpenDoorRightSprite(blockSpriteSheet);
        }
        public ISprite CreateOpenDoorTop()
        {
            return new OpenDoorTopSprite(blockSpriteSheet);
        }
        public ISprite CreateOpenDoorBottom()
        {
            return new OpenDoorBottomSprite(blockSpriteSheet);
        }
        public ISprite CreateClosedDoorLeft()
        {
            return new ClosedDoorLeftSprite(blockSpriteSheet);
        }
        public ISprite CreateClosedDoorRight()
        {
            return new ClosedDoorRightSprite(blockSpriteSheet);
        }
        public ISprite CreateClosedDoorTop()
        {
            return new ClosedDoorTopSprite(blockSpriteSheet);
        }
        public ISprite CreateClosedDoorBottom()
        {
            return new ClosedDoorBottomSprite(blockSpriteSheet);
        }
        public ISprite CreateLockedDoorLeft()
        {
            return new LockedDoorLeftSprite(blockSpriteSheet);
        }
        public ISprite CreateLockedDoorRight()
        {
            return new LockedDoorRightSprite(blockSpriteSheet);
        }
        public ISprite CreateLockedDoorTop()
        {
            return new LockedDoorTopSprite(blockSpriteSheet);
        }
        public ISprite CreateLockedDoorBottom()
        {
            return new LockedDoorBottomSprite(blockSpriteSheet);
        }
        public ISprite CreateHoleDoorLeft()
        {
            return new HoleDoorLeftSprite(blockSpriteSheet);
        }
        public ISprite CreateHoleDoorRight()
        {
            return new HoleDoorRightSprite(blockSpriteSheet);
        }
        public ISprite CreateHoleDoorTop()
        {
            return new HoleDoorTopSprite(blockSpriteSheet);
        }
        public ISprite CreateHoleDoorBottom()
        {
            return new HoleDoorBottomSprite(blockSpriteSheet);
        }
        public ISprite CreateWallLeft()
        {
            return new WallLeftSprite(blockSpriteSheet);
        }
        public ISprite CreateWallRight()
        {
            return new WallRightSprite(blockSpriteSheet);
        }
        public ISprite CreateWallTop()
        {
            return new WallTopSprite(blockSpriteSheet);
        }
        public ISprite CreateWallBottom()
        {
            return new WallBottomSprite(blockSpriteSheet);
        }


        /*Room*/
        public ISprite CreateRoomExterior()
        {
            return new RoomExteriorSprite(blockSpriteSheet);
        }
        public ISprite CreateRoomInterior()
        {
            return new RoomInteriorSprite(blockSpriteSheet);
        }
        public ISprite CreateRoom8Interior()
        {
            return new Room8InteriorSprite(blockSpriteSheet);
        }
        public ISprite CreateRoom8Text()
        {
            return new Room8TextSprite(eagleDungeonSprite);
        }
        public ISprite CreateRoom13()
        {
            return new Room13Sprite(blockSpriteSheet);
        }

        /*TitleScreen*/
        public ISprite CreateTitleScreen()
        {
            return new TitleScreenSprite(titleScreenSpriteSheet);
        }
    }
}
