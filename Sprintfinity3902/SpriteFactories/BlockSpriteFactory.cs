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

        public ISprite CreateOpenDoorLeft()
        {
            return new OpenDoorLeftSprite();
        }
        public ISprite CreateOpenDoorRight()
        {
            return new OpenDoorRightSprite();
        }
        public ISprite CreateOpenDoorTop()
        {
            return new OpenDoorTopSprite();
        }
        public ISprite CreateOpenDoorBottom()
        {
            return new OpenDoorBottomSprite();
        }
        public ISprite CreateClosedDoorLeft()
        {
            return new ClosedDoorLeftSprite();
        }
        public ISprite CreateClosedDoorRight()
        {
            return new ClosedDoorRightSprite();
        }
        public ISprite CreateClosedDoorTop()
        {
            return new ClosedDoorTopSprite();
        }
        public ISprite CreateClosedDoorBottom()
        {
            return new ClosedDoorBottomSprite();
        }
        public ISprite CreateLockedDoorLeft()
        {
            return new LockedDoorLeftSprite();
        }
        public ISprite CreateLockedDoorRight()
        {
            return new LockedDoorRightSprite();
        }
        public ISprite CreateLockedDoorTop()
        {
            return new LockedDoorTopSprite();
        }
        public ISprite CreateLockedDoorBottom()
        {
            return new LockedDoorBottomSprite();
        }
        public ISprite CreateHoleDoorLeft()
        {
            return new HoleDoorLeftSprite();
        }
        public ISprite CreateHoleDoorRight()
        {
            return new HoleDoorRightSprite();
        }
        public ISprite CreateHoleDoorTop()
        {
            return new HoleDoorTopSprite();
        }
        public ISprite CreateHoleDoorBottom()
        {
            return new HoleDoorBottomSprite();
        }
    }
}
