using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Global;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class VerticalWall : AbstractBlock
    {

        private static int EIGHTY = 80;
        private static int THIRTY_TWO = 32;
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
            return new Rectangle((int)Position.X, (int)Position.Y, THIRTY_TWO*Global.Var.SCALE, EIGHTY * Global.Var.SCALE);
        }

        public override bool IsTall()
        {
            return true;
        }


    }
}
