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

        private int count;
        private int totalTime;
        private float speed;
        private float shiftAmount;
        public MovingSwordSplitItem(Vector2 position)
        {
            Sprite = ItemSpriteFactory.Instance.CreateSwordSplitTopLeft();
            Sprite2 = ItemSpriteFactory.Instance.CreateSwordSplitTopRight();
            Sprite3 = ItemSpriteFactory.Instance.CreateSwordSplitBottomLeft();
            Sprite4 = ItemSpriteFactory.Instance.CreateSwordSplitBottomRight();
            Position = position;
            // Creating a position 1 so things will hold on pause.
            // Position will act as a store of starting position and we will change based on that.
            speed = 1.0f;
            count = 0;
            totalTime = 16;

        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (count <= totalTime)
            {
                Sprite.Draw(spriteBatch, new Vector2(Position.X - shiftAmount * Global.Var.SCALE, Position.Y - shiftAmount * Global.Var.SCALE), color);
                Sprite2.Draw(spriteBatch, new Vector2(Position.X + shiftAmount * Global.Var.SCALE, Position.Y - shiftAmount * Global.Var.SCALE), color);
                Sprite3.Draw(spriteBatch, new Vector2(Position.X - shiftAmount * Global.Var.SCALE, Position.Y + shiftAmount * Global.Var.SCALE), color);
                Sprite4.Draw(spriteBatch, new Vector2(Position.X + shiftAmount * Global.Var.SCALE, Position.Y + shiftAmount * Global.Var.SCALE), color);
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
            // We should update the positions in draw as they need to update dependent on the position.
            shiftAmount = speed * count;
        }
    }
}
