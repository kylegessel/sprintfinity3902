using static Sprintfinity3902.Entities.AbstractEntity;

namespace Sprintfinity3902.Interfaces
{
    public interface IEnemy : IEntity
    {

        enum ENEMIES
        {
            BAT,
            GEL,
            SKELETON,
            GORIYA,
            SNAKE,
        };

        int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room);
        int EnemyHealth { get; set; }
        int EnemyAttack { get; set; }
    }
}
