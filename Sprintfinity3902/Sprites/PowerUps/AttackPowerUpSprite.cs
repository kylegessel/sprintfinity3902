using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites.PowerUps
{
    public class AttackPowerUpItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int POWER_UP_X = 0;
        private const int POWER_UP_Y = 0;
        private const int POWER_UP_WIDTH = 16;
        private const int POWER_UP_HEIGHT = 16;

        public AttackPowerUpItemSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, POWER_UP_X, POWER_UP_Y, POWER_UP_WIDTH, POWER_UP_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
        }
    }
}
