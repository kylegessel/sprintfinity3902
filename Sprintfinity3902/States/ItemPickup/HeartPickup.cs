using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class HeartPickup : IPickup
    {
        private const int LOW_HEALTH = 2;
        public HeartPickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            if (Link.LinkHealth < Link.MaxHealth)
            {
                Link.LinkHealth++;
                if (Link.LinkHealth != Link.MaxHealth)
                {
                    Link.LinkHealth++;
                }
                Link.heartChanged = true;
                
            }

            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Heart).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            if(Link.LinkHealth > LOW_HEALTH)
            {
                Link.StopLowHealth();
            }

            return false;
        }

    }
}
