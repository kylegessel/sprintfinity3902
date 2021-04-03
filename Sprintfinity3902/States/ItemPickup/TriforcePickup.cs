using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class TriforcePickup : IPickup
    {
        public TriforcePickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            return true;

        }

    }
}
