using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class OldManNPC : AbstractEntity, IEnemy
    {
        public int EnemyHealth { get; set; }
        public int EnemyAttack { get; set; }
        public OldManNPC(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateOldManNPC();
            EnemyHealth = 0;
            EnemyAttack = 0;
            Position = pos;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            // eventually enable the fire attack

            return 1;
        }
    }
}
