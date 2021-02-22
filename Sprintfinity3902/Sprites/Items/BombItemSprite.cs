using Microsoft.Xna.Framework.Graphics;


namespace Sprintfinity3902.Sprites
{
    class BombItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; private set; }

        private const int BOMB_POS_X = 129;
        private const int BOMB_POS_Y = 185;
        private const int BOMB_WIDTH = 8;
        private const int BOMB_HEIGHT = 14;

        public BombItemSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, BOMB_POS_X, BOMB_POS_Y, BOMB_WIDTH, BOMB_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);

        }
    }
}
