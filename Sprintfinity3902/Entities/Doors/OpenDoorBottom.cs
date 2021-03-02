using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class OpenDoorBottom : AbstractEntity
    {
        public OpenDoorBottom()
        {
            Sprite = BlockSpriteFactory.Instance.CreateOpenDoorBottom();
            Position = new Vector2(300, 700);
        }
        public OpenDoorBottom(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateOpenDoorBottom();
            Position = pos;
        }
    }
}