using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities.Items
{
    public class MovingSwordSplitItem : AbstractEntity
    {
        ISprite Sprite2;
        ISprite Sprite3;
        ISprite Sprite4;

        Vector2 Position2;
        Vector2 Position3;
        Vector2 Position4;

        private int count;
        private int totalTime;
        private float speed;
        public MovingSwordSplitItem(Vector2 position)
        {
            Sprite = ItemSpriteFactory.Instance.CreateSwordSplitTopLeft();
            Sprite2 = ItemSpriteFactory.Instance.CreateSwordSplitTopRight();
            Sprite3 = ItemSpriteFactory.Instance.CreateSwordSplitBottomLeft();
            Sprite4 = ItemSpriteFactory.Instance.CreateSwordSplitBottomRight();
            Position = position;
            Position2 = position;
            Position3 = position;
            Position4 = position;
            speed = 1.0f;
            count = 0;
            totalTime = 16;

        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (count <= totalTime)
            {
                Sprite.Draw(spriteBatch, Position, color);
                Sprite2.Draw(spriteBatch, Position2, color);
                Sprite3.Draw(spriteBatch, Position3, color);
                Sprite4.Draw(spriteBatch, Position4, color);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (count <= totalTime)
            {
                Sprite.Update(gameTime);
                Sprite2.Update(gameTime);
                Sprite3.Update(gameTime);
                Sprite4.Update(gameTime);

                Move();
                count++;
            }
        }

        public override void Move()
        {
            Position = new Vector2(Position.X - speed * Global.Var.SCALE, Position.Y - speed * Global.Var.SCALE);
            Position2 = new Vector2(Position2.X + speed * Global.Var.SCALE, Position2.Y - speed * Global.Var.SCALE);
            Position3 = new Vector2(Position3.X - speed * Global.Var.SCALE, Position3.Y + speed * Global.Var.SCALE);
            Position4 = new Vector2(Position4.X + speed * Global.Var.SCALE, Position4.Y + speed * Global.Var.SCALE);
        }
    }
}
