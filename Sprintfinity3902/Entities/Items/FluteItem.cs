using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class FluteItem : AbstractItem
    {

        public FluteItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateFluteItem();
            Position = pos;
            ID = IItem.ITEMS.FLUTE;
        }

        public override bool Pickup(IPlayer link, IHud parent)
        {
            ((InventoryHud)((DungeonHud)parent).Inventory).EnableItemInInventory(IPlayer.SelectableWeapons.FLUTE);

            link.itemcount[IItem.ITEMS.FLUTE]++;
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            if (link.SelectedWeapon == IPlayer.SelectableWeapons.NONE) {
                link.SelectedWeapon = IPlayer.SelectableWeapons.FLUTE;
                ((InGameHud)((DungeonHud)parent).InGame).UpdateSelectedItems(link.SelectedWeapon);
            }

            return false;
        }
    }
}
