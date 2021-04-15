using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class DodongoRightDamagedSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BOSS_POS_X = 135;
        private const int BOSS_POS_Y = 58;
        private const int BOSS_WIDTH = 32;
        private const int BOSS_HEIGHT = 16;

        public DodongoRightDamagedSprite(Texture2D texture)
        {
            SpriteFrame Sprite = new SpriteFrame(texture, BOSS_POS_X, BOSS_POS_Y, BOSS_WIDTH, BOSS_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite, 0);
            Animation.AddFrame(Sprite, 1 / 4f);
            Animation.AddFrame(Sprite, 1 / 2f);
        }

    }
}