using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class FairyPickup : IPickup
    {
        public FairyPickup()
        { 

        }

        public void Pickup(Player Link)
        {
            Link.LinkHealth = Link.MaxHealth;
            Link.heartChanged = true;

        }

    }
}
