using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;

namespace Sprintfinity3902.SpriteFactories
{
    public class BlockSpriteFactory
    {
        private Texture2D blockSpriteSheet;

        private static BlockSpriteFactory instance;

        private static string BLOCK_FILE_NAME = "Zelda_Dungeon_Tileset_Transparent";

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
            blockSpriteSheet = content.Load<Texture2D>(BLOCK_FILE_NAME);
        }

        public ISprite CreateRegularBlock()
        {
            return new RegularBlockSprite(blockSpriteSheet);
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
    }
}
