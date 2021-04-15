using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class SkeletonEnemy : AbstractEntity, IEnemy
    {

        private static int ONE = 1;
        private static int FIVE = 5;
        private static int MOD_BOUND = 12;
        private static int SIX = 6;
        private static int NINE = 9;
        private static int THIRTY = 30;
        private static int THREE = 3;
        private static int TWO_HUNDRED_FORTY  = 240;
        private static int FORTY = 40;
        private static float F_DOT_FOUR = .4f;

        private Random rd1 = new Random();
        private int count;
        private Direction direction;
        private int waitTime;
        private int health;
        private float speed;
        private int counter;
        private bool decorate;
        

        public SkeletonEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = new Vector2(750, 540);
            direction = intToDirection(rd1.Next(1, 5));
            count = 0;
            health = 2;
            speed = 0.4f;
            color = Color.White;
            decorate = false;
        }
        public SkeletonEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            Position = pos;
            direction = intToDirection(rd1.Next(1, 5));
            count = 0;
            health = 2;
            speed = 0.4f;
            color = Color.White;
            decorate = false;
        }
        public void Decorate()
        {
            counter = count % MOD_BOUND;
            if (counter < THREE)
            {
                color = Color.Aqua;
            }
            else if (counter < SIX)
            {
                color = Color.Red;
            }
            else if (counter < NINE)
            {
                color = Color.White;
            }
            else
            {
                color = Color.Blue;
            }
        }
        public override void Update(GameTime gameTime) {
            Sprite.Update(gameTime);
            Move();
            // We have an implementation for a entity decorator, but I had trouble getting them to collide.
            // This isn't how we will continue to do this, but for the time being this works.
            if (decorate) Decorate();
            SetStepSize(speed);
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, this.color);
        }
        public override void Move()
        {
            
            if(count == Global.Var.ZERO)
            {
                waitTime = rd1.Next(FORTY, TWO_HUNDRED_FORTY);
                count++;
            }
            else if(count == waitTime)
            {
                direction = intToDirection(rd1.Next(ONE, FIVE));
                count = Global.Var.ZERO;
                speed = F_DOT_FOUR;
                decorate = false;
            }

            if (direction == Direction.LEFT) //Left
            {
                X = X - speed * Global.Var.SCALE;
            }
            else if(direction == Direction.RIGHT) //Right
            {
                X = X + speed * Global.Var.SCALE;
            }
            else if(direction == Direction.UP) //Up
            {
                Y = Y - speed * Global.Var.SCALE;
            }
            else if(direction == Direction.DOWN) //Down
            {
                Y = Y + speed * Global.Var.SCALE;
            }
            count++;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            health = health - damage;
            count = 1;
            waitTime = THIRTY;
            direction = projDirection;
            speed = (float)ONE;
            decorate = true;
            return health;
        }
    }
}
