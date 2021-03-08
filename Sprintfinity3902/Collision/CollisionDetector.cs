using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;

namespace Sprintfinity3902.Collision
{
    public class CollisionDetector {


        Game1 gameInstance;
        Player link;

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
        }

        /* 
         * This method updates the Collision singleton 
         * 
         * maybe this should just take in the room instead of each individual list
         */
        public void CheckCollision(List<IEntity> enemies, List<IEntity> blocks, List<IEntity> items, List<IEntity> linkProj) {
            DetectLinkDamage(enemies);
            DetectBlockCollision(enemies, blocks);
            DetectEnemyDamage(enemies, linkProj);
            DetectItemPickup(items);

        }

        private void DetectLinkDamage(List<IEntity> enemies)
        {

            Rectangle linkRect = link.GetBoundingRect();

            foreach (AbstractEntity enemy in enemies)
            {
                if (enemy.IsCollidable() && enemy.GetBoundingRect().Intersects(linkRect))
                {
                    /*
                     * TODO: Replace with handler
                     */
                    ILink damagedLink = new DamagedLink(link, gameInstance);
                    gameInstance.playerCharacter = damagedLink;
                }
            }
        }

        private void DetectBlockCollision(List<IEntity> enemies, List<IEntity> blocks)
        {

            Rectangle linkRect = link.GetBoundingRect();

            foreach (AbstractEntity block in blocks)
            {

                if (block.GetBoundingRect().Intersects(linkRect))
                {
                    /*
                     * TODO: link block collision handler
                     */
                }

            }

            foreach (AbstractEntity enemy in enemies)
            {
                Rectangle enemyRect = enemy.GetBoundingRect();

                foreach (AbstractEntity block in blocks)
                {
                    if (block.GetBoundingRect().Intersects(enemyRect))
                    {
                        /*
                         * TODO: enemy block collision handler
                         */
                    }

                }
            }

        }

        private void DetectEnemyDamage(List<IEntity> enemies, List<IEntity> linkProj)
        {

            List<IEntity> deletionList = new List<IEntity>();
            /*
             * TODO: implement link hurtboxes and pass to this function.
             */
            foreach (AbstractEntity proj in linkProj)
            {
                foreach (AbstractEntity enemy in enemies)
                {
                    /*
                     * TODO: enemy damage handler
                     */

                    if (proj.GetBoundingRect().Intersects(enemy.GetBoundingRect()))
                    {
                        /*
                         * TODO: Replace with handler
                         */
                        deletionList.Add(enemy);
                    }

                }
            }

            foreach (AbstractEntity pickup in deletionList)
            {
                enemies.Remove(pickup);
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
