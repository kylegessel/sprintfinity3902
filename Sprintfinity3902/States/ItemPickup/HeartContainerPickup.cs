using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class HeartContainerPickup : IPickup
    {
        public HeartContainerPickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            Link.MaxHealth += 2;
            Link.LinkHealth += 2;
            HudMenu.InGameHud.Instance.UpdateHearts(Link.MaxHealth, Link.LinkHealth);
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            Link.openToInput = false;
            Link.UseItem();

            return false;

        }

    }
}
