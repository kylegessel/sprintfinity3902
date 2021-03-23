using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    class MovingLeftBlock : AbstractBlock
    {

        private static int THIRTY_TWO = 32;
        private static float F_DOT_FIVE = .5f;

        private ICollision.CollisionSide _pushSide = ICollision.CollisionSide.RIGHT;
        private ICollision.CollisionSide side;
        private Boolean alreadyMoved = false;
        private Boolean isMoving = false;
        private int moveCount;

        public MovingLeftBlock(Vector2 pos)
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
            return _pushSide;
        }
        public override ICollision.CollisionSide PushSide2()
        {
            return _pushSide;
        }

        public override void MoveBlock()
        {
            /*Blocks only move once*/
            if (!alreadyMoved)
            {
                this.X -= F_DOT_FIVE * Global.Var.SCALE;
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
            if (moveCount > THIRTY_TWO)
            {
                StopMoving();
                alreadyMoved = true;
            }
        }
    }
}
