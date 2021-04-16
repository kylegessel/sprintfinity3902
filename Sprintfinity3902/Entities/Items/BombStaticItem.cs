﻿using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BombStaticItem : AbstractItem
    {
        public BombStaticItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Position = new Vector2(700, 600);
            ID = IItem.ITEMS.BOMB;
        }

        public BombStaticItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Position = pos;
            ID = IItem.ITEMS.BOMB;
        }

        public override bool Pickup(IPlayer Link, IHud parent)
        {
            if (Link.itemcount[IItem.ITEMS.BOMB] == 0) {
                ((InventoryHud)((DungeonHud)parent).Inventory).EnableItemInInventory(IPlayer.SelectableWeapons.BOMB);
            }

            Link.itemcount[IItem.ITEMS.BOMB]++;

            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            if (Link.SelectedWeapon == IPlayer.SelectableWeapons.NONE) {
                Link.SelectedWeapon = IPlayer.SelectableWeapons.BOMB;
            }

            return false;
        }
    }
}
