using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BombItem : AbstractEntity {
        public BombItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Position = new Vector2(800, 600);
            
        }

        public override void Move() {
            /*Move me*/
        }
    }
}
