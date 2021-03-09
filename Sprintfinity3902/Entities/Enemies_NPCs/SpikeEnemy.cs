using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class SpikeEnemy : AbstractEntity
    {
        private int count;
        private int distance;
        private int rectangleCycle;
        private bool movingLeft;
        private bool wait;
        public SpikeEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Position = new Vector2(750, 540);

            movingLeft = true;
            wait = false;
            count = 0;
            rectangleCycle = 1;
            distance = 70;
        }
        public SpikeEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Position = pos;

            movingLeft = true;
            wait = false;
            count = 0;
            distance = 70;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Move();
        }

        public override void Move()
        {
            if(count == distance)
            {
                count = 0;
                if (wait)
                {
                    movingLeft = !movingLeft;
                }
                wait = !wait;
            }

            if (wait)
            {

            }
            else if (movingLeft)
            {
                X = X - 2 * Global.Var.SCALE;
            }
            else if (movingLeft == false)
            {
                X = X + 2 * Global.Var.SCALE ;
            }
            count++;
        }

        public override Rectangle GetBoundingRect()
        {
            if(rectangleCycle == 1)
            {
                rectangleCycle++;
                return new Rectangle((int)Position.X, (int)Position.Y, 161 * Global.Var.SCALE, 18 * Global.Var.SCALE);
            }
            else
            {
                rectangleCycle = 1;
                return new Rectangle((int)Position.X, (int)Position.Y, 24 * Global.Var.SCALE, 83 * Global.Var.SCALE);
            }
        }
    }
}
