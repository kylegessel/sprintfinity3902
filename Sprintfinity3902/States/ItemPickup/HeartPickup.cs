using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class HeartPickup : IPickup
    {
        public HeartPickup()
        { 

        }

        public void Pickup(Player Link)
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
        }

    }
}
