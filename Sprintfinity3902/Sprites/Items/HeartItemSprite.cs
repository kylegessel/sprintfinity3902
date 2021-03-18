using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class HeartItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int HEART_R_X = 0;
        private const int HEART_R_Y = 0;
        private const int HEART_R_WIDTH = 7;
        private const int HEART_R_HEIGHT = 8;

        private const int HEART_B_X = 0;
        private const int HEART_B_Y = 8;
        private const int HEART_B_WIDTH = 7;
        private const int HEART_B_HEIGHT = 8;

        private const int RESET_THRESHOLD = 150;

        private int count;

        public HeartItemSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, HEART_R_X, HEART_R_Y, HEART_R_WIDTH, HEART_R_HEIGHT);
            SpriteFrame sprite2 = new SpriteFrame(texture, HEART_B_X, HEART_B_Y, HEART_B_WIDTH, HEART_B_HEIGHT);
            Texture = texture;
            count = 0;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
            Animation.AddFrame(sprite2, 1 / 8f);
            Animation.AddFrame(sprite1, 1 / 4f);
        }

        public override void Update(GameTime gameTime)
        {
            count++;
            if(count == RESET_THRESHOLD)
            {
                Animation.ChangeSpeed(1, 1 / 2f);
                Animation.ChangeSpeed(2, 1);
            }

            Animation.Update(gameTime);
        }
    }
}
