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

            return false;
        }

    }
}
