using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Navigation
{
    public class Camera {

        private static string FILE_NAME = "NES - The Legend of Zelda - Level 1 E";

        private static Texture2D map;

        private Rectangle windowBounds = new Rectangle(1, 1, 256, 240);

        private static Camera instance;

        public static Camera Instance {
            get {
                if (instance == null) {
                    instance = new Camera();

                }
                return instance;
            }
        }

        public Camera() { 

        }

        public void SetWindowBounds(GraphicsDeviceManager graphics) {
            graphics.PreferredBackBufferWidth = windowBounds.Width* Game1.ScaleWindow;
            graphics.PreferredBackBufferHeight = windowBounds.Height* Game1.ScaleWindow;
        }

        public void LoadAllTextures(ContentManager content) {
            map = content.Load<Texture2D>(FILE_NAME);
        }

        public void Update(GameTime gametime) { 
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(map, Vector2.Zero, windowBounds, Color.White, Global.Var.ZERO, new Vector2(0,0), Game1.ScaleWindow, SpriteEffects.None, 0.0f);
        }

    }
}
