using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class ManhandlaBoss : AbstractEntity, IEnemy
    {
        private const int STARTING_HEALTH = 5;
        private const int TIME_DECORATED = 30;
        private const int MOD_BOUND = 12;
        private const int THREE = 3;
        private const int SIX = 6;
        private const int NINE = 9;
        private const int TWO = 2;
        private const int TWO_HUNDRED = 200;
        private const int FORTY = 40;

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

        private int decorateCount;
        private int decorateTime;
        private int health;
        private bool decorate;
        private int counter;

        private Random rand = new Random();
        private int count;
        private int direction;
        private int waitTime;
        private float speed;

        private IEntity downMouth;
        private IEntity leftMouth;
        private IEntity rightMouth;
        private IEntity upMouth;


        public ManhandlaBoss(Vector2 pos, IEntity down, IEntity left, IEntity right, IEntity up)
        {
            Sprite = EnemySpriteFactory.Instance.CreateManhandlaBody();
            Position = pos;
            health = STARTING_HEALTH;
            decorateTime = TIME_DECORATED;
            decorate = false;
            this.color = Color.White;
            direction = LEFT;
            count = 0;
            speed = .2f;
            SetStepSize(speed);

            downMouth = down;
            leftMouth = left;
            rightMouth = right;
            upMouth = up;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (decorate)
            {
                Decorate();
                if (decorateCount == decorateTime)
                {
                    decorate = false;
                    decorateCount = Global.Var.ZERO;
                    color = Color.White;
                }
                decorateCount++;
            }
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
            health = health - damage;
            decorate = true;
            decorateCount = Global.Var.ZERO;
            return health;
        }

        public override void Move()
        {
            if (count == 0)
            {
                waitTime = rand.Next(FORTY, TWO_HUNDRED);
            }
            else if (count == waitTime)
            {
                direction = rand.Next(LEFT, UP_RIGHT+1);
                count = 0;
            }

            if(X <= LEFT_BOUND * Global.Var.SCALE || Y <= UP_BOUND * Global.Var.SCALE)
            {
                direction = DOWN_RIGHT;
            }
            else if(X >= RIGHT_BOUND * Global.Var.SCALE || Y >= DOWN_BOUND * Global.Var.SCALE)
            {
                direction = UP_LEFT;
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

        public void Decorate()
        {
            counter = decorateCount % MOD_BOUND;
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
    }
}
