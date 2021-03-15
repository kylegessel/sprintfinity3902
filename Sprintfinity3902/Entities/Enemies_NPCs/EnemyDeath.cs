using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities.Enemies_NPCs
{
    public class EnemyDeath : AbstractEntity
    {

        public EnemyDeath(Vector2 position)
        {
            Position = position;
            Sprite = ItemSpriteFactory.Instance.CreateSmokeItem();
            Sprite.Animation.PlayOnce();
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (!Sprite.Animation.IsPlaying)
            {
                Position = new Vector2(-1000, -1000);
            }
        }
    }
}
