using Microsoft.Xna.Framework;

namespace Sprintfinity3902.Interfaces
{
    public interface IAttack : IEnemy
    {
        void StartOver(Vector2 position);
        void StartMoving();
        void StopMoving();
    }
}
