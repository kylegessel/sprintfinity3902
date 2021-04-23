using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class LoadingScreenSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int SCREEN1_POS_X = 0;
        private const int SCREEN1_POS_Y = 0;
        private const int SCREEN1_WIDTH = 256;
        private const int SCREEN1_HEIGHT = 240;

        private const int SCREEN2_POS_X = 265;
        private const int SCREEN2_POS_Y = 15;
        private const int SCREEN2_WIDTH = 256;
        private const int SCREEN2_HEIGHT = 240;

        public LoadingScreenSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, SCREEN1_POS_X, SCREEN1_POS_Y, SCREEN1_WIDTH, SCREEN1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, SCREEN2_POS_X, SCREEN2_POS_Y, SCREEN2_WIDTH, SCREEN2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1f);
            Animation.AddFrame(Sprite1, 2f);
        }

    }
}