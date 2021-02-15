using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprintfinity3902.Sprites
{
    class BoomerangItemSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int BOOMERANG_POS1_X = 65;
        private const int BOOMERANG_POS1_Y = 189;
        private const int BOOMERANG_WIDTH1 = 8;
        private const int BOOMERANG_HEIGHT1 = 8;

        private const int BOOMERANG_POS2_X = 73;
        private const int BOOMERANG_POS2_Y = 189;
        private const int BOOMERANG_WIDTH2 = 8;
        private const int BOOMERANG_HEIGHT2 = 8;

        private const int BOOMERANG_POS3_X = 82;
        private const int BOOMERANG_POS3_Y = 192;
        private const int BOOMERANG_WIDTH3 = 8;
        private const int BOOMERANG_HEIGHT3 = 8;

        private const int BOOMERANG_POS4_X = 129;
        private const int BOOMERANG_POS4_Y = 206;
        private const int BOOMERANG_WIDTH4 = 8;
        private const int BOOMERANG_HEIGHT4 = 8;

        public BoomerangItemSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, BOOMERANG_POS1_X, BOOMERANG_POS1_Y, BOOMERANG_WIDTH1, BOOMERANG_HEIGHT1);
            SpriteFrame Sprite2 = new SpriteFrame(texture, BOOMERANG_POS2_X, BOOMERANG_POS2_Y, BOOMERANG_WIDTH2, BOOMERANG_HEIGHT2);
            SpriteFrame Sprite3 = new SpriteFrame(texture, BOOMERANG_POS3_X, BOOMERANG_POS3_Y, BOOMERANG_WIDTH3, BOOMERANG_HEIGHT3);
            SpriteFrame Sprite4 = new SpriteFrame(texture, BOOMERANG_POS4_X, BOOMERANG_POS4_Y, BOOMERANG_WIDTH4, BOOMERANG_HEIGHT4);

            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(Sprite1, 0 / 8f);
            Animation.AddFrame(Sprite2, 1 / 8f);
            Animation.AddFrame(Sprite3, 2 / 8f);
            Animation.AddFrame(Sprite2, 3 / 8f);
            Animation.AddFrame(Sprite1, 4 / 8f);
            Animation.AddFrame(Sprite4, 5 / 8f);
            Animation.AddFrame(Sprite3, 6 / 8f);
            Animation.AddFrame(Sprite2, 7 / 8f);
            Animation.AddFrame(Sprite1, 8/  8f);

        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            if (Animation.CurrentFrame == Animation.GetFrame(3))
            {
                spriteBatch.Draw(Animation.CurrentFrame.Sprite.Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 4.0f, SpriteEffects.FlipHorizontally, 0.0f);
            }else if(Animation.CurrentFrame == Animation.GetFrame(4))
            {
                spriteBatch.Draw(Animation.CurrentFrame.Sprite.Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 4.0f, SpriteEffects.FlipHorizontally, 0.0f);
            }
            // Skipping frame 5 and adding a new sprite, took me about 7 lines of code to get this right, feel it's just better to do the flip and change the spritesheet.
            else if (Animation.CurrentFrame == Animation.GetFrame(6))
            {
                spriteBatch.Draw(Animation.CurrentFrame.Sprite.Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 4.0f, SpriteEffects.FlipVertically, 0.0f);
            }
            else if (Animation.CurrentFrame == Animation.GetFrame(7))
            {
                spriteBatch.Draw(Animation.CurrentFrame.Sprite.Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 4.0f, SpriteEffects.FlipVertically, 0.0f);
            }
            else if (Animation.CurrentFrame == Animation.GetFrame(8))
            {
                spriteBatch.Draw(Animation.CurrentFrame.Sprite.Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 4.0f, SpriteEffects.FlipVertically, 0.0f);
            }
            else
            {
                spriteBatch.Draw(Animation.CurrentFrame.Sprite.Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 4.0f, SpriteEffects.None, 0.0f);

            }
        }

    }
}
