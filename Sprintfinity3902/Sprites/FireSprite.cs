using Microsoft.Xna.Framework.Graphics;


namespace Sprintfinity3902.Sprites
{
    public class FireSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int FIRE_POS_X = 52;
        private const int FIRE_POS_Y = 11;
        private const int FIRE_WIDTH = 16;
        private const int FIRE_HEIGHT = 16;


        public FireSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, FIRE_POS_X, FIRE_POS_Y, FIRE_WIDTH, FIRE_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);

        }
    }
}
