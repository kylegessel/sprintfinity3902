using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Collision
{
    public class BlockCollisionHandler : ICollision 
    {
        //public ICollision.CollisionSide side;
        //public IEntity movingEntity;

        public BlockCollisionHandler()
        {
            //Not sure what I need here
        }

        public void reflectMovingEntity(IEntity movingEntity, ICollision.CollisionSide side)
        {
            if (side == ICollision.CollisionSide.TOP) //Entity would be moving down
            {
                movingEntity.Y -= 5;
            }
            else if (side == ICollision.CollisionSide.RIGHT) //Entity would be moving left
            {
                movingEntity.X += 5;
            }
            else if (side == ICollision.CollisionSide.BOTTOM) //Entity would be moving up
            {
                movingEntity.Y += 5;
            }
            else if (side == ICollision.CollisionSide.LEFT) //Entity would be moving right
            {
                movingEntity.X -= 5;
            }
            else
            {
                //Do nothing. Did not run into block/wall
            }
        }
    }
}
