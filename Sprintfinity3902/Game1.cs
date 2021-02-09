using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Sprintfinity3902.Sprites;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Controllers;
using System.Diagnostics;

namespace Sprintfinity3902
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D texture;
        public IController mouse;
        public Player playerCharacter;
        public IEntity currentEnemy;
        public IEntity currentEnemy2;
        public IEntity currentEnemy3;
        public IEntity currentEnemy4;
        public IEntity currentEnemy5;
        public IEntity currentEnemy6;
        public IEntity currentEnemy7;
        public IEntity currentEnemy8;

        private const string linkSpriteSheet = "Zelda_Link_and_Items_Transparent";




        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 2000;
            _graphics.PreferredBackBufferHeight = 1000;
            Window.Title = "The Legend of Zelda";
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            mouse = new InputMouse(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>(linkSpriteSheet);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);

            playerCharacter = new Player(texture);
            
            currentEnemy = EnemySpriteFactory.Instance.CreateGelEnemy();
            currentEnemy2 = EnemySpriteFactory.Instance.CreateBlueBatEnemy();
            currentEnemy3 = EnemySpriteFactory.Instance.CreateGoriyaDownEnemy();
            currentEnemy4 = EnemySpriteFactory.Instance.CreateGoriyaUpEnemy();
            currentEnemy5 = EnemySpriteFactory.Instance.CreateGoriyaLeftEnemy();
            currentEnemy6 = EnemySpriteFactory.Instance.CreateGoriyaRightEnemy();
            currentEnemy7 = EnemySpriteFactory.Instance.CreateSkeletonEnemy();
            currentEnemy8 = EnemySpriteFactory.Instance.CreateHandEnemy();

            SetCommands();
            SetListeners();
        }

        protected override void Update(GameTime gameTime)
        {
            InputKeyboard.Instance.Update();
            mouse.Update();

            playerCharacter.Update(gameTime);
            currentEnemy.Update(gameTime);
            currentEnemy2.Update(gameTime);
            currentEnemy3.Update(gameTime);
            currentEnemy4.Update(gameTime);
            currentEnemy5.Update(gameTime);
            currentEnemy6.Update(gameTime);
            currentEnemy7.Update(gameTime);
            currentEnemy8.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            playerCharacter.Draw(_spriteBatch);
            currentEnemy.Draw(_spriteBatch);
            currentEnemy2.Draw(_spriteBatch);
            currentEnemy3.Draw(_spriteBatch);
            currentEnemy4.Draw(_spriteBatch);
            currentEnemy5.Draw(_spriteBatch);
            currentEnemy6.Draw(_spriteBatch);
            currentEnemy7.Draw(_spriteBatch);
            currentEnemy8.Draw(_spriteBatch);

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

            input.RegisterCommand(Keys.W, new SetPlayerMoveCommand(playerCharacter, playerCharacter.facingUp));
            input.RegisterCommand(Keys.A, new SetPlayerMoveCommand(playerCharacter, playerCharacter.facingLeft));
            input.RegisterCommand(Keys.S, new SetPlayerMoveCommand(playerCharacter, playerCharacter.facingDown));
            input.RegisterCommand(Keys.D, new SetPlayerMoveCommand(playerCharacter, playerCharacter.facingRight));
        }

        public void SetListeners() {
            InputKeyboard.Instance.RegisterKeyUpCallback(Keys.W, () => { playerCharacter.CurrentState.Sprite.Animation.Stop(); });
            InputKeyboard.Instance.RegisterKeyUpCallback(Keys.A, () => { playerCharacter.CurrentState.Sprite.Animation.Stop(); });
            InputKeyboard.Instance.RegisterKeyUpCallback(Keys.S, () => { playerCharacter.CurrentState.Sprite.Animation.Stop(); });
            InputKeyboard.Instance.RegisterKeyUpCallback(Keys.D, () => { playerCharacter.CurrentState.Sprite.Animation.Stop(); });
        }
    }
}
