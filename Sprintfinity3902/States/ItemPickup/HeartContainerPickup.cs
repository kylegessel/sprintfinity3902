using Sprintfinity3902.Link;
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
            Link.heartChanged = true;
            

            return false;

        }

    }
}
