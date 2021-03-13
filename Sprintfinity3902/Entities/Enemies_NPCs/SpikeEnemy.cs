using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class SpikeEnemy : AbstractEntity
    {
        private int rectangleCycle;

        private int id; //1 - up left 2 - up right 3 - down left 4 - down right
        public SpikeEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Position = new Vector2(750, 540);

            rectangleCycle = 1;
        }
        public SpikeEnemy(Vector2 pos, int spikeId)
        {
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Position = pos;
            id = spikeId;

        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            //Move();
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if(id == 1)
            {
                Sprite.Draw(spriteBatch, Position, Color.White);
            }
            else if (id == 2)
            {
                Sprite.Draw(spriteBatch, Position, Color.Red);
            }
            else if (id == 3)
            {
                Sprite.Draw(spriteBatch, Position, Color.Blue);
            }
            else if (id == 4)
            {
                Sprite.Draw(spriteBatch, Position, Color.Green);
            }
        }

        public override void Move()
        {

        }

        public override Rectangle GetBoundingRect()
        {
            rectangleCycle++;
            if(rectangleCycle == 1)
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 161 * Global.Var.SCALE, 18 * Global.Var.SCALE);
            }
            else
            {
                rectangleCycle = 0;
                return new Rectangle((int)Position.X, (int)Position.Y, 24 * Global.Var.SCALE, 83 * Global.Var.SCALE);
            }
        }
    }
}
