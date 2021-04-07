using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class FairyPickup : IPickup
    {
        public FairyPickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            Link.LinkHealth = Link.MaxHealth;
            HudMenu.InGameHud.Instance.UpdateHearts(Link.MaxHealth, Link.LinkHealth);
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);


            return false;
        }

    }
}
