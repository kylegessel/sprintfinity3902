using System;

namespace Sprintfinity3902.Interfaces
{
    public interface IProjectile
    {
        Boolean Collide(int enemyID, IEnemy enemy, IRoom room);
        void Collide(IRoom room);
    }
}
