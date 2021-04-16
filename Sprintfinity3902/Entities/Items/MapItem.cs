using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class MapItem : AbstractItem
    {
        public MapItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateMapItem();
            Position = new Vector2(600, 600);
            ID = IItem.ITEMS.MAP;
        }

        public MapItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateMapItem();
            Position = pos;
            ID = IItem.ITEMS.MAP;
        }

        public override bool Pickup(IPlayer Link)
        {
            //BuildMapHUD();
            Link.itemcount[IItem.ITEMS.MAP]++;
            //add Map HUD
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            return false;
        }
    }
}
