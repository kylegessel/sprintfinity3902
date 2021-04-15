using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Sprintfinity3902.Entities.AbstractEntity;

namespace Sprintfinity3902.Collision
{
    public class CollisionDetector {


        Game1 gameInstance;
        IPlayer link;

        
        ICollision blockCollision = new BlockCollisionHandler();
        ICollision enemyCollision = new EnemyCollisionHandler();
        ICollision.CollisionSide side;

        private static bool shouldCheck;
        

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

        private CollisionDetector() {
            shouldCheck = true;
        }

        public void Reset() {
            instance = new CollisionDetector();
        }

        public void Initialize(Game1 game)
        {
            gameInstance = game;
            link = (Player)game.link;
        }

        /* 
         * This method updates the Collision singleton 
         * 
         * maybe this should just take in the room instead of each individual list
         */
        public void CheckCollision(Dictionary<int, IEntity> enemies, List<IBlock> blocks, List<IEntity> items, List<IEntity> linkProj, List<IEntity> enemyProj, List<IDoor> doors, List<IEntity> garbage, IProjectile bombExplosion) {
            DetectLinkDamage(enemies, enemyProj);
            DetectBlockCollision(enemies, blocks, linkProj, enemyProj);
            DetectEnemyDamage(enemies, linkProj, items, garbage);
            DetectItemPickup(items);
            DetectDoorCollision(enemies, doors, linkProj, enemyProj, bombExplosion);
        }
        private void DetectDoorCollision(Dictionary<int, IEntity> enemies, List<IDoor> doors, List<IEntity> linkProj, List<IEntity> enemyProj, IProjectile bombExplosion)
        {
            Rectangle linkRect = ((IEntity)link).GetBoundingRect();
            Boolean alreadyMoved = false;
            foreach (IDoor door in doors)
            {
                Rectangle doorRect = door.GetBoundingRect();
                if (!gameInstance.CurrentState.Equals(gameInstance.CHANGE_ROOM)) {
                    if (doorRect.Intersects(linkRect))
                    {
                        if (door.DoorDestination != -1 && door.CurrentState.IsOpen)
                        {
                            // Add more complex logic here.
                            gameInstance.dungeon.ChangeRoom(door);
                        }
                        else if (door.CurrentState.IsLocked && link.itemcount[IItem.ITEMS.KEY] > 0)
                        {
                            door.Open();
                            link.itemcount[IItem.ITEMS.KEY]--;
                            HudMenu.InGameHud.Instance.UpdateKeys(link.itemcount[IItem.ITEMS.KEY]);
                        }
                        else
                        {
                            side = blockCollision.SideOfCollision(doorRect, linkRect);
                            blockCollision.ReflectMovingEntity((IEntity)link, side);
                        }
                    }
                }


                //enemy vs blocks
                foreach (int enemy in enemies.Keys)
                {
                    // TODO: For some enemies, like the Spike and Final Boss, I don't want it to check for it's hit box
                    IEntity currentEnemy;
                    enemies.TryGetValue(enemy, out currentEnemy);
                    AbstractEntity cEnemy = (AbstractEntity)currentEnemy;
                    Rectangle enemyRect = cEnemy.GetBoundingRect();
                    alreadyMoved = false;

                    if (doorRect.Intersects(enemyRect))
                    {
                        side = blockCollision.SideOfCollision(doorRect, enemyRect);
                        if (!alreadyMoved) //This will prevent it from moving back twice
                        {
                            alreadyMoved = blockCollision.ReflectMovingEntity(currentEnemy, side);
                        }
                    }
                }

                //proj vs blocks
                foreach (AbstractEntity proj in linkProj)
                {

                    if (doorRect.Intersects(proj.GetBoundingRect()))
                    {
                        ProjectileCollisionHandler.ProjectileWallHit((IProjectile)proj, gameInstance.dungeon.CurrentRoom);
                        if (proj.GetType().FullName == "Sprintfinity3902.Entities.Items.BombExplosionItem" && door.CurrentState.IsBombable && door.DoorDestination != -1)
                        {
                            door.Open();
                        }
                    }
                }

                foreach (AbstractEntity proj in enemyProj)
                {

                    if (doorRect.Intersects(proj.GetBoundingRect()))
                    {
                        ProjectileCollisionHandler.ProjectileWallHit((IProjectile)proj, gameInstance.dungeon.CurrentRoom);
                    }
                }
            }
        }
        private void DetectLinkDamage(Dictionary<int, IEntity> enemies, List<IEntity> enemyProj)
        {
            if (!shouldCheck) return;

            Rectangle linkRect = ((IEntity)link).GetBoundingRect();
            Boolean alreadyMoved = false;
            IEntity currentEnemy;
            foreach (int enemy in enemies.Keys)
            {
                
                enemies.TryGetValue(enemy, out currentEnemy);
                IEntity cEnemy = currentEnemy;
                Rectangle enemyRect = cEnemy.GetBoundingRect();

                if (((IEntity)link).IsCollidable() && enemyRect.Intersects(linkRect) && !alreadyMoved) 
                {
                    //This will prevent it from moving back twice if runs into two enemies at once (It will just do the first)
                    alreadyMoved = LinkDamageHandler.LinkDamaged(gameInstance, link, linkRect, enemyRect);
                }
            }

            foreach(IEntity proj in enemyProj)
            {
                Rectangle enemyRect = proj.GetBoundingRect();
                if ( ((IEntity)link).IsCollidable() && enemyRect.Intersects(linkRect) && !alreadyMoved)
                {
                    if (proj.GetType().FullName == "Sprintfinity3902.Entities.BoomerangItem")
                    {
                        IBoomerang boomerang = (BoomerangItem)proj;
                        if ((boomerang.FireDirection.Equals(Direction.DOWN) && link.CurrentState.Equals(link.facingUp)) || (boomerang.FireDirection.Equals(Direction.UP) && link.CurrentState.Equals(link.facingDown)) || (boomerang.FireDirection.Equals(Direction.LEFT) && link.CurrentState.Equals(link.facingRight)) || (boomerang.FireDirection.Equals(Direction.RIGHT) && link.CurrentState.Equals(link.facingLeft))) {
                            ProjectileCollisionHandler.ProjectileWallHit((IProjectile)proj, gameInstance.dungeon.CurrentRoom);
                        }
                        else
                        {
                            alreadyMoved = LinkDamageHandler.LinkDamaged(gameInstance, link, linkRect, enemyRect);
                        }
                    }
                    else
                    {
                        alreadyMoved = LinkDamageHandler.LinkDamaged(gameInstance, link, linkRect, enemyRect);
                    }

                }
            }
        }

        private void DetectBlockCollision(Dictionary<int, IEntity> enemies, List<IBlock> blocks, List<IEntity> linkProj, List<IEntity> enemyProj)
        {

            Rectangle linkRect = ((IEntity)link).GetBoundingRect();
            Boolean alreadyMoved = false;

            foreach (AbstractBlock block in blocks)
            {
                Rectangle blockRect = block.GetBoundingRect();
                    //link vs blocks
                    if (!gameInstance.CurrentState.Equals(gameInstance.CHANGE_ROOM) && block.IsCollidable() && blockRect.Intersects(linkRect))
                {
                    side = blockCollision.SideOfCollision(blockRect, linkRect);

                    //Create a movable block class?? But how to only let it move one full space in one direction?
                    if (!alreadyMoved) //This will prevent it from moving back twice
                    {
                        /*This allows link to push blocks. Enemies can not push blocks*/
                        if ( block.IsMovable() && ((block.PushSide() == side) || (block.PushSide2() == side)) )
                        {
                             block.StartMoving(side);
                        }
                        alreadyMoved = blockCollision.ReflectMovingEntity( (IEntity)link, side); 
                    }
                }

                //enemy vs blocks
                foreach (int enemy in enemies.Keys)
                {
                    // TODO: For some enemies, like the Spike and Final Boss, I don't want it to check for it's hit box
                    IEntity currentEnemy;
                    enemies.TryGetValue(enemy, out currentEnemy);
                    IEntity cEnemy = currentEnemy;
                    Rectangle enemyRect = cEnemy.GetBoundingRect();
                    alreadyMoved = false;

                    if (((block.IsCollidable() && cEnemy.IsCollidable())||block.IsTall()) && blockRect.Intersects(enemyRect))
                    {
                        side = blockCollision.SideOfCollision(blockRect, enemyRect);
                        if (!alreadyMoved) //This will prevent it from moving back twice
                        {
                            alreadyMoved = blockCollision.ReflectMovingEntity(currentEnemy, side);
                        }
                    }
                }

                //proj vs blocks
                foreach (AbstractEntity proj in linkProj)
                {

                    if (block.IsTall() && blockRect.Intersects(proj.GetBoundingRect()))
                    {
                        ProjectileCollisionHandler.ProjectileWallHit((IProjectile)proj, gameInstance.dungeon.CurrentRoom);
                    }
                }

                foreach(AbstractEntity proj in enemyProj)
                {

                    if (block.IsTall() && blockRect.Intersects(proj.GetBoundingRect()))
                    {
                        ProjectileCollisionHandler.ProjectileWallHit((IProjectile)proj, gameInstance.dungeon.CurrentRoom);
                    }
                }

            }



        }

        private void DetectEnemyDamage(Dictionary<int, IEntity> enemies, List<IEntity> linkProj, List<IEntity> items, List<IEntity> garbage)
        {
            if (!shouldCheck) return;

            List<int> deletionList = new List<int>();
            foreach (AbstractEntity proj in linkProj)
            {
                foreach (int enemy in enemies.Keys)
                {
                    IEntity currentEnemy;
                    enemies.TryGetValue(enemy, out currentEnemy);
                    if (proj != null && proj.GetBoundingRect().Intersects(currentEnemy.GetBoundingRect()))
                    {
                        ProjectileCollisionHandler.ProjectileEnemyHit(enemy, currentEnemy, (IProjectile)proj, deletionList, garbage, gameInstance, items);

                    }
                }   
            }

            foreach (int enemyID in deletionList)
            {
                enemies.Remove(enemyID);
            }
        }

        private void DetectItemPickup(List<IEntity> items)
        {
            if (!shouldCheck) return;

            Rectangle linkRect = ((IEntity)link).GetBoundingRect();
            List<IEntity> deletionList = new List<IEntity>();

            foreach (AbstractEntity item in items)
            {
                if (item.GetBoundingRect().Intersects(linkRect))
                {
                    link.Pickup(((AbstractItem)item));
                    deletionList.Add(item);
                }
            }

            foreach (AbstractEntity pickup in deletionList)
            {
                items.Remove(pickup);
            }
          
        }

        public bool CheckSpecificCollision(Rectangle rec)
        {
            Rectangle linkRect = ((IEntity)link).GetBoundingRect();
            return rec.Intersects(linkRect);
        }

        public bool CollidesWithBomb(Rectangle rec)
        {
            Rectangle bombRec = gameInstance.dungeon.bombItem.GetBoundingRect();
            return rec.Intersects(bombRec);
        }

        public void Pause() {
            shouldCheck = !shouldCheck;
        }

    }
}
