using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Maps;
using Sprintfinity3902.Navigation;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Entities;

namespace Sprintfinity3902
{
    public class Game1 : Game {

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;

        public static int ScaleWindow = 7;
        public GraphicsDeviceManager Graphics { get { return graphics; } }

        public ILink playerCharacter;
        private Player link;

        private IMap sprintTwo; 

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Window.Title = "The Legend of Zelda";
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Camera.Instance.SetWindowBounds(graphics);
            sprintTwo = new DefaultMap();

            Graphics.ApplyChanges();
        }

        protected override void Initialize() {
            base.Initialize();
        }

        protected void Reset() {
            KeyboardManager.Instance.Reset();

            playerCharacter = new Player();
            link = (Player)playerCharacter;

            sprintTwo.Setup(this);

            KeyboardManager.Instance.Initialize(link);

            KeyboardManager.Instance.RegisterKeyUpCallback(() => { link.CurrentState.Sprite.Animation.Stop(); }, Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right);

            KeyboardManager.Instance.RegisterKeyUpCallback(Exit, Keys.Q);
            KeyboardManager.Instance.RegisterKeyUpCallback(Reset, Keys.R);
        }

        protected override void LoadContent() {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Camera.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);

            Reset();
        }

        protected override void Update(GameTime gameTime) {
            KeyboardManager.Instance.Update(gameTime);
            InputMouse.Instance.Update(gameTime);
            Camera.Instance.Update(gameTime);

            playerCharacter.Update(gameTime);

            sprintTwo.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.DarkSlateGray);
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            Camera.Instance.Draw(SpriteBatch);

            sprintTwo.Draw(SpriteBatch);

            playerCharacter.Draw(SpriteBatch, Color.White);

            SpriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
