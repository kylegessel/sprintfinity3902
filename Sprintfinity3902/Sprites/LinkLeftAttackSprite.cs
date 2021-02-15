using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class LinkLeftAttackSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int LINK_LATTACK1_POS_X = 1;
        private const int LINK_LATTACK1_POS_Y = 78;
        private const int LINK_LATTACK1_WIDTH = 15;
        private const int LINK_LATTACK1_HEIGHT = 15;

        private const int LINK_LATTACK2_POS_X = 18;
        private const int LINK_LATTACK2_POS_Y = 78;
        private const int LINK_LATTACK2_WIDTH = 27;
        private const int LINK_LATTACK2_HEIGHT = 15;

        private const int LINK_LATTACK3_POS_X = 46;
        private const int LINK_LATTACK3_POS_Y = 78;
        private const int LINK_LATTACK3_WIDTH = 23;
        private const int LINK_LATTACK3_HEIGHT = 15;

        private const int LINK_LATTACK4_POS_X = 70;
        private const int LINK_LATTACK4_POS_Y = 77;
        private const int LINK_LATTACK4_WIDTH = 19;
        private const int LINK_LATTACK4_HEIGHT = 16;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(Animation.CurrentFrame.Sprite.Texture, position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0.0f, new Vector2(0, 0), 5.0f, SpriteEffects.FlipHorizontally, 0.0f);
        }
        public LinkLeftAttackSprite(Texture2D texture)
        {
            SpriteFrame Sprite1 = new SpriteFrame(texture, LINK_LATTACK1_POS_X, LINK_LATTACK1_POS_Y, LINK_LATTACK1_WIDTH, LINK_LATTACK1_HEIGHT);
            SpriteFrame Sprite2 = new SpriteFrame(texture, LINK_LATTACK2_POS_X, LINK_LATTACK2_POS_Y, LINK_LATTACK2_WIDTH, LINK_LATTACK2_HEIGHT);
            SpriteFrame Sprite3 = new SpriteFrame(texture, LINK_LATTACK3_POS_X, LINK_LATTACK3_POS_Y, LINK_LATTACK3_WIDTH, LINK_LATTACK3_HEIGHT);
            SpriteFrame Sprite4 = new SpriteFrame(texture, LINK_LATTACK4_POS_X, LINK_LATTACK4_POS_Y, LINK_LATTACK4_WIDTH, LINK_LATTACK4_HEIGHT);
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
