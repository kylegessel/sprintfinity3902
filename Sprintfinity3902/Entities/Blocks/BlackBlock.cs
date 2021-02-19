using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BlackBlock : AbstractEntity
    {
        public BlackBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateBlackBlock();
            Position = new Vector2(300, 700);
        }
    }
}