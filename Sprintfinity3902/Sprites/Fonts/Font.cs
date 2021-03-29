using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;
using IDrawable = Sprintfinity3902.Interfaces.IDrawable;

namespace Sprintfinity3902.Sprites.Fonts
{
    public class Font
    {
        private string text;
        private List<Rectangle> sourceRectangles;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Font(string _text) {
            text = _text;
            UpdateText(text);
        }

        public void UpdateText(string text) {
            sourceRectangles =  FontSpriteFactory.Instance.GenerateSourceRectangles(text);
            Width = sourceRectangles.Count * Global.Var.SCALE * FontSpriteFactory.ITEM_WIDTH;
            Height = Global.Var.SCALE * FontSpriteFactory.ITEM_HEIGHT;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            for (int i = 0; i < sourceRectangles.Count; i++) {
                spriteBatch.Draw(FontSpriteFactory.Texture, new Vector2(pos.X + i* Global.Var.SCALE * FontSpriteFactory.ITEM_WIDTH, pos.Y), sourceRectangles[i], Color.White, 0.0f, new Vector2(0,0), Global.Var.SCALE, SpriteEffects.None, 0.0f);
            }
                
        }
    }
}
