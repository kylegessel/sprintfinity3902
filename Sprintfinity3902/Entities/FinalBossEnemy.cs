using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

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

        public FinalBossEnemy()
        {
            ClosedMouth = EnemySpriteFactory.Instance.CreateFinalBossClosed();
            OpenedMouth = EnemySpriteFactory.Instance.CreateFinalBossOpened();

            Sprite = ClosedMouth;
            FireAttack = new DummyEntity();
            Position = new Vector2(1200, 500);

            direction = new Random().Next(1, 4);
            directionCount = 0;

            attack = new Random().Next(1, 3);
            attackTime = 60;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            FireAttack.Update(gameTime);
            Move();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position, Color.White);
            FireAttack.Draw(spriteBatch);
        }

        public override void Move()
        {
            if (directionCount == 0)
            {
                waitTime = new Random().Next(60, 120);
                directionCount++;
            }
            else if (directionCount == waitTime)
            {
                direction = new Random().Next(1, 4);
                if (attack == 1)
                    attack = 2;
                else
                    attack = new Random().Next(1, 3);
                directionCount = 0;
            }

            // Handle Movement
            if (direction == 1) //Forward
                X = X - 1;
            else if (direction == 2) //Backward
                X = X + 1;
            else { } //Still
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
                FireAttack = new DummyEntity();
            }

            attackCount++;
        }
    }
}
