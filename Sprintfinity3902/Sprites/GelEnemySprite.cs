using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class GelEnemySprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int GEL1_POS_X = 1;
        private const int GEL1_POS_Y = 16;
        private const int GEL1_WIDTH = 8;
        private const int GEL1_HEIGHT = 8;

        private const int GEL2_POS_X = 10;
        private const int GEL2_POS_Y = 15;
        private const int GEL2_WIDTH = 8;
        private const int GEL2_HEIGHT = 9;

        public GelEnemySprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, GEL1_POS_X, GEL1_POS_Y, GEL1_WIDTH, GEL1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, GEL2_POS_X, GEL2_POS_Y, GEL2_WIDTH, GEL2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 24f);
            Animation.AddFrame(Sprite1, 1 / 12f);
        }

    }
}
