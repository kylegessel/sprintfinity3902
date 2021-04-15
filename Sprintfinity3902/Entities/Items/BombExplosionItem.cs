using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class BombExplosionItem : AbstractEntity, IProjectile
    {
        private static int STUN_LENGTH = 30;
        private static int FORTY_EIGHT =  48;
        private static int THIRTY_TWO = 32;
        private static int FIVE = 5;
        private static int ELEVEN = 11;
        private static int THIRTEEN = 13;
        private static int NINETEEN = 19;
        private static int THREE = 3;

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
            Sprite.Draw(spriteBatch, new Vector2(Position.X - THREE * Global.Var.SCALE, Position.Y), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X - NINETEEN * Global.Var.SCALE, Position.Y), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X + THIRTEEN * Global.Var.SCALE, Position.Y), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X + FIVE * Global.Var.SCALE, Position.Y - Global.Var.TILE_SIZE * Global.Var.SCALE), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X - ELEVEN * Global.Var.SCALE, Position.Y - Global.Var.TILE_SIZE * Global.Var.SCALE), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X + FIVE * Global.Var.SCALE, Position.Y + Global.Var.TILE_SIZE * Global.Var.SCALE), Color.White);
            Sprite.Draw(spriteBatch, new Vector2(Position.X - ELEVEN * Global.Var.SCALE, Position.Y + Global.Var.TILE_SIZE * Global.Var.SCALE), Color.White);
        }

        public override Rectangle GetBoundingRect()
        {
            return new Rectangle((int)Position.X + FIVE, (int)Position.Y - Global.Var.TILE_SIZE, THIRTY_TWO * Global.Var.SCALE, FORTY_EIGHT * Global.Var.SCALE);

        }

        public bool Collide(int enemyID, IEnemy enemy, IRoom room)
        {
            return enemy.HitRegister(enemyID, 3, STUN_LENGTH, this, Direction.NONE, room) <= 0;
        }
        public void Collide(IRoom room)
        {
            // Do nothing.
        }
    }
}
