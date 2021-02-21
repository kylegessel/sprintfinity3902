using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class GoriyaEnemyLeftSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int GORIYA1_POS_X = 257;
        private const int GORIYA1_POS_Y = 11;
        private const int GORIYA1_WIDTH = 14;
        private const int GORIYA1_HEIGHT = 16;

        private const int GORIYA2_POS_X = 275;
        private const int GORIYA2_POS_Y = 12;
        private const int GORIYA2_WIDTH = 14;
        private const int GORIYA2_HEIGHT = 16;

        public GoriyaEnemyLeftSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, GORIYA1_POS_X, GORIYA1_POS_Y, GORIYA1_WIDTH, GORIYA1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, GORIYA2_POS_X, GORIYA2_POS_Y, GORIYA2_WIDTH, GORIYA2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) {
            spriteBatch.Draw(Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 5.0f, SpriteEffects.FlipHorizontally, 0);
        }
    }
}
