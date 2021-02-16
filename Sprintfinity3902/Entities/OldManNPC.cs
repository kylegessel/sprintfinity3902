using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class OldManNPC : AbstractEntity
    {
        public OldManNPC()
        {
            Sprite = EnemySpriteFactory.Instance.CreateOldManNPC();
            Position = new Vector2(1100, 500);
        }
    }
}
