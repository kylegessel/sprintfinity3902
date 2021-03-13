using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Fire : AbstractEntity, IEnemy
    {
        public Fire()
        {
            //TODO: Eventually add the attack to this class as well
            // I'm not too concerned yet though as it depends on npc being hit.
            Sprite = EnemySpriteFactory.Instance.CreateFire();
            Position = new Vector2(750, 540);
        }
        public Fire(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateFire();
            Position = pos;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection)
        {
            return 1;
        }
    }
}
