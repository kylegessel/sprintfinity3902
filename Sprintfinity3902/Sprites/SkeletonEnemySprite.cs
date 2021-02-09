using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class SkeletonEnemySprite : AbstractEntity
    {
        public Texture2D Texture { get; set; }

        private const int SKELETON_POS_X = 2;
        private const int SKELETON_POS_Y = 59;
        private const int SKELETON_WIDTH = 15;
        private const int SKELETON_HEIGHT = 16;

        public SkeletonEnemySprite(Texture2D texture)
        {
            Sprite Sprite = new Sprite(texture, SKELETON_POS_X, SKELETON_POS_Y, SKELETON_WIDTH, SKELETON_HEIGHT);
            Texture = texture;
            Position = new Vector2(1100, 500);

            Animation = new Animation();
            Animation.AddFrame(Sprite, 0);
            Animation.AddFrame(Sprite, 1 / 4f);
            Animation.AddFrame(Sprite, 1 / 2f);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Texture, Position, Animation.CurrentFrame.Sprite.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 5.0f, Animation.CurrentFrame == Animation.GetFrame(1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    
    }
}

