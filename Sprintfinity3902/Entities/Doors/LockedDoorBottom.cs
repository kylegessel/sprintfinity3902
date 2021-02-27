using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class LockedDoorBottom : AbstractEntity
    {
        public LockedDoorBottom()
        {
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorBottom();
            Position = new Vector2(300, 700);
        }
        public LockedDoorBottom(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorBottom();
            Position = pos;
        }
    }
}