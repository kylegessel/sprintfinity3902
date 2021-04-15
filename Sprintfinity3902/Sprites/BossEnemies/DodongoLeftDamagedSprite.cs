using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class DodongoLeftDamagedSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BOSS_POS_X = 135;
        private const int BOSS_POS_Y = 58;
        private const int BOSS_WIDTH = 32;
        private const int BOSS_HEIGHT = 16;

        public DodongoLeftDamagedSprite(Texture2D texture)
        {
            SpriteFrame Sprite = new SpriteFrame(texture, BOSS_POS_X, BOSS_POS_Y, BOSS_WIDTH, BOSS_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite, 0);
            Animation.AddFrame(Sprite, 1 / 4f);
            Animation.AddFrame(Sprite, 1 / 2f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) //Need to change Color.White to color
        {
            spriteBatch.Draw(Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, color, 0f, new Vector2(0, 0), Global.Var.SCALE, SpriteEffects.FlipHorizontally, 0);
        }
    }
}