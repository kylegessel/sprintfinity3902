using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class FireEnemy : AbstractEntity, IEnemy
    {
        private int count;
        private int waitTime;
        private Random rd;
        private IAttack attack;

        public FireEnemy(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateFire();
            Position = pos;

            rd = new Random();
            count = 0;
            waitTime = 0;
        }

        public override void Attack()
        {
            if (count == 0)
            {
                waitTime = rd.Next(30, 150);
                attack = new FireAttack(new Vector2((X + 40), (Y+40)), 0);
                attack.StartMoving();
            }
            else if (count == waitTime)
            {
                count = rd.Next(-40, -1);
                attack = null;
            }
            else
            {
                if(attack != null)
                {
                    attack.Move();
                }
            }
            count++;
            
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if(attack != null)
            {
                attack.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, Position, color);
            if (attack != null)
            {
                attack.Draw(spriteBatch, color);
            }
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            return 1;
        }


    }
}
