using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class FireAttack : AbstractEntity, IEnemy
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
            Sprite.Update(gameTime);

            if (isMoving)
                Move();
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (isMoving)
                Sprite.Draw(spriteBatch, Position, Color.White);
        }

        public override void Move()
        {
            //Implement 2 count integers that handle spread

            this.X = X - 1.5f * Global.Var.SCALE;

            if(this.direction == 1) //UP
                this.Y = Y - .7f * Global.Var.SCALE;

            if(this.direction == 2) //DOWN
                this.Y = Y + .7f * Global.Var.SCALE;
        }

        public void StartOver(Vector2 position)
        {
            Position = position;
        }

        public void StartMoving()
        {
            this.isMoving = true;
        }

        public void StopMoving()
        {
            this.isMoving = false;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            // If any type of hit, delete the attack.
            return 0;
        }
    }
}
