using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class InGameHudEntity : AbstractEntity
    {
        public InGameHudEntity(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateInGameHud();
            Position = pos;
        }
    }
}
