using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class SpikeEnemy : AbstractEntity
    {
        private int count;
        private int distance;
        private bool movingLeft;
        private bool wait;
        public SpikeEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSpikeEnemy();
            Position = new Vector2(750, 540);

            movingLeft = true;
            wait = false;
            count = 0;
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
    }
}
