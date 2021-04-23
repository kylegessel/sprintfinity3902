using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class RupeeBlock : AbstractBlock
    {
        private static Vector2 OFFSET = new Vector2(4 * Global.Var.SCALE, 4 * Global.Var.SCALE);

        public RupeeBlock(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRupeeBlock();
            Position = pos;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position - OFFSET, color);
        }

        public override Boolean IsCollidable()
        {
            return false;
        }
    }
}