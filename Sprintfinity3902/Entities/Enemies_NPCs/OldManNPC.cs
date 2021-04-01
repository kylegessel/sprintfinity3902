using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class OldManNPC : AbstractEntity, IEnemy
    {

        public OldManNPC(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateOldManNPC();
            Position = pos;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            // eventually enable the fire attack

            return 1;
        }
    }
}
