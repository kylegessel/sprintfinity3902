using System;

namespace Sprintfinity3902.Interfaces
{
    public interface IProjectile
    {
        Boolean Collide(IEnemy enemy);
    }
}
