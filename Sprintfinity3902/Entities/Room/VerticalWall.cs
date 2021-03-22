using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Entities
{
    public class VerticalWall : AbstractBlock
    {
        public VerticalWall(Vector2 pos)
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
            return new Rectangle((int)Position.X, (int)Position.Y, 32*Global.Var.SCALE, 80*Global.Var.SCALE);
        }

        public override bool IsTall()
        {
            return true;
        }


    }
}
