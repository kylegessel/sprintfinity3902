using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.Navigation;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902
{
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int ScaleWindow = 7;
        public GraphicsDeviceManager Graphics { get { return _graphics; } }

        public Texture2D texture;
        public IController mouse;
        public ILink playerCharacter;
        public Player link;
        public Color linkColor;
        public IEntity currentEnemy1;
        public IEntity currentEnemy2;
        public IEntity currentEnemy3;
        public IEntity boomerangItem;
        public IEntity bombItem;
        public IEntity finalBoss;
        public IEntity testAttack;
        public IEntity rupee;
        public IEntity heart;
        public IEntity heartContainer;
        public IEntity compass;
        public IEntity map;
        public IEntity key;
        public IEntity bomb;
        public IEntity triforce;
        public IEntity bow;
        public IEntity clock;
        public IEntity oldMan;
        public IEntity fire;
        public IEntity movingSword;
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

        protected void Reset() {
            InputKeyboard.Instance.UnregisterListeners();
            InputKeyboard.Instance.UnregisterCommands();

            gelEnemy = new GelEnemy();
            playerCharacter = new Player();
            currentEnemy1 = new SkeletonEnemy();
            currentEnemy2 = new HandEnemy();
            currentEnemy3 = new BlueBatEnemy();
            boomerangItem = new BoomerangItem();
            finalBoss = new FinalBossEnemy();
            testAttack = new FireAttack(finalBoss.Position);
            bombItem = new BombItem(new Vector2(-1000, -1000));
            movingSword = new MovingSwordItem(new Vector2(-1000, -1000));
            rupee = new RupeeItem();
            heart = new HeartItem();
            heartContainer = new HeartContainerItem();
            compass = new CompassItem();
            map = new MapItem();
            key = new KeyItem();
            triforce = new TriforceItem();
            bow = new BowItem();
            clock = new ClockItem();
            oldMan = new OldManNPC();
            fire = new Fire();

            SetCommands();
            SetListeners();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            camera.LoadAllTextures(Content);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);

            Reset();
            
        }

        protected override void Update(GameTime gameTime)
        {
            InputKeyboard.Instance.Update();
            InputMouse.Instance.Update();

            gelEnemy.Update(gameTime);

            playerCharacter.Update(gameTime);
            currentEnemy1.Update(gameTime);
            currentEnemy2.Update(gameTime);
            currentEnemy3.Update(gameTime);
            boomerangItem.Update(gameTime);
            bombItem.Update(gameTime);
            finalBoss.Update(gameTime);
            testAttack.Update(gameTime);
            rupee.Update(gameTime);
            heart.Update(gameTime);
            heartContainer.Update(gameTime);
            compass.Update(gameTime);
            map.Update(gameTime);
            key.Update(gameTime);
            triforce.Update(gameTime);
            bow.Update(gameTime);
            clock.Update(gameTime);
            oldMan.Update(gameTime);
            fire.Update(gameTime);
            movingSword.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            //camera.Draw(_spriteBatch);

            playerCharacter.Draw(_spriteBatch, Color.White);
            gelEnemy.Draw(_spriteBatch);
            currentEnemy1.Draw(_spriteBatch);
            currentEnemy2.Draw(_spriteBatch);
            currentEnemy3.Draw(_spriteBatch);
            boomerangItem.Draw(_spriteBatch);
            bombItem.Draw(_spriteBatch);
            testAttack.Draw(_spriteBatch);
            finalBoss.Draw(_spriteBatch);
            testAttack.Draw(_spriteBatch);
            rupee.Draw(_spriteBatch);
            heart.Draw(_spriteBatch);
            heartContainer.Draw(_spriteBatch);
            compass.Draw(_spriteBatch);
            map.Draw(_spriteBatch);
            key.Draw(_spriteBatch);
            triforce.Draw(_spriteBatch);
            bow.Draw(_spriteBatch);
            clock.Draw(_spriteBatch);
            oldMan.Draw(_spriteBatch);
            fire.Draw(_spriteBatch);
            movingSword.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetCommands()
        {
            
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                InputKeyboard.Instance.RegisterCommand(key, new DoNothingCommand(this));
            }

            link = (Player)playerCharacter;

            InputKeyboard.Instance.RegisterCommand(new SetPlayerMoveCommand(link, link.facingUp), Keys.W, Keys.Up);
            InputKeyboard.Instance.RegisterCommand(new SetPlayerMoveCommand(link, link.facingLeft), Keys.A, Keys.Left);
            InputKeyboard.Instance.RegisterCommand(new SetPlayerMoveCommand(link, link.facingDown), Keys.S, Keys.Down);
            InputKeyboard.Instance.RegisterCommand(new SetPlayerMoveCommand(link, link.facingRight), Keys.D, Keys.Right);
            InputKeyboard.Instance.RegisterCommand(new SetDamageLinkCommand(this), Keys.E);
            InputKeyboard.Instance.RegisterCommand(new UseBombCommand(link, (BombItem)bombItem), Keys.D1);
            InputKeyboard.Instance.RegisterCommand(new UseBoomerangCommand(link, (BoomerangItem)boomerangItem), Keys.D2);
            InputKeyboard.Instance.RegisterCommand(new SetLinkAttackCommand(link, (MovingSwordItem)movingSword), Keys.Z, Keys.N);
        }

        public void SetListeners()
        {
            InputKeyboard.Instance.RegisterKeyUpCallback(() => { link.CurrentState.Sprite.Animation.Stop(); }, Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.E);
            InputKeyboard.Instance.RegisterKeyUpCallback(() => { Exit(); }, Keys.Q);
            InputKeyboard.Instance.RegisterKeyUpCallback(() => { Reset(); }, Keys.R);
        }
    }
}
