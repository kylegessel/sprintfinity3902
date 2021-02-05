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
        public Enemy currentEnemy;
        public Item currentItem;

        private const string linkSpriteSheet = "Zelda - Link and Items - Transparent";

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
            ItemSpriteFactory.Instance.LoadAllTextures(Content);

            playerCharacter = new Player(texture);
            currentEnemy = new Enemy();
            currentEnemy.getEnemy();

            currentItem = new Item();
            currentItem.getItem();

            SetCommands();
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard.Update();
            mouse.Update();

            playerCharacter.Update(gameTime);
            currentEnemy.CurrentEnemySprite.Update(gameTime);
            currentItem.CurrentItemSprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            playerCharacter.playerSprite.Draw(_spriteBatch, gameTime);
            currentEnemy.CurrentEnemySprite.Draw(_spriteBatch, gameTime);
            currentItem.CurrentItemSprite.Draw(_spriteBatch, gameTime);

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
