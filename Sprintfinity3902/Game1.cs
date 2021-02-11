using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Controllers;
using System.Diagnostics;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Navigation;

namespace Sprintfinity3902 {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int ScaleWindow = 7;
        public GraphicsDeviceManager Graphics { get { return _graphics; } }

        public Texture2D texture;
        public IController mouse;
        public Player playerCharacter;
        public IEntity currentEnemy1;
        public IEntity gelEnemy;
        public Camera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Window.Title = "The Legend of Zelda";
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            camera = new Camera(this);
            Graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            camera.LoadAllTextures(Content);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);

            playerCharacter = new Player();
            currentEnemy1 = new SkeletonEnemy();
            gelEnemy = new GelEnemy();

            SetCommands();
            SetListeners();
        }

        protected override void Update(GameTime gameTime)
        {
            InputKeyboard.Instance.Update();
            InputMouse.Instance.Update();


            playerCharacter.Update(gameTime);
            currentEnemy1.Update(gameTime);
            gelEnemy.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            camera.Draw(_spriteBatch);
            playerCharacter.Draw(_spriteBatch);
            currentEnemy1.Draw(_spriteBatch);
            gelEnemy.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetCommands()
        {
            InputKeyboard input = InputKeyboard.Instance;
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                input.RegisterCommand(key, new DoNothingCommand(this));
            }

            input.RegisterCommand(new SetPlayerMoveCommand(playerCharacter, playerCharacter.facingUp), Keys.W, Keys.Up);
            input.RegisterCommand(new SetPlayerMoveCommand(playerCharacter, playerCharacter.facingLeft), Keys.A, Keys.Left);
            input.RegisterCommand(new SetPlayerMoveCommand(playerCharacter, playerCharacter.facingDown), Keys.S, Keys.Down);
            input.RegisterCommand(new SetPlayerMoveCommand(playerCharacter, playerCharacter.facingRight), Keys.D, Keys.Right);
 
        }

        public void SetListeners() {
            InputKeyboard.Instance.RegisterKeyUpCallback(() => { playerCharacter.CurrentState.Sprite.Animation.Stop(); }, Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
        }
    }
}
