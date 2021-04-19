using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class FluteIconSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int ICON_X = 664;
        private const int ICON_Y = 137;
        private const int ICON_WIDTH = 8;
        private const int ICON_HEIGHT = 16;

        public FluteIconSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, ICON_X, ICON_Y, ICON_WIDTH, ICON_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
