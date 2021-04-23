using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class Bomb5Pickup : IPickup
    {
        private static int PLUS_5 = 5;
        public Bomb5Pickup()
        {

        }

        public bool Pickup(IPlayer Link)
        {
            if (Link.itemcount[IItem.ITEMS.BOMB] == 0)
            {
                HudMenu.InventoryHud.Instance.EnableItemInInventory(IPlayer.SelectableWeapons.BOMB);
            }

            Link.itemcount[IItem.ITEMS.BOMB] = Link.itemcount[IItem.ITEMS.BOMB] + PLUS_5;

            HudMenu.InGameHud.Instance.UpdateBomb(Link.itemcount[IItem.ITEMS.BOMB]);
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            if (Link.SelectedWeapon == IPlayer.SelectableWeapons.NONE)
            {
                Link.SelectedWeapon = IPlayer.SelectableWeapons.BOMB;
                HudMenu.InGameHud.Instance.UpdateSelectedItems(Link.SelectedWeapon);
            }

            return false;

        }

    }
}
