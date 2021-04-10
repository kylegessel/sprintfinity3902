using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class ManhandlaMouthRight : AbstractEntity, IEnemy
    {
        private static int STARTING_HEALTH = 5;
        private static int TIME_DECORATED = 30;
        private static int MOD_BOUND = 12;
        private static int THREE = 3;
        private static int SIX = 6;
        private static int NINE = 9;

        private int decorateCount;
        private int decorateTime;
        private int health;
        private bool decorate;
        private int counter;


        public ManhandlaMouthRight(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateManhandlaRightMouth();
            Position = pos;
            health = STARTING_HEALTH;
            decorateTime = TIME_DECORATED;
            decorate = false;
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
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 pos, Color color)
        {
            if (health > 0)
            {
                Position = pos;
                X = X + 17 * Global.Var.SCALE;
                Sprite.Draw(spriteBatch, Position, this.color);
            }
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            health = health - damage;
            decorate = true;
            decorateCount = Global.Var.ZERO;
            return health;
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
