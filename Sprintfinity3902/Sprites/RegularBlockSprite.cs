using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class RegularBlockSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BLOCK_X = 354;
        private const int BLOCK_Y = 81;
        private const int BLOCK_WIDTH = 16;
        private const int BLOCK_HEIGHT = 16;

        public RegularBlockSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, BLOCK_X, BLOCK_Y, BLOCK_WIDTH, BLOCK_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
