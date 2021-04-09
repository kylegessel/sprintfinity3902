using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class ManhandlaUpMouthSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BOSS1_POS_X = 35;
        private const int BOSS1_POS_Y = 89;
        private const int BOSS1_WIDTH = 16;
        private const int BOSS1_HEIGHT = 16;

        private const int BOSS2_POS_X = 52;
        private const int BOSS2_POS_Y = 89;
        private const int BOSS2_WIDTH = 16;
        private const int BOSS2_HEIGHT = 16;

        public ManhandlaUpMouthSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, BOSS1_POS_X, BOSS1_POS_Y, BOSS1_WIDTH, BOSS1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, BOSS2_POS_X, BOSS2_POS_Y, BOSS2_WIDTH, BOSS2_HEIGHT); Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 4f);
            Animation.AddFrame(Sprite1, 2 / 4f);

        }
    }
}
