using Microsoft.Xna.Framework.Graphics;


namespace Sprintfinity3902.Sprites
{
    public class OldManNPCSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int NPC2_POS_X = 18;
        private const int NPC2_POS_Y = 11;
        private const int NPC2_WIDTH = 16;
        private const int NPC2_HEIGHT = 16;

        public OldManNPCSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, NPC2_POS_X, NPC2_POS_Y, NPC2_WIDTH, NPC2_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);

        }
    }
}
