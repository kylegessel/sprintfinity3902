using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class BlueRupeePickup : IPickup
    {
        private const int BLUE_RUPEE_VALUE = 5;
        public BlueRupeePickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            Link.itemcount[IItem.ITEMS.RUPEE]+=BLUE_RUPEE_VALUE;

            HudMenu.InGameHud.Instance.UpdateRupees(Link.itemcount[IItem.ITEMS.RUPEE]);
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Rupee).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            return false;
        }

    }
}
