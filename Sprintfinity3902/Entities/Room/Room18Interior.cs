using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Room18Interior : AbstractEntity
    {
        public Room18Interior(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRoom18Interior();
            Position = pos;
        }
    }
}
