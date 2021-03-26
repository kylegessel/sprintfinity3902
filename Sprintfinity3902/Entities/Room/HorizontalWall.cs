using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Entities
{
    public class HorizontalWall : AbstractBlock
    {

        private static int THIRTY_TWO = 32;
        private static int ONE_HUNDRED_TWENTY = 120;
        

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
            return new Rectangle((int)Position.X, (int)Position.Y, ONE_HUNDRED_TWENTY*Global.Var.SCALE, THIRTY_TWO*Global.Var.SCALE);
        }

        public override bool IsTall()
        {
            return true;
        }

    }
}
