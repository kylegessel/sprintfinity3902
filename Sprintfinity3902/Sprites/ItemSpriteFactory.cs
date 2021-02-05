using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("Zelda - Link and Items - Transparent");
        }

        public ISprite CreateBombItem()
        {
            return new BombItemSprite(itemSpriteSheet);
        }
    }
}
