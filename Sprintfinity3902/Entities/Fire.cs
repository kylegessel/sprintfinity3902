using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class Fire : AbstractEntity
    {
        public Fire()
        {
            //TODO: Eventually add the attack to this class as well
            // I'm not too concerned yet though as it depends on npc being hit.
            Sprite = EnemySpriteFactory.Instance.CreateFire();
            Position = new Vector2(1000, 500);
        }
    }
}
