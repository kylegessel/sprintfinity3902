using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites.Items
{
    public class ArrowHorizontalSprite : AbstractSprite
    { 
        public Texture2D Texture { get; set; }

        private const int ARROW_POS_X = 10;
        private const int ARROW_POS_Y = 190;
        private const int ARROW_WIDTH = 16;
        private const int ARROW_HEIGHT = 5;

        public ArrowHorizontalSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, ARROW_POS_X, ARROW_POS_Y, ARROW_WIDTH, ARROW_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
        }
    }
}
