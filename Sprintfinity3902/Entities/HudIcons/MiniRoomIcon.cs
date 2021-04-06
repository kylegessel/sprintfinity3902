using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class MiniRoomIcon : AbstractEntity
    {
        public MiniRoomIcon(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateMiniRoomIcon();
            Position = pos;
        }
    }
}
