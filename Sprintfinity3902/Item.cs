using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902
{
    public class Item
    {
        public ISprite CurrentItemSprite { get; set; }
        public ItemSpriteFactory ItemFactory { get; set; }

        public Item()
        {
            ItemFactory = ItemSpriteFactory.Instance;
        }

        public void getItem()
        {
            CurrentItemSprite = ItemFactory.CreateBombItem();
        }
    }


}

