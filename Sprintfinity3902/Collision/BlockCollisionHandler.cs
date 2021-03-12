using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using System;

namespace Sprintfinity3902.Collision
{
    public class BlockCollisionHandler : ICollision 
    {
        ICollision.CollisionSide side;
        Rectangle intersectionRect;

        public BlockCollisionHandler()
        {
            //Not sure what I need here
        }

        public ICollision.CollisionSide sideOfCollision(Rectangle blockRect, Rectangle characterRect)
        {
                intersectionRect = Rectangle.Intersect(characterRect, blockRect);
                //Insert logic to determine where the overlap is
                if (intersectionRect.Top == blockRect.Top)
                {
                    if (intersectionRect.Left == blockRect.Left)
                    {
                        if (intersectionRect.Height > intersectionRect.Width)
                        {
                            side = ICollision.CollisionSide.LEFT;
                        }
                        else
                        {
                            side = ICollision.CollisionSide.TOP;
                        }
                    }
                    else if (intersectionRect.Right == blockRect.Right)
                    {
                        if (intersectionRect.Height > intersectionRect.Width)
                        {
                            side = ICollision.CollisionSide.RIGHT;
                        }
                        else
                        {
                            side = ICollision.CollisionSide.TOP;
                        }
                    }
                    else //Only intersects top (Not sure if this is possible) -- Will be with the walls
                    {
                        side = ICollision.CollisionSide.TOP;
                    }
                }
                else if (intersectionRect.Bottom == blockRect.Bottom)
                {
                    if (intersectionRect.Left == blockRect.Left)
                    {
                        if (intersectionRect.Height > intersectionRect.Width)
                        {
                            side = ICollision.CollisionSide.LEFT;
                        }
                        else
                        {
                            side = ICollision.CollisionSide.BOTTOM;
                        }

                    }
                    else if (intersectionRect.Right == blockRect.Right)
                    {
                        //compare width and  height
                        if (intersectionRect.Height > intersectionRect.Width)
                        {
                            side = ICollision.CollisionSide.RIGHT;
                        }
                        else
                        {
                            side = ICollision.CollisionSide.BOTTOM;
                        }
                    }
                    else //Only intersects Bot (Don't think this is possible)
                    {
                        side = ICollision.CollisionSide.BOTTOM;
                    }
                }
                else if (intersectionRect.Left == blockRect.Left)
                {
                    side = ICollision.CollisionSide.LEFT;
                }
                else //Link ran into left wall
                {
                    side = ICollision.CollisionSide.RIGHT;
                }
                return side;
        }

        public Boolean reflectMovingEntity(IEntity movingEntity, ICollision.CollisionSide side) // had this previously. May be needed in future (Rectangle collisionRect)
        {
            Boolean moved = false;
            if (side == ICollision.CollisionSide.TOP) //Entity would be moving down
            {
                movingEntity.Y -= Global.Var.SCALE;
                //movingEntity.Y -= collisionRect.Height;
                moved = true;
            }
            else if (side == ICollision.CollisionSide.RIGHT) //Entity would be moving left
            {
                movingEntity.X += Global.Var.SCALE;
                moved = true;
            }
            else if (side == ICollision.CollisionSide.BOTTOM) //Entity would be moving up
            {
                movingEntity.Y += Global.Var.SCALE;
                moved = true;
            }
            else if (side == ICollision.CollisionSide.LEFT) //Entity would be moving right
            {
                movingEntity.X -= Global.Var.SCALE;
                moved = true;  
            }
            //If this call is made we know there is a collision so an else condition is not needed
            return moved;
        }
    }
}
