using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class ClosedDoorBottom : AbstractEntity
    {
        public ClosedDoorBottom()
        {
            Sprite = BlockSpriteFactory.Instance.CreateClosedDoorBottom();
            Position = new Vector2(300, 700);
        }
    }
}