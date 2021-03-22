using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Entities
{
    public class HorizontalWall : AbstractBlock
    {
        public HorizontalWall(Vector2 pos)
        {
            Position = pos;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override Rectangle GetBoundingRect()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 120*Global.Var.SCALE, 32*Global.Var.SCALE);
        }

        public override bool IsTall()
        {
            return true;
        }

    }
}
