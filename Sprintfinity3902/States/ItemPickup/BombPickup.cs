using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class BombPickup : IPickup
    {
        public BombPickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            Link.itemcount[IItem.ITEMS.BOMB]++;


            HudMenu.InGameHud.Instance.UpdateBomb(Link.itemcount[IItem.ITEMS.BOMB]);
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            return false;

        }

    }
}
