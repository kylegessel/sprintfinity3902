using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class LinkLeftSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_LEFT1_X = 35;
        private const int LINK_LEFT1_Y = 11;
        private const int LINK_LEFT1_WIDTH = 15;
        private const int LINK_LEFT1_HEIGHT = 16;

        private const int LINK_LEFT2_X = 52;
        private const int LINK_LEFT2_Y = 12;
        private const int LINK_LEFT2_WIDTH = 14;
        private const int LINK_LEFT2_HEIGHT = 15;

        public LinkLeftSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, LINK_LEFT1_X, LINK_LEFT1_Y, LINK_LEFT1_WIDTH, LINK_LEFT1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, LINK_LEFT2_X, LINK_LEFT2_Y, LINK_LEFT2_WIDTH, LINK_LEFT2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) //Need to change Color.White to color
        {
            spriteBatch.Draw(Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, color, 0f, new Vector2(0, 0), 5.0f, SpriteEffects.FlipHorizontally, 0);
        }
    }
}
