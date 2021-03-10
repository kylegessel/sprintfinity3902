using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    interface IBlock
    {
        Boolean IsMovable();
        ICollision.CollisionSide PushSide();
        ICollision.CollisionSide PushSide2();
        void MoveBlock(ICollision.CollisionSide side);
    }
}
