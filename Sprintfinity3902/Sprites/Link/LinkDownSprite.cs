using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class LinkDownSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_DOWN1_POS_X = 1;
        private const int LINK_DOWN1_POS_Y = 11;
        private const int LINK_DOWN1_WIDTH = 15;
        private const int LINK_DOWN1_HEIGHT = 16;

        private const int LINK_DOWN2_POS_X = 18;
        private const int LINK_DOWN2_POS_Y = 11;
        private const int LINK_DOWN2_WIDTH = 14;
        private const int LINK_DOWN2_HEIGHT = 16;

        public LinkDownSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, LINK_DOWN1_POS_X, LINK_DOWN1_POS_Y, LINK_DOWN1_WIDTH, LINK_DOWN1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, LINK_DOWN2_POS_X, LINK_DOWN2_POS_Y, LINK_DOWN2_WIDTH, LINK_DOWN2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            base.Draw(spriteBatch, position, color);
        }
    }
}
