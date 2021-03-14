using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Map : AbstractEntity
    {
        public Map(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateMapSprite();
            Position = pos;
        }
    }
}
