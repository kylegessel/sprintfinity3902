using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class LinkUpAttackSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_UATTACK1_POS_X = 1;
        private const int LINK_UATTACK1_POS_Y = 97;
        private const int LINK_UATTACK1_WIDTH = 16;
        private const int LINK_UATTACK1_HEIGHT = 28;

        private const int LINK_UATTACK2_POS_X = 18;
        private const int LINK_UATTACK2_POS_Y = 97;
        private const int LINK_UATTACK2_WIDTH = 16;
        private const int LINK_UATTACK2_HEIGHT = 28;

        private const int LINK_UATTACK3_POS_X = 35;
        private const int LINK_UATTACK3_POS_Y = 97;
        private const int LINK_UATTACK3_WIDTH = 16;
        private const int LINK_UATTACK3_HEIGHT = 28;

        private const int LINK_UATTACK4_POS_X = 52;
        private const int LINK_UATTACK4_POS_Y = 97;
        private const int LINK_UATTACK4_WIDTH = 16;
        private const int LINK_UATTACK4_HEIGHT = 28;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            position = new Vector2(position.X, position.Y-(12*5));
            spriteBatch.Draw(Animation.CurrentFrame.Sprite.Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, color, 0.0f, new Vector2(0, 0), 5.0f, SpriteEffects.FlipHorizontally, 0.0f);
        }
        public LinkUpAttackSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, LINK_UATTACK1_POS_X, LINK_UATTACK1_POS_Y, LINK_UATTACK1_WIDTH, LINK_UATTACK1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, LINK_UATTACK2_POS_X, LINK_UATTACK2_POS_Y, LINK_UATTACK2_WIDTH, LINK_UATTACK2_HEIGHT);
            SpriteFrame Sprite3 = new SpriteFrame(texture, LINK_UATTACK3_POS_X, LINK_UATTACK3_POS_Y, LINK_UATTACK3_WIDTH, LINK_UATTACK3_HEIGHT);
            SpriteFrame Sprite4 = new SpriteFrame(texture, LINK_UATTACK4_POS_X, LINK_UATTACK4_POS_Y, LINK_UATTACK4_WIDTH, LINK_UATTACK4_HEIGHT);
            Texture = texture;

            Animation = new Animation(false);
            Animation.AddFrame(Sprite1, 0);
            Animation.AddFrame(Sprite2, 1 / 32f);
            Animation.AddFrame(Sprite3, 2 / 8f);
            Animation.AddFrame(Sprite4, 3 / 8f);
            Animation.AddFrame(Sprite1, 4 / 8f);
            Animation.PlayOnce();
        }

    }
}
