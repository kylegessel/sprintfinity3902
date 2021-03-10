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
        private Boolean alreadyMoved = false;
        public MovingVertBlock(Vector2 pos)
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
            return _pushSide1;
        }
        public override ICollision.CollisionSide PushSide2()
        {
            return _pushSide2;
        }

        public override void MoveBlock(ICollision.CollisionSide side)
        {
            /*Blocks only move once*/
            if (!alreadyMoved)
            {
                if (side == ICollision.CollisionSide.BOTTOM)
                {
                    //Will want this to be an animation. So slower!
                    this.Y -= 16 * Global.Var.SCALE;
                }
                else
                {
                    this.Y += 16 * Global.Var.SCALE;
                }
                alreadyMoved = true;
            }
        }
    }
}
