using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class BoomerangPickup : IPickup
    {
        public BoomerangPickup()
        { 

        }

        public bool Pickup(Player Link)
        {
            //ASDFASDF
            Link.itemcount[IItem.ITEMS.BOOMERANG]++;
            return false;
        }

    }
}
