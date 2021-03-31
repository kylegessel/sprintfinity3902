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
using System.Collections.Generic;

namespace Sprintfinity3902
{
    public class Game1 : Game, IGame<Game1.GameState>
    {
        public enum GameState
        {
            INTRO,
            PLAYING,
            PAUSED,
            PAUSED_TRANSITION,
            WIN,
            LOSE,
            OPTIONS,
            RESET
        };

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;

        private static Rectangle windowBounds = new Rectangle(1, 1, 256, 240);
        public GameState State { get; private set; }
        public GraphicsDeviceManager Graphics { get { return graphics; } }

        public ILink link;
        public IPlayer playerCharacter;

        public IDungeon dungeon;
        public PauseMenu pauseMenu;
        public OptionMenu optionMenu;
        
        public List<IHud> huds;

        private ISprite titleScreen;
        private string introMusicInstanceID;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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

            Reset();
        }

        public void Reset()
        {
            KeyboardManager.Instance.Reset();
            SoundManager.Instance.Reset();
            CollisionDetector.Instance.Reset();

            titleScreen = BlockSpriteFactory.Instance.CreateTitleScreen();

            link = new Player(this);
            playerCharacter = (IPlayer)link;

            dungeon = new Dungeon.Dungeon(this);

            pauseMenu = new PauseMenu(this);
            optionMenu = new OptionMenu(this);

            huds = new List<IHud>();

            /*Order of these now relevent*/
            huds.Add(new DungeonHud(this));
            huds.Add(new InGameHud(this));
            huds.Add(new InventoryHud(this));
            huds.Add(new MiniMapHud(this));

            KeyboardManager.Instance.RegisterKeyUpCallback(Exit, Keys.Q);
            KeyboardManager.Instance.RegisterKeyUpCallback(Reset, Keys.R);
            KeyboardManager.Instance.RegisterKeyUpCallback(Pause, Keys.P);

            UpdateState(GameState.INTRO);
        }

        public void Pause()
        {
            if (!State.Equals(GameState.PAUSED_TRANSITION)) {
                UpdateState(GameState.PAUSED_TRANSITION);
            }
        }

        public void StartGame()
        {
            if (!State.Equals(GameState.PLAYING))
            {
                UpdateState(GameState.PLAYING);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardManager.Instance.Update(gameTime);

            switch (State) {
                case GameState.INTRO:
                    titleScreen.Update(gameTime);
                    break;
                case GameState.PAUSED:
                    break;
                case GameState.PAUSED_TRANSITION:
                    pauseMenu.Update(gameTime);

                    break;
                case GameState.LOSE:
                case GameState.WIN:
                    dungeon.Update(gameTime);
                    link.Update(gameTime);
                    foreach (IHud hud in huds) {
                        hud.Update(gameTime);
                    }
                    break;
                case GameState.PLAYING:
                    foreach (IHud hud in huds) {
                        hud.Update(gameTime);
                    }

                    dungeon.Update(gameTime);
                    link.Update(gameTime);
                    
                    break;
                case GameState.OPTIONS:
                    optionMenu.Update(gameTime);
                    break;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            switch (State) {
                case GameState.INTRO:
                    titleScreen.Draw(SpriteBatch, new Vector2(0, 16 * Global.Var.SCALE), Color.White);
                    break;
                case GameState.PAUSED:
                case GameState.PAUSED_TRANSITION:
                case GameState.LOSE:
                case GameState.WIN:
                case GameState.PLAYING:
                    
                    foreach (IHud hud in huds) {
                        hud.Draw(SpriteBatch, Color.White);
                    }

                    dungeon.Draw(SpriteBatch);

                    link.Draw(SpriteBatch, Color.White);

                    break;
                case GameState.OPTIONS:
                    optionMenu.Draw(SpriteBatch);
                    break;
            }
            
            SpriteBatch.End();
        }

        public void UpdateState(GameState state) {

            if (state.Equals(State)) return;

            switch (state) {
                case GameState.INTRO:
                    introMusicInstanceID = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Intro), 0.02f, true);
                    SoundManager.Instance.GetSoundEffectInstance(introMusicInstanceID).Play();

                    KeyboardManager.Instance.PushCommandMatrix(copyPreviousLayer: true);
                    KeyboardManager.Instance.RegisterKeyUpCallback(StartGame, Keys.Enter);
                    break;
                case GameState.PAUSED:
                    KeyboardManager.Instance.RegisterKeyUpCallback(((InventoryHud)huds[2]).MoveSelectorLeft, Keys.A, Keys.Left);
                    KeyboardManager.Instance.RegisterKeyUpCallback(((InventoryHud)huds[2]).MoveSelectorRight, Keys.D, Keys.Right);
                    break;
                case GameState.PAUSED_TRANSITION:
                    if (State.Equals(GameState.PLAYING)) {
                        KeyboardManager.Instance.PushCommandMatrix();
                        KeyboardManager.Instance.RegisterKeyUpCallback(Pause, Keys.P);
                    }
                    break;
                case GameState.WIN:
                    dungeon.UpdateState(IDungeon.GameState.WIN);
                    break;
                case GameState.OPTIONS:
                    KeyboardManager.Instance.PushCommandMatrix();
                    optionMenu.Start();
                    KeyboardManager.Instance.PushCommandMatrix();
                    break;
                case GameState.PLAYING:
                    SoundManager.Instance.GetSoundEffectInstance(introMusicInstanceID).Stop();

                    if (State.Equals(GameState.PAUSED_TRANSITION)) {
                        KeyboardManager.Instance.PopCommandMatrix();
                    } else if (State.Equals(GameState.INTRO)) {
                        KeyboardManager.Instance.PopCommandMatrix();
                        dungeon.Initialize();
                        playerCharacter.Initialize();
                    }
                    break;
                case GameState.LOSE:
                    dungeon.UpdateState(IDungeon.GameState.LOSE);
                    break;
                case GameState.RESET:
                    Reset();
                    return;
            }

            State = state;
        }

        public bool IsInState(GameState state) {
            return State.Equals(state);
        }
    }
}