using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class DungeonHudSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int HUD_X = 258;
        private const int HUD_Y = 112;
        private const int HUD_WIDTH = 256;
        private const int HUD_HEIGHT = 88;

        public DungeonHudSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, HUD_X, HUD_Y, HUD_WIDTH, HUD_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
