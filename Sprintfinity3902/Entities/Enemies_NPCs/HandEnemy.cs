using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities.Enemies_NPCs;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class HandEnemy : AbstractEntity, IEnemy
    {

        private static float F_DOT_THREE = .3f;
        private static int ONE = 1;
        private static  int FIVE = 5;
        private static int TWO_HUNDRED_TWENTY = 220;
        private static int SIXTY =  60;
        private static int MOD_BOUND  = 12;
        private static int SIX = 6;
        private static int NINE = 9;
        private static int THIRTY = 30;
        private static int THREE = 3;

        private int count;
        private static int decorateTime = 80;
        private int health;
        private float speed;
        private AbstractEntity.Direction direction;
        private bool decorate;
        private int enemyID;
        private IPlayer link;
        private HandAI _AI;

        public HandEnemy(Vector2 pos, IPlayer player, IRoom room)
        {
            Sprite = EnemySpriteFactory.Instance.CreateHandEnemy();
            Position = pos;
            health = THREE;
            speed = F_DOT_THREE;
            color = Color.White;
            link = player;
            _AI = new HandAI(room, this);
            
            direction = AbstractEntity.Direction.LEFT;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, this.color);

            //ItemSpriteFactory.Instance.CreateBombItem().Draw(spriteBatch, new Vector2(32 * Global.Var.SCALE+ Global.Var.TILE_SIZE * Global.Var.SCALE*6, 96 * Global.Var.SCALE + Global.Var.SCALE*Global.Var.TILE_SIZE*6), Color.White);
            //ItemSpriteFactory.Instance.CreateBombItem().Draw(spriteBatch, new Vector2(32 * Global.Var.SCALE + Global.Var.TILE_SIZE * Global.Var.SCALE, 96 * Global.Var.SCALE + Global.Var.SCALE * Global.Var.TILE_SIZE), Color.White);
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            this.enemyID = enemyID;
            health = health - damage;
            decorate = true;
            direction = projDirection;
            speed = (float)ONE;
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
            int counter = count % MOD_BOUND;
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
            count++;
            if (count >= decorateTime) {
                count = 0;
                decorate = false;
                color = Color.White;

                speed = 0.7f;
            }
        }

        public override void Move()
        {
            switch (decorate ? direction : _AI.WhichDirection(Position, link.Position)) {
                case Direction.LEFT:
                    X -= speed * Global.Var.SCALE;
                    break;
                case Direction.RIGHT:
                    X += speed * Global.Var.SCALE;
                    break;
                case Direction.UP:
                    Y -= speed * Global.Var.SCALE;
                    break;
                case Direction.DOWN:
                    Y += speed * Global.Var.SCALE;
                    break;
            }
        }
    }
}
