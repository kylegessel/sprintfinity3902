using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class BlueBatEnemySprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BAT1_POS_X = 183;
        private const int BAT1_POS_Y = 15;
        private const int BAT1_WIDTH = 16;
        private const int BAT1_HEIGHT = 10;

        private const int BAT2_POS_X = 200;
        private const int BAT2_POS_Y = 15;
        private const int BAT2_WIDTH = 16;
        private const int BAT2_HEIGHT = 10;

        public BlueBatEnemySprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, BAT1_POS_X, BAT1_POS_Y, BAT1_WIDTH, BAT1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, BAT2_POS_X, BAT2_POS_Y, BAT2_WIDTH, BAT2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 10f);
            Animation.AddFrame(Sprite1, 1 / 5f);
        }

    }
}
