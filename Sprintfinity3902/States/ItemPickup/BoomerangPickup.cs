using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class BoomerangPickup : IPickup
    {
        public BoomerangPickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            Link.itemcount[IItem.ITEMS.BOOMERANG]++;
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            HudMenu.InventoryHud.Instance.EnableItemInInventory(IPlayer.SelectableWeapons.BOOMERANG);

            if (Link.SelectedWeapon == IPlayer.SelectableWeapons.NONE)
            {
                Link.SelectedWeapon = IPlayer.SelectableWeapons.BOOMERANG;
                HudMenu.InGameHud.Instance.UpdateSelectedItems(Link.SelectedWeapon);
            }

            

            return false;
        }

    }
}
