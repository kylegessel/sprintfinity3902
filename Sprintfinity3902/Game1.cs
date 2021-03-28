using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System.Collections.Generic;
using Sprintfinity3902.Sound;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;

namespace Sprintfinity3902
{
    public class Game1 : Game, IGame<Game1.GameState>
    {
        public enum GameState
        {
            PLAYING,
            PAUSED,
            PAUSED_TRANSITION,
            WIN,
            LOSE,
            OPTIONS
        };

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;

        private static Rectangle windowBounds = new Rectangle(1, 1, 256, 240);
        public GameState State { get; private set; }
        public GraphicsDeviceManager Graphics { get { return graphics; } }

        public ILink playerCharacter;
        public Player link;
        
        public IDungeon dungeon;
        public PauseMenu pauseMenu;
        public OptionMenu optionMenu;
        
        public List<IHud> huds;

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

            playerCharacter = new Player(this);
            link = (Player)playerCharacter;
            link.Initialize();

            dungeon = new Dungeon.Dungeon(this);
            dungeon.Initialize();

            pauseMenu = new PauseMenu(this);
            optionMenu = new OptionMenu(this);

            huds = new List<IHud>();

            huds.Add(new DungeonHud(this));
            huds.Add(new InGameHud(this));
            huds.Add(new InventoryHud(this));
            huds.Add(new MiniMapHud(this));

            KeyboardManager.Instance.RegisterKeyUpCallback(Exit, Keys.Q);
            KeyboardManager.Instance.RegisterKeyUpCallback(Reset, Keys.R);
            KeyboardManager.Instance.RegisterKeyUpCallback(Pause, Keys.P);

            UpdateState(GameState.PLAYING);
        }

        public void Pause()
        {
            if (!State.Equals(GameState.PAUSED_TRANSITION)) {
                UpdateState(GameState.PAUSED_TRANSITION);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardManager.Instance.Update(gameTime);

            switch (State) {
                case GameState.PAUSED:
                    break;
                case GameState.PAUSED_TRANSITION:
                    pauseMenu.Update(gameTime);

                    break;
                case GameState.LOSE:
                case GameState.WIN:
                    dungeon.Update(gameTime);
                    playerCharacter.Update(gameTime);
                    foreach (IHud hud in huds) {
                        hud.Update(gameTime);
                    }
                    break;
                case GameState.PLAYING:
                    foreach (IHud hud in huds) {
                        hud.Update(gameTime);
                    }

                    dungeon.Update(gameTime);
                    playerCharacter.Update(gameTime);
                    
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
                case GameState.PAUSED:
                case GameState.PAUSED_TRANSITION:
                case GameState.LOSE:
                case GameState.WIN:
                case GameState.PLAYING:
                    
                    foreach (IHud hud in huds) {
                        foreach (IEntity icon in hud.Icons) {
                            icon.Draw(SpriteBatch, Color.White);
                        }
                    }

                    dungeon.Draw(SpriteBatch);

                    playerCharacter.Draw(SpriteBatch, Color.White);

                    break;
                case GameState.OPTIONS:
                    optionMenu.Draw(SpriteBatch);
                    break;
            }
            
            SpriteBatch.End();
        }

        public void UpdateState(GameState state) {
            switch (state) {
                case GameState.PAUSED:
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
                    optionMenu.Start();
                    break;
                case GameState.PLAYING:
                    if (State.Equals(GameState.PAUSED_TRANSITION)) {
                        KeyboardManager.Instance.PopCommandMatrix();
                    }
                    break;
                case GameState.LOSE:
                    dungeon.UpdateState(IDungeon.GameState.LOSE);
                    break;
            }

            State = state;
        }

        public bool IsInState(GameState state) {
            return State.Equals(state);
        }
    }
}