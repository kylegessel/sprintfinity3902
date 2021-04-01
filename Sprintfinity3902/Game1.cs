using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.Sound;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.States.GameStates;
using System.Collections.Generic;

namespace Sprintfinity3902
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch SpriteBatch;

        public IGameState INTRO { get; set; }
        public IGameState PLAYING { get; set; }
        public IGameState PAUSED { get; set; }
        public IGameState PAUSED_TRANSITION { get; set; }
        public IGameState WIN { get; set; }
        public IGameState LOSE { get; set; }
        public IGameState OPTIONS { get; set; }
        public IGameState RESET { get; set; }

        private static Rectangle windowBounds = new Rectangle(1, 1, 256, 240);
        public GraphicsDeviceManager Graphics { get { return _graphics; } }

        public ILink link;
        public IPlayer playerCharacter;

        public IDungeon dungeon;
        public PauseMenu pauseMenu;
        public OptionMenu optionMenu;
        
        public List<IHud> huds;

        public IGameState CurrentState;
        public IGameState PreviousState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Window.Title = "The Legend of Zelda";
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Graphics.PreferredBackBufferWidth = windowBounds.Width * Global.Var.SCALE;
            Graphics.PreferredBackBufferHeight = windowBounds.Height * Global.Var.SCALE;
            Graphics.ApplyChanges();

        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            HudSpriteFactory.Instance.LoadAllTextures(Content);
            FontSpriteFactory.Instance.LoadAllTextures(Content);

            SoundLoader.Instance.LoadContent(Content);

            RESET = new ResetState(this);
            CurrentState = RESET;
            SetState(RESET);
        }

        public void BuildStates()
        {
            INTRO = new IntroState(this);
            PLAYING = new PlayingState(this);
            PAUSED = new PausedState(this);
            PAUSED_TRANSITION = new Paused_TransitionState(this);
            WIN = new WinState(this);
            LOSE = new LoseState(this);
            OPTIONS = new OptionsState(this);
        }

        public void SetState(IGameState state)
        {
            PreviousState = CurrentState;
            CurrentState = state;
            CurrentState.SetUp();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardManager.Instance.Update(gameTime);
            CurrentState.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            CurrentState.Draw(SpriteBatch, gameTime);            
            SpriteBatch.End();
        }

    }
}