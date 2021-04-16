using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class HeartContainerItem : AbstractItem
    {
        public HeartContainerItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateHeartContainerItem();
            Position = new Vector2(400, 600);
            ID = IItem.ITEMS.HEART;
        }

        public HeartContainerItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateHeartContainerItem();
            Position = pos;
            ID = IItem.ITEMS.HEART;
        }

        public override bool Pickup(IPlayer Link)
        {
            Link.MaxHealth += 2;
            Link.LinkHealth += 2;
            //HudMenu.InGameHud.Instance.UpdateHearts(Link.MaxHealth, Link.LinkHealth);
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            return false;
        }
    }
}
