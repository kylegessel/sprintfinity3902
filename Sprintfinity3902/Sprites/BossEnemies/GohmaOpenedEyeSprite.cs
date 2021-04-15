using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class GohmaOpenedEyeSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BOSS1_POS_X = 446;
        private const int BOSS1_POS_Y = 105;
        private const int BOSS1_WIDTH = 47;
        private const int BOSS1_HEIGHT = 16;


        public GohmaOpenedEyeSprite(Texture2D texture)
        {
            Texture = texture;
            SpriteFrame Sprite1 = new SpriteFrame(texture, BOSS1_POS_X, BOSS1_POS_Y, BOSS1_WIDTH, BOSS1_HEIGHT);

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite1, 1 / 6f);
            Animation.AddFrame(Sprite1, 2 / 6f);

        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, color, 0f, new Vector2(0, 0), Global.Var.SCALE, Animation.CurrentFrame == Animation.GetFrame(0) ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }

    }
}