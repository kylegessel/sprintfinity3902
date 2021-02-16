using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;

namespace Sprintfinity3902.SpriteFactories
{
    public class PlayerSpriteFactory
    {
        private Texture2D playerSpriteSheet;

        private static PlayerSpriteFactory instance;

        private static string FILE_NAME = "Zelda_Link_and_Items_Transparent";

        public static PlayerSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerSpriteFactory();
                }
                return instance;
            }
        }
        public void LoadAllTextures(ContentManager content)
        {
            playerSpriteSheet = content.Load<Texture2D>(FILE_NAME);
        }

        public ISprite CreateLinkUpSprite()
        {
            return new LinkUpSprite(playerSpriteSheet);
        }
        public ISprite CreateLinkDownSprite()
        {
            return new LinkDownSprite(playerSpriteSheet);
        }
        public ISprite CreateLinkLeftSprite()
        {
            return new LinkLeftSprite(playerSpriteSheet);
        }
        public ISprite CreateLinkRightSprite()
        {
            return new LinkRightSprite(playerSpriteSheet);
        }
        public ISprite CreateLinkDownAttackSprite()
        {
            return new LinkDownAttackSprite(playerSpriteSheet);
        }

        public ISprite CreateLinkUpAttackSprite()
        {
            return new LinkUpAttackSprite(playerSpriteSheet);
        }

        public ISprite CreateLinkRightAttackSprite()
        {
            return new LinkRightAttackSprite(playerSpriteSheet);
        }

        public ISprite CreateLinkLeftAttackSprite()
        {
            return new LinkLeftAttackSprite(playerSpriteSheet);
        }

        public ISprite CreateLinkDownItemSprite()
        {
            return new LinkDownItemSprite(playerSpriteSheet);
        }
        public ISprite CreateLinkUpItemSprite()
        {
            return new LinkUpItemSprite(playerSpriteSheet);
        }
        public ISprite CreateLinkRightItemSprite()
        {
            return new LinkRightItemSprite(playerSpriteSheet);
        }
        public ISprite CreateLinkLeftItemSprite()
        {
            return new LinkLeftItemSprite(playerSpriteSheet);
        }
    }
}
