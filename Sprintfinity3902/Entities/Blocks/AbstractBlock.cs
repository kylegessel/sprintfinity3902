using Sprintfinity3902.Interfaces;
using System;

namespace Sprintfinity3902.Entities
{
    public abstract class AbstractBlock : AbstractEntity, IBlock
    {
        private bool _movable = false;
        private bool _tall = false;
        //private Boolean _isMoving = false;
        //private ICollision.CollisionSide _side;
        private ICollision.CollisionSide _pushSide = ICollision.CollisionSide.NONE;

        public virtual void Update()
        {
            //Do nothing for all still blocks
        }
        public virtual Boolean IsMovable()
        {
            return _movable;
        }
        public virtual void StartMoving(ICollision.CollisionSide Side)
        {
            //
        }
        public virtual ICollision.CollisionSide PushSide()
        {
            return _pushSide;
        }
        public virtual ICollision.CollisionSide PushSide2()
        {
            return _pushSide;
        }
        public virtual bool IsTall()
        {
            return _tall;
        }
        public virtual void MoveBlock()
        {
            //Most blocks don't move so do nothing
        }
    }
}
