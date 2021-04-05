using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class ItemSelectIconSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int ICON_X = 519;
        private const int ICON_Y = 137;
        private const int ICON_WIDTH = 16;
        private const int ICON_HEIGHT = 16;

        private const int ICON2_X = 536;
        private const int ICON2_Y = 137;
        private const int ICON2_WIDTH = 16;
        private const int ICON2_HEIGHT = 16;

        public ItemSelectIconSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, ICON_X, ICON_Y, ICON_WIDTH, ICON_HEIGHT);
            SpriteFrame sprite2 = new SpriteFrame(texture, ICON2_X, ICON2_Y, ICON2_WIDTH, ICON2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            /*TODO: This doesn't work and I don't know why*/
            Animation.AddFrame(sprite1, 0);
            Animation.AddFrame(sprite2, 1/8f);
            Animation.AddFrame(sprite1, 1/4f);

        }
    }
}
