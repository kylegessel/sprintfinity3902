using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class Sprite
    {
        public Texture2D Texture { get; private set; }
        public Rectangle SourceRectangle { get; private set; }
        public int X { 
            get {
                return SourceRectangle.X;
            }
        }
        public int Y {
            get {
                return SourceRectangle.Y;
            }
        }
        public int Width {
            get {
                return SourceRectangle.Width;
            }
        }
        public int Height {
            get {
                return SourceRectangle.Height;
            }
        }
        public Sprite(Texture2D texture, int x, int y, int width, int height)
        {
            Texture = texture;
            SourceRectangle = new Rectangle(x, y, width, height);
        }

        public Sprite(Texture2D texture, Rectangle sourceRectangle) {
            Texture = texture;
            SourceRectangle = sourceRectangle;
        }

    }
}

