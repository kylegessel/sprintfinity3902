using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class InGameHudBottomBlackBarSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int ICON_X = 258;
        private const int ICON_Y = 59;
        private const int ICON_WIDTH = 256;
        private const int ICON_HEIGHT = 8;

        public InGameHudBottomBlackBarSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, ICON_X, ICON_Y, ICON_WIDTH, ICON_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
