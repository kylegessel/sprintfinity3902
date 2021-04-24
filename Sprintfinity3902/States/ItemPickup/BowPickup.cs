using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class BowPickup : IPickup
    {
        public BowPickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            //link.bow = true
            // add link bow to HUD AND allow to use
            Link.itemcount[IItem.ITEMS.BOW]++;
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            HudMenu.InventoryHud.Instance.EnableItemInInventory(IPlayer.SelectableWeapons.BOW);
            Link.openToInput = false;
            Link.UseItem();

            if (Link.SelectedWeapon == IPlayer.SelectableWeapons.NONE)
            {
                Link.SelectedWeapon = IPlayer.SelectableWeapons.BOW;
                HudMenu.InGameHud.Instance.UpdateSelectedItems(Link.SelectedWeapon);
            }

            return false;
        }

    }
}
