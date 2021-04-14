using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class RightFaceBlockEnemy : AbstractBlock, IEnemy
    {
        private const int RANDOM_DOWN_BOUND = 80;
        private const int RANDOM_UP_BOUND = 140;

        private IAttack fireAttack;
        private int randomAttack;
        private int count;
        public RightFaceBlockEnemy(Vector2 pos, IAttack fire)
        {
            Sprite = BlockSpriteFactory.Instance.CreateFace2Block();
            Position = pos;
            fireAttack = fire;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Attack();
        }

        public override void Attack()
        {
            if (count == 0)
            {
                fireAttack.StartOver(Position);
                fireAttack.StartMoving();
                randomAttack = new Random().Next(RANDOM_DOWN_BOUND, RANDOM_UP_BOUND);
            }
            else if (count == randomAttack)
            {
                fireAttack.StopMoving();
                count = -1;
            }
            else
            {
                fireAttack.Move();
            }
            count++;
        }

        public override Boolean IsCollidable()
        {
            return true;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            return 0;
        }
    }
}
