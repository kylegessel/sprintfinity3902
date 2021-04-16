using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BoomerangStaticItem : AbstractItem
    {
        public BoomerangStaticItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBoomerangStaticItem();
            Position = new Vector2(700, 600);
            ID = IItem.ITEMS.BOOMERANG;
        }

        public BoomerangStaticItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateBoomerangStaticItem();
            Position = pos;
            ID = IItem.ITEMS.BOOMERANG;
        }

        public override bool Pickup(IPlayer Link)
        {
            Link.itemcount[IItem.ITEMS.BOOMERANG]++;
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            //HudMenu.InventoryHud.Instance.EnableItemInInventory(IPlayer.SelectableWeapons.BOOMERANG);

            if (Link.SelectedWeapon == IPlayer.SelectableWeapons.NONE) {
                Link.SelectedWeapon = IPlayer.SelectableWeapons.BOOMERANG;
                //HudMenu.InGameHud.Instance.UpdateSelectedItems(Link.SelectedWeapon);
            }



            return false;
        }
    }
}
