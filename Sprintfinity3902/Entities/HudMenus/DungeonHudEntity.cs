using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DungeonHudEntity : AbstractEntity
    {
        public DungeonHudEntity(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateDungeonHud();
            Position = pos;
        }
    }
}
