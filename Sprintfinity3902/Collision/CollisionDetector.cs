using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Entities.Items;
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
        public static List<int> decorateList;
        public static List<int> undecorateList;
        //Rectangle intersectionRect;
        

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

        public void setup(Game1 game)
        {
            gameInstance = game;
            link = (Player)game.playerCharacter;
            decorateList = new List<int>();
            undecorateList = new List<int>();
        }

        /* 
         * This method updates the Collision singleton 
         * 
         * maybe this should just take in the room instead of each individual list
         */
        public void CheckCollision(Dictionary<int, IEntity> enemies, List<IEntity> blocks, List<IEntity> items, List<IEntity> linkProj) {
            DetectLinkDamage(enemies);
            DetectBlockCollision(enemies, blocks);
            DetectEnemyDamage(enemies, linkProj, items);
            DetectItemPickup(items);

        }

        private void DetectLinkDamage(Dictionary<int, IEntity> enemies)
        {

            Rectangle linkRect = link.GetBoundingRect();

            foreach (int enemy in enemies.Keys)
            {
                IEntity currentEnemy;
                enemies.TryGetValue(enemy, out currentEnemy);
                AbstractEntity cEnemy = (AbstractEntity)currentEnemy;
                Rectangle enemyRect = currentEnemy.GetBoundingRect();
                if (cEnemy.IsCollidable() && currentEnemy.GetBoundingRect().Intersects(linkRect))
                {
                    /*
                     * TODO: Replace with handler
                     */
                    ILink damagedLink = new DamagedLink(link, gameInstance);
                    gameInstance.playerCharacter = damagedLink;
                }
            }
        }

        private void DetectBlockCollision(Dictionary<int, IEntity> enemies, List<IEntity> blocks)
        {

            Rectangle linkRect = link.GetBoundingRect();
            Boolean alreadyMoved = false;

            foreach (AbstractEntity block in blocks)
            {
                Rectangle blockRect = block.GetBoundingRect();
                if (block.IsCollidable() && blockRect.Intersects(linkRect))
                {
                    side = blockCollision.sideOfCollision(blockRect, linkRect);
                    if (!alreadyMoved) //This will prevent it from moving back twice
                    {
                        alreadyMoved = blockCollision.reflectMovingEntity(link, side);
                    }
                }
            }

            foreach (int enemy in enemies.Keys)
            {
                // TODO: For some enemies, like the Spike and Final Boss, I don't want it to check for it's hit box
                IEntity currentEnemy;
                enemies.TryGetValue(enemy, out currentEnemy);
                Rectangle enemyRect = currentEnemy.GetBoundingRect();
                alreadyMoved = false;

                foreach (AbstractEntity block in blocks)
                {
                    Rectangle blockRect = block.GetBoundingRect();
                    if (block.IsCollidable() && blockRect.Intersects(enemyRect))
                    {
                        side = blockCollision.sideOfCollision(blockRect, enemyRect);
                        if (!alreadyMoved) //This will prevent it from moving back twice
                        {
                            alreadyMoved = blockCollision.reflectMovingEntity(currentEnemy, side);
                        }
                    }
                }
            }

        }

        private void DetectEnemyDamage(Dictionary<int, IEntity> enemies, List<IEntity> linkProj, List<IEntity> items)
        {

            List<int> deletionList = new List<int>();
            /*
             * TODO: implement link hurtboxes and pass to this function.
             */
            foreach (AbstractEntity proj in linkProj)
            {
                foreach (int enemy in enemies.Keys)
                {
                    IEntity currentEnemy;
                    enemies.TryGetValue(enemy, out currentEnemy);
                    Rectangle enemyRect = currentEnemy.GetBoundingRect();
                    /*
                     * TODO: enemy damage handler
                     */

                    if (proj != null && proj.GetBoundingRect().Intersects(currentEnemy.GetBoundingRect()))
                    {
                         IProjectile projectile = (IProjectile)proj;

                        Boolean removeItem = projectile.Collide(enemy, (IEnemy)currentEnemy);
                        //CollisionDetector.decorateList.Add(enemy);
                        if (removeItem)
                        {
                            deletionList.Add(enemy);
                            items.Add(new RupeeItem(currentEnemy.Position));
                        }

                    }

                }
            }
            foreach (int enemyID in decorateList)
            {
                IEntity currEnemy;
                enemies.TryGetValue(enemyID, out currEnemy);
                enemies.Remove(enemyID);
                enemies.Add(enemyID, new DamagedEntity(enemyID, (AbstractEntity)currEnemy, gameInstance.dungeon.CurrentRoom));
            }
            decorateList.Clear();
            foreach (int enemyID in undecorateList)
            {
                IEntity decoratedEnemy;
                enemies.TryGetValue(enemyID, out decoratedEnemy);
                enemies.Remove(enemyID);
                DamagedEntity damagedEnemy = (DamagedEntity)decoratedEnemy;
                enemies.Add(enemyID, damagedEnemy.GetUnDecorated());
            }
            undecorateList.Clear();
            foreach (int enemyID in deletionList)
            {
                enemies.Remove(enemyID);
            }


        }

        private void DetectItemPickup(List<IEntity> items)
        {

            Rectangle linkRect = link.GetBoundingRect();
            List<IEntity> deletionList = new List<IEntity>();

            foreach (AbstractEntity item in items)
            {
                if (item.GetBoundingRect().Intersects(linkRect))
                {
                    link.pickup(((AbstractItem)item).ID);
                    /*
                     * TODO: Replace with handler
                     */
                    deletionList.Add(item);
                }
            }

            //how tf does this work, isn't items just a reference?
            foreach (AbstractEntity pickup in deletionList)
            {
                items.Remove(pickup);
            }
          
        }

    }
}
