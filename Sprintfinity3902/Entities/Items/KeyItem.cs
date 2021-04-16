using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class KeyItem : AbstractItem
    {
        public KeyItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateKeyItem();
            Position = new Vector2(700, 600);
            ID = IItem.ITEMS.KEY;
        }

        public KeyItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateKeyItem();
            Position = pos;
            ID = IItem.ITEMS.KEY;
        }

        public override bool Pickup(IPlayer Link)
        {
            Link.itemcount[IItem.ITEMS.KEY]++;

            //HudMenu.InGameHud.Instance.UpdateKeys(Link.itemcount[IItem.ITEMS.KEY]);
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Heart).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            return false;
        }
    }
}
