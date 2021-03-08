using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using System;

namespace Sprintfinity3902.Interfaces
{
    public interface ICollision
    {
        //The side refers to where the moving entity is (Link or enemy)
        enum CollisionSide
        {
            TOP,
            RIGHT,
            BOTTOM,
            LEFT
        }

        Boolean reflectMovingEntity(IEntity movingEntity, CollisionSide side); //, Rectangle intersectionRect);

        CollisionSide sideOfCollision(Rectangle block, Rectangle characterRect);
    }
}
