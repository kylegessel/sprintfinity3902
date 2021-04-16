using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class HeartItem : AbstractItem
    {
        private const int LOW_HEALTH = 2;
        public HeartItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateHeartItem();
            Position = new Vector2(300, 600);
            ID = IItem.ITEMS.HEART;
        }

        public HeartItem(Vector2 pos) {
            Sprite = ItemSpriteFactory.Instance.CreateHeartItem();
            Position = pos;
            ID = IItem.ITEMS.HEART;
        }

        public override bool Pickup(IPlayer Link)
        {
            if (Link.LinkHealth < Link.MaxHealth) {
                Link.LinkHealth++;
                if (Link.LinkHealth != Link.MaxHealth) {
                    Link.LinkHealth++;
                }
                //HudMenu.InGameHud.Instance.UpdateHearts(Link.MaxHealth, Link.LinkHealth);

            }

            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Heart).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            if (Link.LinkHealth > LOW_HEALTH) {
                Link.StopLowHealth();
            }

            return false;
        }
    }
}
