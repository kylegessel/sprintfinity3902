﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class OldMan_FireEnemy : AbstractEntity, IEnemy
    {
        private static int MOD_BOUND = 12;
        private static int WAIT_TIME = 40;
        private static int THREE = 3;
        private static int SIX = 6;
        private static int NINE = 9;

        private int counter;
        private int count;
        private int waitTime;
        private bool decorate;
        private bool attacked;

        private FireEnemy fireEnemy1;
        private FireEnemy fireEnemy2;

        public OldMan_FireEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateOldManNPC();
            Position = pos;

            fireEnemy1 = new FireEnemy(Position);
            fireEnemy1.X = X + 48 * Global.Var.SCALE + 16 * Global.Var.SCALE;
            fireEnemy2 = new FireEnemy(Position);
            fireEnemy2.X = X - 48 * Global.Var.SCALE;
            
            Position = pos;
            color = Color.White;

            counter = 0;
            count = 1;
            waitTime = WAIT_TIME;
            decorate = false;
            attacked = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (attacked)
            {
                fireEnemy1.Attack();
                fireEnemy2.Attack();
            }
            Sprite.Update(gameTime);
            fireEnemy1.Update(gameTime);
            fireEnemy2.Update(gameTime);
            if (decorate)
            {
                Decorate();
                if (count == waitTime)
                {
                    decorate = false;
                    color = Color.White;
                }
                count++;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, this.color);
            fireEnemy1.Draw(spriteBatch, color);
            fireEnemy2.Draw(spriteBatch, color);
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            attacked = true;
            decorate = true;
            waitTime = WAIT_TIME;
            count = 1;
            return 1;
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
    }
}
