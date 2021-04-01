using Microsoft.Xna.Framework;
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
            Animation.AddFrame(Sprite1, 1/8f);
            Animation.AddFrame(Sprite1, 1/4f);

        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, color, 0f, new Vector2(0, 0), Global.Var.SCALE, Animation.CurrentFrame == Animation.GetFrame(1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}
