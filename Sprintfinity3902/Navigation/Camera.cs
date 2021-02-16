using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Navigation
{
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
            _sourceRectangle = new Rectangle(0,0,1900,1000);
            ((Game1)_game).Graphics.PreferredBackBufferWidth = _sourceRectangle.Width;
            ((Game1)_game).Graphics.PreferredBackBufferHeight = _sourceRectangle.Height;



        }

        public void LoadAllTextures(ContentManager content) {
            map = content.Load<Texture2D>(FILE_NAME);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(map, Vector2.Zero, _sourceRectangle, Color.White, 0, new Vector2(0,0), Game1.ScaleWindow, SpriteEffects.None, 0.0f);
        }


    }
}
