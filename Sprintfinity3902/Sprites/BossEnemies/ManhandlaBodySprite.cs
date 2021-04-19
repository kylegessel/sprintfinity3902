using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class ManhandlaBodySprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BOSS_X = 69;
        private const int BOSS_Y = 89;
        private const int BOSS_WIDTH = 16;
        private const int BOSS_HEIGHT = 16;

        public ManhandlaBodySprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, BOSS_X, BOSS_Y, BOSS_WIDTH, BOSS_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
