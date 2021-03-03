using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class FinalBossEnemy : AbstractEntity
    {
        private ISprite ClosedMouth;
        private ISprite OpenedMouth;
        private IEntity FireAttack;

        private int directionCount;
        private int direction;
        private int attackCount;
        private int attack;
        private int waitTime;
        private int attackTime;

        private Random rd;

        public FinalBossEnemy()
        {
            ClosedMouth = EnemySpriteFactory.Instance.CreateFinalBossClosed();
            OpenedMouth = EnemySpriteFactory.Instance.CreateFinalBossOpened();
            Sprite = ClosedMouth;
            Position = new Vector2(750, 540);

            rd = new Random();

            direction = rd.Next(1, 4);
            directionCount = 0;

            attack = rd.Next(1, 3);
            attackTime = 70;
        }
        public FinalBossEnemy(Vector2 pos)
        {
            ClosedMouth = EnemySpriteFactory.Instance.CreateFinalBossClosed();
            OpenedMouth = EnemySpriteFactory.Instance.CreateFinalBossOpened();
            Sprite = ClosedMouth;
            Position = pos;

            rd = new Random();

            direction = rd.Next(1, 4);
            directionCount = 0;

            attack = rd.Next(1, 3);
            attackTime = 70;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (FireAttack != null) {
                FireAttack.Update(gameTime);
            }
            
            Move();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position, Color.White);
            if (FireAttack != null) {
                FireAttack.Draw(spriteBatch);
            }
                
        }

        public override void Move()
        {
            // Movement of dragon
            if (directionCount == 0)
            {
                waitTime = rd.Next(60, 120);
                directionCount++;
            }
            else if (directionCount == waitTime)
            {
                direction = rd.Next(1, 4);
                if (attack == 1)
                    attack = 2;
                else
                    attack = rd.Next(1, 3);
                directionCount = 0;
            }

            // Handle Movement
            if (direction == 1) //Forward
                X = X - .2f*Global.Var.SCALE;
            else if (direction == 2) //Backward
                X = X + .2f*Global.Var.SCALE;
            
            directionCount++;

            // Handle Attack
            if (attack == 1)
            {
                Sprite = OpenedMouth;
                attackCount = 0;
                FireAttack = new FireAttack(Position);
            }
            else if (attackCount == attackTime)
            {
                Sprite = ClosedMouth;
                FireAttack = null;
            }

            attackCount++;
        }
    }
}
