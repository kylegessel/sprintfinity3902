using Sprintfinity3902.SpriteFactories;
using System;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    class MovingLeftBlock : AbstractBlock
    {
        private ICollision.CollisionSide _pushSide = ICollision.CollisionSide.RIGHT;
        private Boolean alreadyMoved = false;

        public MovingLeftBlock(Vector2 pos)
        {
            Sprite = BlockSpriteFactory.Instance.CreateRegularBlock();
            Position = pos;
        }

        public override Boolean IsMovable()
        {
            return true;
        }
        public override ICollision.CollisionSide PushSide()
        {
            return _pushSide;
        }
        public override ICollision.CollisionSide PushSide2()
        {
            return _pushSide;
        }

        public override void MoveBlock(ICollision.CollisionSide side)
        {
            /*Blocks only move once*/
            if (!alreadyMoved)
            {
                this.X -= 16 * Global.Var.SCALE;
                alreadyMoved = true;
            }
        }
    }
}
