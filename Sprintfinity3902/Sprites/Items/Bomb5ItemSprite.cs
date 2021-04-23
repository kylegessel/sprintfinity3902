using Microsoft.Xna.Framework.Graphics;


namespace Sprintfinity3902.Sprites
{
    class Bomb5ItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; private set; }

        private const int BOMB_POS_X = 136;
        private const int BOMB_POS_Y = 14;
        private const int BOMB_WIDTH = 8;
        private const int BOMB_HEIGHT = 14;

        public Bomb5ItemSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, BOMB_POS_X, BOMB_POS_Y, BOMB_WIDTH, BOMB_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);

        }
    }
}
