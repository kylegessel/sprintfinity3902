using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Sprintfinity3902.Navigation {
    public class Camera {

        private static string FILE_NAME = "NES - The Legend of Zelda - Level 1 E";

        private Texture2D map;
        private Game _game;
        private Rectangle _sourceRectangle;

        public Rectangle SourceRectangle {
            get {
                return _sourceRectangle;
            }
        }

        public GameWindow Window {
            get {
                return _game.Window;
            }
        }

        public Camera(Game game) {
            _game = game;
            _sourceRectangle = new Rectangle(1,0,257,177);
        }

        public void LoadAllTextures(ContentManager content) {
            map = content.Load<Texture2D>(FILE_NAME);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(map, Vector2.Zero, _sourceRectangle, Color.White, 0, new Vector2(0,0), Game1.ScaleWindow, SpriteEffects.None, 0.0f);
        }


    }
}
