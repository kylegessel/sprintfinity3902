using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprintfinity3902.Sprites
{
    class BoomerangStaticItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BOOMERANG_POS1_X = 65;
        private const int BOOMERANG_POS1_Y = 189;
        private const int BOOMERANG_WIDTH1 = 8;
        private const int BOOMERANG_HEIGHT1 = 8;


        public BoomerangStaticItemSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, BOOMERANG_POS1_X, BOOMERANG_POS1_Y, BOOMERANG_WIDTH1, BOOMERANG_HEIGHT1);

            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);

        }

    }
}
