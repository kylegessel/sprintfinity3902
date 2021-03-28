using Sprintfinity3902.Entities.Enemies_NPCs;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

namespace Sprintfinity3902.Collision
{
    public class ProjectileCollisionHandler
    {

        public static void ProjectileEnemyHit(int enemy, IEntity currentEnemy, IProjectile proj, List<int> deletionList, List<IEntity> garbage, Game1 gameInstance)
        {
            bool removeItem = proj.Collide(enemy, (IEnemy)currentEnemy, gameInstance.dungeon.CurrentRoom);
            if (removeItem)
            {
                deletionList.Add(enemy);
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
    }
}
