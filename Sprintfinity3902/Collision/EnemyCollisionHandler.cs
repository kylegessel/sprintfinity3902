using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using System;

namespace Sprintfinity3902.Collision
{
    public class EnemyCollisionHandler : ICollision
    {
        ICollision.CollisionSide side;
        Rectangle intersectionRect;

        public EnemyCollisionHandler()
        {
            //Not sure what I need here
        }

        public ICollision.CollisionSide SideOfCollision(Rectangle enemyRect, Rectangle characterRect)
        {
            intersectionRect = Rectangle.Intersect(characterRect, enemyRect);
            //Logic to determine where the overlap is
            if (intersectionRect.Top == enemyRect.Top)
            {
                if (intersectionRect.Left == enemyRect.Left)
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
                else if (intersectionRect.Right == enemyRect.Right)
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
                else //Link only intersects top. Will happen with bottom wall
                {
                    side = ICollision.CollisionSide.TOP;
                }
            }
            else if (intersectionRect.Bottom == enemyRect.Bottom)
            {
                if (intersectionRect.Left == enemyRect.Left)
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
                else if (intersectionRect.Right == enemyRect.Right)
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
                else //Link only intersects Bottom. Will happen with top wall
                {
                    side = ICollision.CollisionSide.BOTTOM;
                }
            }
            else if (intersectionRect.Left == enemyRect.Left)
            {
                side = ICollision.CollisionSide.LEFT;
            }
            else //Link ran into left wall
            {
                side = ICollision.CollisionSide.RIGHT;
            }
            return side;
        }

        
        public Boolean ReflectMovingEntity(IEntity movingEntity, ICollision.CollisionSide side) // had this previously. May be needed in future (Rectangle collisionRect)
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

        /*This currently is not used. But want to move the "MoveLink" method from player class to here and use this. */
        public void UpdatePosition(IEntity link)
        {
            int top = 96 * Global.Var.SCALE;
            int bot = 194 * Global.Var.SCALE;
            int left = 32 * Global.Var.SCALE;
            int right = 224 * Global.Var.SCALE;

            if (link.X > right) link.X = right;
            if (link.X < left) link.X = left;
            if (link.Y > bot) link.Y = bot;
            if (link.Y < top) link.Y = top;
        }

    }
}
