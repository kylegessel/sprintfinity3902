using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Collections.Generic;

namespace Sprintfinity3902.Collision
{
    public class CollisionDetector {


        Game1 gameInstance;
        Player link;

        ICollision blockCollision = new BlockCollisionHandler();
        ICollision.CollisionSide side;
        Rectangle intersectionRect;


        /* Singleton instance */

        private static CollisionDetector instance;
        public static CollisionDetector Instance {
            get {
                if (instance == null) {
                    instance = new CollisionDetector();
                }
                return instance;
            }
        }

        //public CollisionDetector() {
        //Reset();
        // }
        public void setup(Game1 game)
        {
            gameInstance = game;
            link = (Player)game.playerCharacter;
        }
        
        /* This method updates the InputKeyboard singleton
         * to remove clutter from game class. Additionally,
         * the InputKeyboard will call this.CallCommands and 
         * this.CallHandlers if it needs to.
         */
        public void CheckCollision( List<IEntity> entities) {

            Rectangle linkrect = link.GetBoundingRect();

            foreach (AbstractEntity entity in entities)
            {
                if (entity.IsCollidable() && entity.GetBoundingRect().Intersects(linkrect))
                {
                    ILink damagedLink = new DamagedLink(link, gameInstance);
                    gameInstance.playerCharacter = damagedLink;
                }
            }
        }

        public void CheckBlockCollision( List<IEntity> blocks)
        {
            Rectangle linkrect = link.GetBoundingRect();
            

            foreach (AbstractEntity entity in blocks)
            {
                Rectangle blockrect = entity.GetBoundingRect();
                if (entity.IsCollidable() && blockrect.Intersects(linkrect))
                {
                    intersectionRect = Rectangle.Intersect(linkrect, blockrect);
                    
                    //Insert logic to determine where the overlap is
                    if (intersectionRect.Top == blockrect.Top)
                    {
                        if (intersectionRect.Left == blockrect.Left)
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
                        else if (intersectionRect.Right == blockrect.Right)
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
                    else if (intersectionRect.Bottom == blockrect.Bottom)
                    {
                        if (intersectionRect.Left == blockrect.Left)
                        {
                            if(intersectionRect.Height > intersectionRect.Width)
                            {
                                side = ICollision.CollisionSide.LEFT;
                            }
                            else
                            {
                                side = ICollision.CollisionSide.BOTTOM;
                            }

                        }
                        else if (intersectionRect.Right == blockrect.Right)
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
                    else if (intersectionRect.Right == blockrect.Left)
                    {
                        side = ICollision.CollisionSide.LEFT;
                    }
                    else //Link ran into left wall
                    {
                        side = ICollision.CollisionSide.RIGHT;
                    }

                        //if top, check left and right, if neither side = top, if has a side compare height to width, go with the bigger one

                    blockCollision.reflectMovingEntity(link, side);
                }
            }
        }

    }
}
