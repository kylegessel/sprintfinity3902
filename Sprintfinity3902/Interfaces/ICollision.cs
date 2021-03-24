using Microsoft.Xna.Framework;
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
            LEFT,
            NONE
        }

        Boolean ReflectMovingEntity(IEntity movingEntity, CollisionSide side); //, Rectangle intersectionRect);

        CollisionSide SideOfCollision(Rectangle block, Rectangle characterRect);
        void UpdatePosition(IEntity entity);
    }
}
