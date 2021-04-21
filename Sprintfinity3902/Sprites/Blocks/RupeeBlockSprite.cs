using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class RupeeBlockSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int RUPEE_G_X = 72;
        private const int RUPEE_G_Y = 0;
        private const int RUPEE_G_WIDTH = 8;
        private const int RUPEE_G_HEIGHT = 16;

        public RupeeBlockSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, RUPEE_G_X, RUPEE_G_Y, RUPEE_G_WIDTH, RUPEE_G_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
