using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class ManhandlaBoss : AbstractEntity, IEnemy
    {
        private const int TWO = 2;
        private const int UPPER_BOUND = 200;
        private const int LOWER_BOUND = 40;
        private const float SPEED_INCREASE = .2f;
        public const float FINAL_SPEED = 1f;

        private const int LEFT = 1;
        private const int RIGHT = 2;
        private const int UP = 3;
        private const int DOWN = 4;
        private const int DOWN_RIGHT = 5;
        private const int DOWN_LEFT = 6;
        private const int UP_LEFT = 7;
        private const int UP_RIGHT = 8;

        private const int UP_BOUND = 119;
        private const int LEFT_BOUND = 56;
        private const int RIGHT_BOUND = 188;
        private const int DOWN_BOUND = 172;

        private Random rand = new Random();
        private int count;
        private int direction;
        private int waitTime;
        public float speed;

        private ManhandlaMouthDown downMouth;
        private ManhandlaMouthLeft leftMouth;
        private ManhandlaMouthRight rightMouth;
        private ManhandlaMouthUp upMouth;
        public int EnemyHealth { get; set; }
        public int EnemyAttack { get; set; }


        public ManhandlaBoss(Vector2 pos, IEntity down, IEntity left, IEntity right, IEntity up)
        {
            Sprite = EnemySpriteFactory.Instance.CreateManhandlaBody();
            Position = pos;
            this.color = Color.White;
            direction = LEFT;
            count = 0;
            speed = .2f;
            EnemyHealth = 0;
            EnemyAttack = 1;
            SetStepSize(speed);

            downMouth = (ManhandlaMouthDown) down;
            leftMouth = (ManhandlaMouthLeft) left;
            rightMouth = (ManhandlaMouthRight) right;
            upMouth = (ManhandlaMouthUp) up;
            downMouth.GiveManhandla(this);
            leftMouth.GiveManhandla(this);
            rightMouth.GiveManhandla(this);
            upMouth.GiveManhandla(this);
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Move();
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {

            downMouth.Draw(spriteBatch, Position, color);
            leftMouth.Draw(spriteBatch, Position, color);
            rightMouth.Draw(spriteBatch, Position, color);
            upMouth.Draw(spriteBatch, Position, color);

            Sprite.Draw(spriteBatch, Position, this.color);
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            int i = 1;
            if (downMouth.health <= 0 && leftMouth.health <= 0 && rightMouth.health <= 0 && upMouth.health <= 0)      
            {
                i = 0;
            }
            return i;
        }

        public override void Move()
        {
            if (count == 0)
            {
                waitTime = rand.Next(LOWER_BOUND, UPPER_BOUND);
            }
            else if (count == waitTime)
            {
                direction = rand.Next(LEFT, UP_RIGHT+1);
                count = 0;
            }

            if(X <= LEFT_BOUND * Global.Var.SCALE)
            {
                int[] array = new int[] { RIGHT, UP_RIGHT, DOWN_RIGHT };
                int randomIndex = rand.Next(array.Length);
                direction = array[randomIndex];
                count = 0;
            }
            else if(Y >= DOWN_BOUND * Global.Var.SCALE)
            {
                int[] array = new int[] { UP, UP_RIGHT, UP_LEFT };
                int randomIndex = rand.Next(array.Length);
                direction = array[randomIndex]; 
                count = 0;
            }
            else if(X >= RIGHT_BOUND * Global.Var.SCALE)
            {
                int[] array = new int[] { LEFT, UP_LEFT, DOWN_LEFT };
                int randomIndex = rand.Next(array.Length);
                direction = array[randomIndex]; 
                count = 0;
            }
            else if(Y <= UP_BOUND * Global.Var.SCALE)
            {
                int[] array = new int[] { DOWN, DOWN_LEFT, DOWN_RIGHT };
                int randomIndex = rand.Next(array.Length);
                direction = array[randomIndex]; 
                count = 0;
            }


            switch (direction)
            {
                case LEFT:
                    X = X - speed * Global.Var.SCALE;
                    SetStepSize(speed);
                    break;
                case RIGHT:
                    X = X + speed * Global.Var.SCALE;
                    SetStepSize(speed);
                    break;
                case UP:
                    Y = Y - speed * Global.Var.SCALE;
                    SetStepSize(speed);
                    break;
                case DOWN:
                    Y = Y + speed * Global.Var.SCALE;
                    SetStepSize(speed);
                    break;
                case DOWN_RIGHT:
                    X = X + speed * Global.Var.SCALE;
                    Y = Y + speed * Global.Var.SCALE;
                    SetStepSize((float)Math.Sqrt(Math.Pow(speed, TWO) + Math.Pow(speed, TWO)));
                    break;
                case DOWN_LEFT:
                    X = X - speed * Global.Var.SCALE;
                    Y = Y + speed * Global.Var.SCALE;
                    SetStepSize((float)Math.Sqrt(Math.Pow(speed, TWO) + Math.Pow(speed, TWO)));
                    break;
                case UP_LEFT:
                    X = X - speed * Global.Var.SCALE;
                    Y = Y - speed * Global.Var.SCALE;
                    SetStepSize((float)Math.Sqrt(Math.Pow(speed, TWO) + Math.Pow(speed, TWO)));
                    break;
                case UP_RIGHT:
                    X = X + speed * Global.Var.SCALE;
                    Y = Y - speed * Global.Var.SCALE;
                    SetStepSize((float)Math.Sqrt(Math.Pow(speed, TWO) + Math.Pow(speed, TWO)));
                    break;

            }
            count++;
        }

        public void IncreaseSpeed()
        {
            speed = speed + SPEED_INCREASE;
        }
    }
}
