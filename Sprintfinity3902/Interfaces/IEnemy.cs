using static Sprintfinity3902.Entities.AbstractEntity;

namespace Sprintfinity3902.Interfaces
{
    public interface IEnemy : IEntity
    {
           int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room);
    }
}
