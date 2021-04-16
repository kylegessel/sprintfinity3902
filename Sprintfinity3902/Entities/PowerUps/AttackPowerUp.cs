using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class AttackPowerUpItem : AbstractItem
    {
        public AttackPowerUpItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateAttackPowerUpItem();
            Position = new Vector2(200, 600);
            ID = IItem.ITEMS.ATTACKPWRUP;
        }

        public AttackPowerUpItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateAttackPowerUpItem();
            Position = pos;
            ID = IItem.ITEMS.ATTACKPWRUP;
        }
    }
}
