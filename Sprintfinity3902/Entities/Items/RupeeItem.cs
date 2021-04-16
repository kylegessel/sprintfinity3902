using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class RupeeItem : AbstractItem
    {
        public RupeeItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateRupeeItem();
            Position = new Vector2(200, 600);
            ID = IItem.ITEMS.RUPEE;
        }

        public RupeeItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateRupeeItem();
            Position = pos;
            ID = IItem.ITEMS.RUPEE;
        }

        public override bool Pickup(IPlayer Link, IHud parent)
        {
            Link.itemcount[IItem.ITEMS.RUPEE]++;

            //HudMenu.InGameHud.Instance.UpdateRupees(Link.itemcount[IItem.ITEMS.RUPEE]);
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Rupee).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            return false;
        }
    }
}
