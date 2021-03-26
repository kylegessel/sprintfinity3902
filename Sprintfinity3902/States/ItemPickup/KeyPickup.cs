using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class KeyPickup : IPickup
    {
        public KeyPickup()
        { 

        }

        public void Pickup(Player Link)
        {

            if (Link.itemcount.ContainsKey(IItem.ITEMS.KEY))
            {
                Link.itemcount[IItem.ITEMS.KEY]++;
            }
            else
            {
                Link.itemcount.Add(IItem.ITEMS.KEY, 1);
            }

            Link.itemPickedUp = true;

        }

    }
}
