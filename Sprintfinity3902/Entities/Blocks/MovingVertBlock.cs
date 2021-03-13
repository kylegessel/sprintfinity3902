using Sprintfinity3902.SpriteFactories;
using System;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    class MovingVertBlock : AbstractBlock
    {
        private ICollision.CollisionSide _pushSide1 = ICollision.CollisionSide.BOTTOM;
        private ICollision.CollisionSide _pushSide2 = ICollision.CollisionSide.TOP;
        private ICollision.CollisionSide side;
        private Boolean alreadyMoved = false;
        private Boolean isMoving = false;
        private int moveCount;

        public MovingVertBlock(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRegularBlock();
            Position = pos;
            moveCount = 1;
        }

        public override Boolean IsMovable()
        {
            return true;
        }
        public override void StartMoving(ICollision.CollisionSide Side)
        {
            isMoving = true;
            side = Side;
        }
        public void StopMoving()
        {
            isMoving = false;
        }
        public override ICollision.CollisionSide PushSide()
        {
            return _pushSide1;
        }
        public override ICollision.CollisionSide PushSide2()
        {
            return _pushSide2;
        }

        public override void MoveBlock()
        {
            /*Blocks only move once*/
            if (!alreadyMoved)
            {
                //start moving
                      
                if (side == ICollision.CollisionSide.BOTTOM)
                {
                    //Will want this to be an animation. So slower!
                    this.Y -= (float)0.5 * Global.Var.SCALE;
                }
                else
                {
                    this.Y += (float)0.5 * Global.Var.SCALE;
                }
                //alreadyMoved = true;
            }
        }
        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (isMoving)
            {
                MoveBlock();
                moveCount++;
            }
            if (moveCount > 32)
            {
                StopMoving();
                alreadyMoved = true;
            }
        }
            
    }
}
