using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class AttackPowerUpPickup : IPickup
    {
        public AttackPowerUpPickup()
        {

        }

        public bool Pickup(IPlayer Link)
        {
            if (Link.itemcount[IItem.ITEMS.ATTACKPWRUP] < 10)
            {
                Link.itemcount[IItem.ITEMS.ATTACKPWRUP]++;
            }

            HudMenu.InGameHud.Instance.UpdateCrit(Link.itemcount[IItem.ITEMS.ATTACKPWRUP]);
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            return false;
        }

    }
}
