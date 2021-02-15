using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class KeyItem : AbstractEntity
    {
        public KeyItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateKeyItem();
            Position = new Vector2(700, 600);
        }
    }
}
