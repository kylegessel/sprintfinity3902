using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class SkeletonEnemy : AbstractEntity, IEnemy
    {
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
            counter = count % 12;
            if (counter < 3)
            {
                color = Color.Aqua;
            }
            else if (counter < 6)
            {
                color = Color.Red;
            }
            else if (counter < 9)
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
            
            if(count == 0)
            {
                waitTime = rd1.Next(40, 240);
                count++;
            }
            else if(count == waitTime)
            {
                direction = intToDirection(rd1.Next(1, 5));
                count = 0;
                speed = 0.4f;
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

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            health = health - damage;
            count = 1;
            waitTime = 30;
            direction = projDirection;
            speed = 1f;
            decorate = true;
            return health;
        }
    }
}
