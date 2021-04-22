using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class TitleScreenSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int SCREEN_WIDTH = 256;
        private const int SCREEN_HEIGHT = 224;

        private const int SCREEN1_X = 1;
        private const int SCREEN1_Y = 15;

        private const int SCREEN2_X = 258;
        private const int SCREEN2_Y = 15;

        private const int SCREEN3_X = 515;
        private const int SCREEN3_Y = 15;

        private const int SCREEN4_X = 772;
        private const int SCREEN4_Y = 15;

        private const int SCREEN5_X = 1;
        private const int SCREEN5_Y = 242;

        private const int SCREEN6_X = 258;
        private const int SCREEN6_Y = 242;

        private const int SCREEN7_X = 515;
        private const int SCREEN7_Y = 242;

        private const int SCREEN8_X = 772;
        private const int SCREEN8_Y = 242;

        private const int SCREEN9_X = 1;
        private const int SCREEN9_Y = 470;

        private const int SCREEN10_X = 258;
        private const int SCREEN10_Y = 470;

        private const int SCREEN11_X = 515;
        private const int SCREEN11_Y = 470;

        private const int SCREEN12_X = 772;
        private const int SCREEN12_Y = 470;

        private const int SCREEN13_X = 1;
        private const int SCREEN13_Y = 698;

        private const int SCREEN14_X = 258;
        private const int SCREEN14_Y = 698;

        private const int SCREEN15_X = 515;
        private const int SCREEN15_Y = 698;

        private const int SCREEN16_X = 772;
        private const int SCREEN16_Y = 698;

        public TitleScreenSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, SCREEN1_X, SCREEN1_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, SCREEN2_X, SCREEN2_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite3 = new SpriteFrame(texture, SCREEN3_X, SCREEN3_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite4 = new SpriteFrame(texture, SCREEN4_X, SCREEN4_Y, SCREEN_WIDTH, SCREEN_HEIGHT);

            SpriteFrame Sprite5 = new SpriteFrame(texture, SCREEN5_X, SCREEN5_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite6 = new SpriteFrame(texture, SCREEN6_X, SCREEN6_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite7 = new SpriteFrame(texture, SCREEN7_X, SCREEN7_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite8 = new SpriteFrame(texture, SCREEN8_X, SCREEN8_Y, SCREEN_WIDTH, SCREEN_HEIGHT);

            SpriteFrame Sprite9 = new SpriteFrame(texture, SCREEN9_X, SCREEN9_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite10 = new SpriteFrame(texture, SCREEN10_X, SCREEN10_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite11 = new SpriteFrame(texture, SCREEN11_X, SCREEN11_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite12 = new SpriteFrame(texture, SCREEN12_X, SCREEN12_Y, SCREEN_WIDTH, SCREEN_HEIGHT);

            SpriteFrame Sprite13 = new SpriteFrame(texture, SCREEN13_X, SCREEN13_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite14 = new SpriteFrame(texture, SCREEN14_X, SCREEN14_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite15 = new SpriteFrame(texture, SCREEN15_X, SCREEN15_Y, SCREEN_WIDTH, SCREEN_HEIGHT);
            SpriteFrame Sprite16 = new SpriteFrame(texture, SCREEN16_X, SCREEN16_Y, SCREEN_WIDTH, SCREEN_HEIGHT);

            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 20f);
            Animation.AddFrame(Sprite3, 2 / 20f);
            Animation.AddFrame(Sprite4, 3 / 20f);
            Animation.AddFrame(Sprite5, 4 / 20f);
            Animation.AddFrame(Sprite6, 5 / 20f);
            Animation.AddFrame(Sprite7, 6 / 20f);
            Animation.AddFrame(Sprite8, 7 / 20f);
            Animation.AddFrame(Sprite9, 8 / 20f);
            Animation.AddFrame(Sprite10, 9 / 20f);
            Animation.AddFrame(Sprite11, 10 / 20f);
            Animation.AddFrame(Sprite12, 11 / 20f);
            Animation.AddFrame(Sprite13, 12 / 20f);
            Animation.AddFrame(Sprite14, 13 / 20f);
            Animation.AddFrame(Sprite15, 14 / 20f);
            Animation.AddFrame(Sprite16, 15 / 20f);
            Animation.AddFrame(Sprite13, 16 / 20f);
            Animation.AddFrame(Sprite14, 17 / 20f);
            Animation.AddFrame(Sprite15, 18 / 20f);
            Animation.AddFrame(Sprite16, 19 / 20f);
            Animation.AddFrame(Sprite9, 20 / 20f);
            Animation.AddFrame(Sprite10, 21 / 20f);
            Animation.AddFrame(Sprite11, 22 / 20f);
            Animation.AddFrame(Sprite12, 23 / 20f);
            Animation.AddFrame(Sprite5, 24 / 20f);
            Animation.AddFrame(Sprite6, 25 / 20f);
            Animation.AddFrame(Sprite7, 26 / 20f);
            Animation.AddFrame(Sprite8, 27 / 20f);
            Animation.AddFrame(Sprite1, 28 / 20f);
            Animation.AddFrame(Sprite2, 29 / 20f);
            Animation.AddFrame(Sprite3, 30 / 20f);
            Animation.AddFrame(Sprite4, 31 / 20f);
            Animation.AddFrame(Sprite1, 32 / 20f);

        }

    }
}
