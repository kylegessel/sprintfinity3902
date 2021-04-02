using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class CompassPickup : IPickup
    {
        public CompassPickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            //BuildCompassHUD();
            //add compass HUD
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            return false;
        }

    }
}
