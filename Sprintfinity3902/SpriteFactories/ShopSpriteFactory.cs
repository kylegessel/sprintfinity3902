using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.SpriteFactories
{
    public class ShopSpriteFactory
    {
        private Texture2D shopSpriteSheet;
        private static ShopSpriteFactory instance;
        private static string ITEM_FILE_NAME = "Zelda_Items_and_Weapons_Transparent";
        
        public ISprite shop { get; set; }

        public static ShopSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShopSpriteFactory();
                }
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            shopSpriteSheet = content.Load<Texture2D>(ITEM_FILE_NAME);
        }

        public List<ISprite> CreateHeartShopSprite()
        {
            //return new HeartShopSprite(shopSpriteSheet);
            
            List<ISprite> list = new List<ISprite>();
            list.Add(ItemSpriteFactory.Instance.CreateHeartItem());
            list.Add(HudSpriteFactory.Instance.CreateLetterX());
            list.Add(HudSpriteFactory.Instance.CreateNumber5());

            return list;  
        }

        public List<ISprite> CreateHeartContainerShopSprite()
        {
            List<ISprite> list = new List<ISprite>();
            list.Add(ItemSpriteFactory.Instance.CreateHeartContainerItem());
            list.Add(HudSpriteFactory.Instance.CreateLetterX());
            list.Add(HudSpriteFactory.Instance.CreateNumber5());

            return list;
        }

        public List<ISprite> CreateBombShopSprite()
        {
            List<ISprite> list = new List<ISprite>();
            list.Add(ItemSpriteFactory.Instance.CreateBombItem());
            list.Add(HudSpriteFactory.Instance.CreateLetterX());
            list.Add(HudSpriteFactory.Instance.CreateNumber5());

            return list;
        }

    }
}
