using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Ardrey.Sprint0.Sprites;
using Ardrey.Sprint0.Commands;
using Sprintfinity3902.Interfaces;

namespace Ardrey.Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D texture;
        public Vector2 startingLocation = new Vector2(363, 195);
        public ISprite sprite;
        public IController keyboard;
        public IController mouse;
        public Player playerCharacter;

        private const string linkSpriteSheet = "NES - Link - Transparent";

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

            playerCharacter = new Player(this, texture);

            SetCommands();
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard.Update();
            mouse.Update();

            playerCharacter.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            playerCharacter.playerSprite.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetSprite(ISprite spriteSet)
        {
            sprite = spriteSet;
        }

        public void SetCommands()
        {
            InputKeyboard input = (InputKeyboard) keyboard;
            foreach(Keys key in Enum.GetValues(typeof(Keys)))
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
