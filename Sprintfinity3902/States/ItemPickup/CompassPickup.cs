using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class CompassPickup : IPickup
    {
        public CompassPickup()
        { 

        }

        public void Pickup(Player Link)
        {
            if (Link.LinkHealth < Link.MaxHealth)
            {
                Link.LinkHealth++;
            }
        }

    }
}
