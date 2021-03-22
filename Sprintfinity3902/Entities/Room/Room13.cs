using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Room13 : AbstractBlock
    {
        public Room13(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRoom13();
            Position = pos;
        }

        public override bool IsCollidable()
        {
            return false;
        }
    }
}
