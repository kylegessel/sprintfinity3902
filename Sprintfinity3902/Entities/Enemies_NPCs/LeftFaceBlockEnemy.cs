using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class LeftFaceBlockEnemy : AbstractBlock, IBlock
    {
        private const int RANDOM_DOWN_BOUND = 80;
        private const int RANDOM_UP_BOUND = 140;
        
        private IAttack fireAttack;
        private IRoom currentRoom;
        private int randomAttack;
        private int count;
        public LeftFaceBlockEnemy(Vector2 pos, IAttack fire, IRoom room)
        {
            Sprite = BlockSpriteFactory.Instance.CreateFace1Block();
            Position = pos;
            fireAttack = fire;
            currentRoom = room;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if(currentRoom.enemies.Count != 0)
            {
                Attack();
            }
        }

        public override void Attack()
        {
            if (count == 0)
            {
                Vector2 startPosition = new Vector2(X + Global.Var.TILE_SIZE * Global.Var.SCALE, Y);
                fireAttack.StartOver(startPosition);
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
    }
}
