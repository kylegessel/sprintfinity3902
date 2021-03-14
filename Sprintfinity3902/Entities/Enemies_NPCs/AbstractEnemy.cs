using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities.Enemies_NPCs
{
    public class AbstractEnemy: AbstractEntity, IEnemy
    {
        private int _health;

        public int health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = health;
            }
        }

        // Simplest implementation of a hit register, will work for all entities.
        public virtual int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection)
        {
            health = health - damage;
            return health;
        }
    }
}
