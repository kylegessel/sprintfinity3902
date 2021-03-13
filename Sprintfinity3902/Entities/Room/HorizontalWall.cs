using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Global;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

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


    }
}
