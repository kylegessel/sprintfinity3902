using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class SpottedBlock : AbstractEntity
    {
        public SpottedBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateSpottedBlock();
            Position = new Vector2(300, 700);
        }
    }
}