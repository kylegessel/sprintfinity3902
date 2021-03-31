using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class KeyPickup : IPickup
    {
        public KeyPickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            Link.itemcount[IItem.ITEMS.KEY]++;

            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Heart).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            return false;

        }

    }
}
