using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities.Items
{
    public class BombExplosionItem : AbstractEntity, IProjectile
    {
        public BombExplosionItem(Vector2 position)
        {
            Position = position;
            Sprite = ItemSpriteFactory.Instance.CreateSmokeItem();
        }

        public void Move(Vector2 position)
        {
            Position = position;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            Sprite.Draw(spriteBatch, new Vector2(Position.X - 3 * Global.Var.SCALE, Position.Y), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X - 19 * Global.Var.SCALE, Position.Y), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X + 13 * Global.Var.SCALE, Position.Y), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X + 5 * Global.Var.SCALE, Position.Y - 16 * Global.Var.SCALE), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X - 11 * Global.Var.SCALE, Position.Y - 16 * Global.Var.SCALE), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X + 5 * Global.Var.SCALE, Position.Y + 16 * Global.Var.SCALE), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X - 11 * Global.Var.SCALE, Position.Y + 16 * Global.Var.SCALE), Color.White);
        }

        public override Rectangle GetBoundingRect()
        {
            return new Rectangle((int)Position.X + 5, (int)Position.Y - 16, 32 * Global.Var.SCALE, 48 * Global.Var.SCALE);

        }

        public bool Collide(int enemyID, IEnemy enemy, IRoom room)
        {
            return enemy.HitRegister(enemyID, 3, 30, Direction.NONE, room) <= 0;
        }
        public void Collide(IRoom room)
        {
            // Do nothing.
        }
    }
}
