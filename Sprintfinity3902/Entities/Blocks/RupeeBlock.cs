using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class RupeeBlock : AbstractBlock
    {
        private static int X_OFFSET = 4 * Global.Var.SCALE;
        private static int Y_OFFSET = 4 * Global.Var.SCALE;

        private Vector2 RupeePos;

        public RupeeBlock(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRupeeBlock();
            Position = pos;
            RupeePos.X = Position.X - X_OFFSET;
            RupeePos.Y = Position.Y + Y_OFFSET;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, RupeePos, color);
        }

        public override Boolean IsCollidable()
        {
            return false;
        }
    }
}