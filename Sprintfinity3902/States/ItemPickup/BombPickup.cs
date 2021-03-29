using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class BombPickup : IPickup
    {
        public BombPickup()
        { 

        }

        public bool Pickup(Player Link)
        {
            if (Link.itemcount.ContainsKey(IItem.ITEMS.BOMB))
            {
                Link.itemcount[IItem.ITEMS.BOMB]++;
            }
            else
            {
                Link.itemcount.Add(IItem.ITEMS.BOMB, 1);
            }

            Link.itemPickedUp = true;
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            return false;

        }

    }
}
