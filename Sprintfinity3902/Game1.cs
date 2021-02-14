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

namespace Sprintfinity3902 {
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D texture;
        public IController mouse;
        public Player playerCharacter;
        public IEntity currentEnemy1;
        public IEntity currentEnemy2;
        public IEntity finalBoss;
        public IEntity testAttack;
        public IEntity rupee;
        public IEntity heart;
        public IEntity heartContainer;
        public IEntity compass;
        public IEntity map;

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>(linkSpriteSheet);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);

            playerCharacter = new Player();
            currentEnemy1 = new SkeletonEnemy();
            currentEnemy2 = new HandEnemy();
            finalBoss = new FinalBossEnemy();
            testAttack = new FireAttack(new Vector2(1200, 700));
            rupee = new RupeeItem();
            heart = new HeartItem();
            heartContainer = new HeartContainerItem();
            compass = new CompassItem();
            map = new MapItem();
            

            SetCommands();
            SetListeners();
        }

        protected override void Update(GameTime gameTime)
        {
            InputKeyboard.Instance.Update();
            InputMouse.Instance.Update();

            playerCharacter.Update(gameTime);
            currentEnemy1.Update(gameTime);
            currentEnemy2.Update(gameTime);
            finalBoss.Update(gameTime);
            testAttack.Update(gameTime);
            rupee.Update(gameTime);
            heart.Update(gameTime);
            heartContainer.Update(gameTime);
            compass.Update(gameTime);
            map.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            playerCharacter.Draw(_spriteBatch);
            currentEnemy1.Draw(_spriteBatch);
            currentEnemy2.Draw(_spriteBatch);
            finalBoss.Draw(_spriteBatch);
            testAttack.Draw(_spriteBatch);
            rupee.Draw(_spriteBatch);
            heart.Draw(_spriteBatch);
            heartContainer.Draw(_spriteBatch);
            compass.Draw(_spriteBatch);
            map.Draw(_spriteBatch);

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
