using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class HoleDoorBottom : AbstractEntity
    {
        public HoleDoorBottom()
        {
            Sprite = BlockSpriteFactory.Instance.CreateHoleDoorBottom();
            Position = new Vector2(300, 700);
        }
        public HoleDoorBottom(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateHoleDoorBottom();
            Position = pos;
        }
    }
}