using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class MapPickup : IPickup
    {
        public MapPickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            //BuildMapHUD();
            Link.itemcount[IItem.ITEMS.MAP]++;
            //add Map HUD
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            return false;

        }

    }
}
