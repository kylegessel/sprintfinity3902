using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class BlueRupeeItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int RUPEE_B_X = 72;
        private const int RUPEE_B_Y = 16;
        private const int RUPEE_B_WIDTH = 8;
        private const int RUPEE_B_HEIGHT = 16;

        public BlueRupeeItemSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, RUPEE_B_X, RUPEE_B_Y, RUPEE_B_WIDTH, RUPEE_B_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }

    }
}
