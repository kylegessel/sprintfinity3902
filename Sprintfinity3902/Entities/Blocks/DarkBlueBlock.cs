using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class DarkBlueBlock : AbstractEntity
    {
        public DarkBlueBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateDarkBlueBlock();
            Position = new Vector2(300, 700);
        }
    }
}