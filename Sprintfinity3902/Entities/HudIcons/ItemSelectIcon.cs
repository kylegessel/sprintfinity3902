using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class ItemSelectIcon : AbstractEntity
    {
        public ItemSelectIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateItemSelectIcon();
            Position = pos;
        }
    }
}
