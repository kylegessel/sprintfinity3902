using System;
using System.Collections.Generic;
using System.Text;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public abstract class AbstractBlock : AbstractEntity, IBlock
    {
        private Boolean _movable = false;
        private ICollision.CollisionSide _pushSide = ICollision.CollisionSide.NONE;

        public virtual Boolean IsMovable()
        {
            return _movable;
        }
        public virtual ICollision.CollisionSide PushSide()
        {
            return _pushSide;
        }
        public virtual ICollision.CollisionSide PushSide2()
        {
            return _pushSide;
        }
        public virtual void MoveBlock(ICollision.CollisionSide side)
        {
            //Most blocks don't move so do nothing
        }
    }
}
