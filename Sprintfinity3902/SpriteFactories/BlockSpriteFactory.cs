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

        private static string BLOCK_FILE_NAME = "Zelda_Dungeon_1_Map_Transparent";

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
    }
}
