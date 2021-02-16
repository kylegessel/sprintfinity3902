using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class LinkRightItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_RITEM1_POS_X = 124;
        private const int LINK_RITEM1_POS_Y = 12;
        private const int LINK_RITEM1_WIDTH = 15;
        private const int LINK_RITEM1_HEIGHT = 15;

        public LinkRightItemSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, LINK_RITEM1_POS_X, LINK_RITEM1_POS_Y, LINK_RITEM1_WIDTH, LINK_RITEM1_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite1, 1/4f);
        }


    }
}
