using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites.Items
{
    class SwordSplitTopLeftSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }


        private const int SPLIT_X1 = 25;
        private const int SPLIT_Y1 = 157;
        private const int SPLIT_WIDTH1 = 10;
        private const int SPLIT_HEIGHT1 = 10;

        private const int SPLIT_X2 = 95;
        private const int SPLIT_Y2 = 157;
        private const int SPLIT_WIDTH2 = 10;
        private const int SPLIT_HEIGHT2 = 10;

        public SwordSplitTopLeftSprite(Texture2D texture)
        {

            SpriteFrame Sprite1 = new SpriteFrame(texture, SPLIT_X1, SPLIT_Y1, SPLIT_WIDTH1, SPLIT_HEIGHT1);
            SpriteFrame Sprite2 = new SpriteFrame(texture, SPLIT_X2, SPLIT_Y2, SPLIT_WIDTH2, SPLIT_HEIGHT2);

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 32f);
            Animation.AddFrame(Sprite1, 1 / 16f);
        }

    }
}
