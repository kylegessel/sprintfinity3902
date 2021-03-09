using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class FireAttack : AbstractEntity
    {

        public bool isMoving { get; set; }
        private int direction;

        public FireAttack(int moveDirection)
        {
            Sprite = ItemSpriteFactory.Instance.CreateFireAttack();

            direction = moveDirection;
            isMoving = false;
        }

        public FireAttack(Vector2 position, int moveDirection)
        {
            Sprite = ItemSpriteFactory.Instance.CreateFireAttack();
        
            Position = position;
            direction = moveDirection;
            isMoving = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (isMoving)
            {
                Sprite.Update(gameTime);
                Move();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isMoving)
            {
                Sprite.Draw(spriteBatch, Position, Color.White);
            }
        }

        public override void Move()
        {
            //Implement 2 count integers that handle spread
            isMoving = true;

            X = X - 1.5f * Global.Var.SCALE;

            if(direction == 1) //UP
                Y = Y - .7f * Global.Var.SCALE;

            else if(direction == 2) //DOWN
                Y = Y + .7f * Global.Var.SCALE;
        }

        public void StartOver(Vector2 position)
        {
            Position = position;
        }
    }
}
