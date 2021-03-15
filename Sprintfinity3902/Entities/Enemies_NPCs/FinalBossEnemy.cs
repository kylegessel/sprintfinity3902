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
        public FireAttack fireAttackUp;
        public FireAttack fireAttackCenter;
        public FireAttack fireAttackDown;

        private int directionCount;
        private int direction;
        private int attackCount;
        private int attack;
        private int waitTime;
        private int attackTime;

        private Random rd;

        public FinalBossEnemy(Vector2 pos, FireAttack up, FireAttack center, FireAttack down)
        {
            ClosedMouth = EnemySpriteFactory.Instance.CreateFinalBossClosed();
            OpenedMouth = EnemySpriteFactory.Instance.CreateFinalBossOpened();
            Sprite = ClosedMouth;
            fireAttackUp = up;
            fireAttackCenter = center;
            fireAttackDown = down;
            Position = pos;

            rd = new Random();

            direction = rd.Next(1, 4);
            directionCount = 0;

            attack = rd.Next(1, 3);
            attackTime = 85;
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
            attackTime = 85;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Move();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position, Color.White);                
        }

        public override bool IsCollidable()
        {
            return false;
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
            if (direction == 1 && X > 145*Global.Var.SCALE) //Forward
                X = X - .15f*Global.Var.SCALE;
            else if (direction == 2 && X < 180*Global.Var.SCALE) //Backward
                X = X + .15f*Global.Var.SCALE;
            
            directionCount++;

            // Handle Attack
            if (attack == 1)
            {
                Sprite = OpenedMouth;
                attackCount = 0;
                fireAttackUp.StartOver(Position);
                fireAttackCenter.StartOver(Position);
                fireAttackDown.StartOver(Position);
                fireAttackUp.StartMoving();
                fireAttackCenter.StartMoving();
                fireAttackDown.StartMoving();


            }
            else if (attackCount == attackTime)
            {
                Sprite = ClosedMouth;
                fireAttackUp.StopMoving();
                fireAttackCenter.StopMoving();
                fireAttackDown.StopMoving();

            }


            attackCount++;
        }
    }
}
