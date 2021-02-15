using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class FireAttackSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int FIRE_LGREEN_X = 101;
        private const int FIRE_LGREEN_Y = 14;
        private const int FIRE_LGREEN_WIDTH = 8;
        private const int FIRE_LGREEN_HEIGHT = 10;

        private const int FIRE_GREEN_X = 110;
        private const int FIRE_GREEN_Y = 14;
        private const int FIRE_GREEN_WIDTH = 8;
        private const int FIRE_GREEN_HEIGHT = 10;

        private const int FIRE_RED_X = 119;
        private const int FIRE_RED_Y = 14;
        private const int FIRE_RED_WIDTH = 8;
        private const int FIRE_RED_HEIGHT = 10;

        private const int FIRE_BLUE_X = 128;
        private const int FIRE_BLUE_Y = 14;
        private const int FIRE_BLUE_WIDTH = 8;
        private const int FIRE_BLUE_HEIGHT = 10;

        public FireAttackSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, FIRE_LGREEN_X, FIRE_LGREEN_Y, FIRE_LGREEN_WIDTH, FIRE_LGREEN_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, FIRE_GREEN_X, FIRE_GREEN_Y, FIRE_GREEN_WIDTH, FIRE_GREEN_HEIGHT);
            SpriteFrame Sprite3 = new SpriteFrame(texture, FIRE_RED_X, FIRE_RED_Y, FIRE_RED_WIDTH, FIRE_RED_HEIGHT);
            SpriteFrame Sprite4 = new SpriteFrame(texture, FIRE_BLUE_X, FIRE_BLUE_Y, FIRE_BLUE_WIDTH, FIRE_BLUE_HEIGHT);
            Texture = texture;

            Animation = new Animation(true);
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1/128f);
            Animation.AddFrame(Sprite3, 1/64f);
            Animation.AddFrame(Sprite4, 1/32f);
            Animation.AddFrame(Sprite1, 1/16f);
        }
    }
}
