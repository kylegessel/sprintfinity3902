using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class LinkDownItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_DITEM1_POS_X = 107;
        private const int LINK_DITEM1_POS_Y = 11;
        private const int LINK_DITEM1_WIDTH = 16;
        private const int LINK_DITEM1_HEIGHT = 16;

        public LinkDownItemSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, LINK_DITEM1_POS_X, LINK_DITEM1_POS_Y, LINK_DITEM1_WIDTH, LINK_DITEM1_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite1, 1/4f);
        }


    }
}
