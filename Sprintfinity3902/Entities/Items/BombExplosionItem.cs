using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities.Items
{
    public class BombExplosionItem : AbstractEntity
    {
        Vector2 Position1;
        Vector2 Position2;
        Vector2 Position3;
        Vector2 Position4;
        Vector2 Position5;
        Vector2 Position6;
        Vector2 Position7;

        public BombExplosionItem(Vector2 position)
        {
            Sprite = ItemSpriteFactory.Instance.CreateSmokeItem();
            Position = position;
            Position1 = new Vector2(Position.X - 3 * Global.Var.SCALE, Position.Y);
            Position2 = new Vector2(Position.X - 19 * Global.Var.SCALE, Position.Y);
            Position3 = new Vector2(Position.X + 13 * Global.Var.SCALE, Position.Y);
            Position4 = new Vector2(Position.X + 5 * Global.Var.SCALE, Position.Y - 16 * Global.Var.SCALE);
            Position5 = new Vector2(Position.X - 11 * Global.Var.SCALE, Position.Y - 16 * Global.Var.SCALE);
            Position6 = new Vector2(Position.X + 5 * Global.Var.SCALE, Position.Y + 16 * Global.Var.SCALE);
            Position7 = new Vector2(Position.X - 11 * Global.Var.SCALE, Position.Y + 16 * Global.Var.SCALE);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position1, Color.White);
            Sprite.Draw(spriteBatch, Position2, Color.White);
            Sprite.Draw(spriteBatch, Position3, Color.White);
            Sprite.Draw(spriteBatch, Position4, Color.White);
            Sprite.Draw(spriteBatch, Position5, Color.White);
            Sprite.Draw(spriteBatch, Position6, Color.White);
            Sprite.Draw(spriteBatch, Position7, Color.White);
        }
    }
}
