using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class SpikeEnemySprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int SPIKE_X = 164;
        private const int SPIKE_Y = 59;
        private const int SPIKE_WIDTH = 16;
        private const int SPIKE_HEIGHT = 16;

        public SpikeEnemySprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, SPIKE_X, SPIKE_Y, SPIKE_WIDTH, SPIKE_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
