using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class HeartContainerPickup : IPickup
    {
        public HeartContainerPickup()
        { 

        }

        public void Pickup(Player Link)
        {
            Link.MaxHealth += 2;
            Link.LinkHealth += 2;

        }

    }
}
