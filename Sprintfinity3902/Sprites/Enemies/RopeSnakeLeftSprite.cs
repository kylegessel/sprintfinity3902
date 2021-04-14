using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class RopeSnakeLeftSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int SNAKE1_POS_X = 127;
        private const int SNAKE1_POS_Y = 59;
        private const int SNAKE1_WIDTH = 14;
        private const int SNAKE1_HEIGHT = 14;

        private const int SNAKE2_POS_X = 144;
        private const int SNAKE2_POS_Y = 60;
        private const int SNAKE2_WIDTH = 14;
        private const int SNAKE2_HEIGHT = 14;

        public RopeSnakeLeftSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, SNAKE1_POS_X, SNAKE1_POS_Y, SNAKE1_WIDTH, SNAKE1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, SNAKE2_POS_X, SNAKE2_POS_Y, SNAKE2_WIDTH, SNAKE2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 4f);
            Animation.AddFrame(Sprite1, 1 / 2f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, color, 0f, new Vector2(0, 0), Global.Var.SCALE, SpriteEffects.FlipHorizontally, 0);
        }
    }
}
