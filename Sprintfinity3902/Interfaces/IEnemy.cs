using static Sprintfinity3902.Entities.AbstractEntity;

namespace Sprintfinity3902.Interfaces
{
    public interface IEnemy : IEntity
    {
        int EnemyHealth { get; set; }
        int EnemyAttack { get; set; }
           int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room);
    }
}
