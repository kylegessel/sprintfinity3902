using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class DodongoBackDamagedSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BOSS_POS_X = 52;
        private const int BOSS_POS_Y = 58;
        private const int BOSS_WIDTH = 16;
        private const int BOSS_HEIGHT = 16;

        public DodongoBackDamagedSprite(Texture2D texture)
        {
            SpriteFrame Sprite = new SpriteFrame(texture, BOSS_POS_X, BOSS_POS_Y, BOSS_WIDTH, BOSS_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite, 0);

        }

    }
}