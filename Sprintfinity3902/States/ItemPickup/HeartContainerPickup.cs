using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class HeartContainerPickup : IPickup
    {
        public HeartContainerPickup()
        { 

        }

        public bool Pickup(Player Link)
        {
            Link.MaxHealth += 2;
            Link.LinkHealth += 2;
            Link.heartChanged = true;
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Heart).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            return false;

        }

    }
}
