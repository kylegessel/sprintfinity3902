using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BowItem : AbstractItem
    {
        public BowItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBowItem();
            Position = new Vector2(1000, 600);
            ID = IItem.ITEMS.BOW;
        }

        public BowItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateBowItem();
            Position = pos;
            ID = IItem.ITEMS.BOW;
        }

        public override bool Pickup(IPlayer Link)
        {
            //link.bow = true
            // add link bow to HUD AND allow to use
            Link.itemcount[IItem.ITEMS.BOW]++;
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            //HudMenu.InventoryHud.Instance.EnableItemInInventory(IPlayer.SelectableWeapons.BOW);

            if (Link.SelectedWeapon == IPlayer.SelectableWeapons.NONE) {
                Link.SelectedWeapon = IPlayer.SelectableWeapons.BOW;
                //HudMenu.InGameHud.Instance.UpdateSelectedItems(Link.SelectedWeapon);
            }

            return false;
        }
    }
}
