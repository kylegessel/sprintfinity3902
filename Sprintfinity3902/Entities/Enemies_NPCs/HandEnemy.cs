using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class HandEnemy : AbstractEntity, IEnemy
    {
        private int count;
        private Direction direction;
        private int waitTime;
        private int health;
        private int counter;
        private float speed;
        private Boolean decorate;
        private int enemyID;
        public HandEnemy()
        {
            Sprite = EnemySpriteFactory.Instance.CreateHandEnemy();
            Position = new Vector2(750, 540);
            health = 3;
            speed = .2f;
            color = Color.White;
        }
        public HandEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateHandEnemy();
            Position = pos;
            health = 3;
            speed = .2f;
            color = Color.White;

        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, this.color);
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            this.enemyID = enemyID;
            health = health - damage;
            count = 1;
            waitTime = 30;
            decorate = true;
            direction = projDirection;
            speed = 1f;
            return health;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Move();
            SetStepSize(speed);
            if (decorate) Decorate();
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

        public override void Move()
        {
            if (count == 0)
            {
                waitTime = new Random().Next(60, 220);
                count++;
            }
            else if (count == waitTime)
            {
                direction = intToDirection(new Random().Next(1, 5));
                speed = 0.2f;
                count = 0;
                if (decorate)
                {
                    decorate = false;
                    color = Color.White;
                }
            }

            if (direction == Direction.LEFT) //Left
            {
                X = X - speed * Global.Var.SCALE;
            }
            else if (direction == Direction.RIGHT) //Right
            {
                X = X + speed * Global.Var.SCALE;
            }
            else if (direction == Direction.UP) //Up
            {
                Y = Y - speed * Global.Var.SCALE;
            }
            else if (direction == Direction.DOWN) //Down
            {
                Y = Y + speed * Global.Var.SCALE;
            }
            count++;
        }
    }
}
