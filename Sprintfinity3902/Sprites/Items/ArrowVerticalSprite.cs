using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites.Items
{ 
    public class ArrowVerticalSprite : AbstractSprite
    { 
        public Texture2D Texture { get; set; }

        private const int ARROW_POS_X = 3;
        private const int ARROW_POS_Y = 185;
        private const int ARROW_WIDTH = 5;
        private const int ARROW_HEIGHT = 16;

        public ArrowVerticalSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, ARROW_POS_X, ARROW_POS_Y, ARROW_WIDTH, ARROW_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
        }
    }
}
