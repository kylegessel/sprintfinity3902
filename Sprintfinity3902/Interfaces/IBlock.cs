using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IBlock : IEntity
    {
        Boolean IsMovable();

        bool IsTall();
        void StartMoving(ICollision.CollisionSide Side);
        ICollision.CollisionSide PushSide();
        ICollision.CollisionSide PushSide2();
        void MoveBlock();
        void Update();
    }
}
