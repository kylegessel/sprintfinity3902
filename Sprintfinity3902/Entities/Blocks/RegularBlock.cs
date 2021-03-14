using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class RegularBlock : AbstractBlock
    {
        /*Can this constructor be deleted?? */
        public RegularBlock()
        {
            Sprite = BlockSpriteFactory.Instance.CreateRegularBlock();
            Position = new Vector2(300, 700);
        }
        public RegularBlock(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRegularBlock();
            Position = pos;
        }
    }
}
