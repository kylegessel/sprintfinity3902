using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class MapPickup : IPickup
    {
        public MapPickup()
        { 

        }

        public bool Pickup(IPlayer Link)
        {
            HudMenu.DungeonHud.Instance.MapPickedUp();
            Link.itemcount[IItem.ITEMS.MAP]++;
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            return false;

        }

    }
}
