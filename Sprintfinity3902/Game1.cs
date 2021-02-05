using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Sprintfinity3902.Sprites;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Controllers;

namespace Sprintfinity3902
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D texture;
        public IController keyboard;
        public IController mouse;
        public Player playerCharacter;
        public ISprite currentEnemy;
        public ISprite currentEnemy2;
        public ISprite currentEnemy3;
        public ISprite currentEnemy4;
        public ISprite currentEnemy5;
        public ISprite currentEnemy6;
        public ISprite currentEnemy7;
        public ISprite currentEnemy8;

        private const string linkSpriteSheet = "Zelda_Link_and_Items_Transparent";


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            keyboard = new InputKeyboard();
            mouse = new InputMouse(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>(linkSpriteSheet);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);

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
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard.Update();
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

            playerCharacter.playerSprite.Draw(_spriteBatch, gameTime);
            currentEnemy.Draw(_spriteBatch, gameTime);
            currentEnemy2.Draw(_spriteBatch, gameTime);
            currentEnemy3.Draw(_spriteBatch, gameTime);
            currentEnemy4.Draw(_spriteBatch, gameTime);
            currentEnemy5.Draw(_spriteBatch, gameTime);
            currentEnemy6.Draw(_spriteBatch, gameTime);
            currentEnemy7.Draw(_spriteBatch, gameTime);
            currentEnemy8.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetCommands()
        {
            InputKeyboard input = (InputKeyboard)keyboard;
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                input.RegisterCommand(key, new DoNothingCommand(this));
            }
            input.RegisterCommand(Keys.W, new SetLinkUpCommand(playerCharacter));
            input.RegisterCommand(Keys.A, new SetLinkLeftCommand(playerCharacter));
            input.RegisterCommand(Keys.S, new SetLinkDownCommand(playerCharacter));
            input.RegisterCommand(Keys.D, new SetLinkRightCommand(playerCharacter));
        }
    }
}
