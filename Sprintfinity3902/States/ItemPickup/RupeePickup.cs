using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class RupeePickup : IPickup
    {
        public RupeePickup()
        { 

        }

        public void Pickup(Player Link)
        {
            if (Link.itemcount.ContainsKey(IItem.ITEMS.RUPEE))
            {
                Link.itemcount[IItem.ITEMS.RUPEE]++;
            }
            else
            {
                Link.itemcount.Add(IItem.ITEMS.RUPEE, 1);
            }

            Link.itemPickedUp = true;

        }

    }
}
