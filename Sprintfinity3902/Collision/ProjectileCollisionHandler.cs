using Sprintfinity3902.Entities;
using Sprintfinity3902.Entities.Enemies_NPCs;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;

namespace Sprintfinity3902.Collision
{
    public class ProjectileCollisionHandler
    {
        private static double NO_ITEM_FREQ = .35;

        //THESE ARE CUMULATIVE FREQUENCIES (in this order)
        private static double RUPEE_FREQ = .30;
        private static double HEART_FREQ = .60;
        private static double BOMB_FREQ = .85;
        private static double FAIRY_FREQ = .9; 
        private static double BLUE_RUPEE_FREQ =  1;



        public static void ProjectileEnemyHit(int enemy, IEntity currentEnemy, IProjectile proj, List<int> deletionList, List<IEntity> garbage, Game1 gameInstance, List<IEntity> items, IPlayer player)
        {
            bool removeItem = proj.Collide(enemy, (IEnemy)currentEnemy, gameInstance.dungeon.CurrentRoom, player);
            if (removeItem)
            {
                deletionList.Add(enemy);
                if (EnemyDrop())
                {
                    items.Add(PickDrop(currentEnemy));
                }
               
                garbage.Add(new EnemyDeath(currentEnemy.Position));
                Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Enemy_Die).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            }
            else
            {
                Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Enemy_Hit).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            }
        }

        public static void ProjectileWallHit(IProjectile projectile, IRoom room)
        {
            projectile.Collide(room);
        }

        private static bool EnemyDrop()
        {

            bool dropItem = false;
            double RandomNum;
            Random random = new Random();

            RandomNum = random.NextDouble();

            if (RandomNum < NO_ITEM_FREQ)
            {
                dropItem = true;
            }

            return dropItem;
        }

        private static IItem PickDrop(IEntity currentEnemy)
        {
            IItem droppedItem;
            double RandomNum;
            Random random = new Random();

            RandomNum = random.NextDouble();

            if (RandomNum <= RUPEE_FREQ)
            {
                droppedItem = (new RupeeItem(currentEnemy.Position));
            } 
            else if (RandomNum <= HEART_FREQ)
            {
                droppedItem = (new HeartItem(currentEnemy.Position));
            }
            else if (RandomNum <= BOMB_FREQ)
            {
                droppedItem = (new BombStaticItem(currentEnemy.Position));
            }
            else if (RandomNum <= FAIRY_FREQ)
            {
                droppedItem = (new FairyItem(currentEnemy.Position));
            }
            else if (RandomNum <= BLUE_RUPEE_FREQ)
            {
                droppedItem = (new BlueRupeeItem(currentEnemy.Position));
            }
            else
            {
                //this should never happen
                droppedItem = (new RupeeItem(currentEnemy.Position));
            }

            return droppedItem;
        }
    }
}
