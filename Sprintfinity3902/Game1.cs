using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.Navigation;
using Sprintfinity3902.SpriteFactories;
using System.Collections.Generic;
using Sprintfinity3902.Entities.Items;

namespace Sprintfinity3902
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;

        public static int ScaleWindow = Global.Var.SCALE;
        public GraphicsDeviceManager Graphics { get { return graphics; } }

        public ILink playerCharacter;
        public Player link;
        public IEntity boomerangItem;
        public IEntity bombItem;
        public IEntity movingSword;
        public IDungeon dungeon;
        public PauseMenu pauseMenu;
        
        public IEntity hitboxSword;
        public List<IEntity> linkProj;
        private IEntity bombExplosion;
        //private IDetector detector;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Window.Title = "The Legend of Zelda";
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Camera.Instance.SetWindowBounds(graphics);

            Graphics.ApplyChanges();
        }

        protected override void Initialize() => base.Initialize();

        protected void Reset()
        {
            KeyboardManager.Instance.Reset();
            
            //basicMap.Setup(this);

            dungeon = new Dungeon.Dungeon(this);

            dungeon.Build();

            playerCharacter = new Player();
            link = (Player)playerCharacter;

            pauseMenu = new PauseMenu(this);

            boomerangItem = new BoomerangItem();
            bombExplosion = new BombExplosionItem(new Vector2(-1000,-1000));
            bombItem = new BombItem(new Vector2(-1000, -1000), (BombExplosionItem) bombExplosion);
            movingSword = new MovingSwordItem(new Vector2(-1000, -1000));
            hitboxSword = new SwordHitboxItem(new Vector2(-1000, -1000));

            linkProj = new List<IEntity>();

            linkProj.Add(boomerangItem);
            linkProj.Add(bombExplosion);
            linkProj.Add(movingSword);
            linkProj.Add(hitboxSword);

            KeyboardManager.Instance.Initialize(link);
            InputMouse.Instance.GiveGame(this);

            KeyboardManager.Instance.RegisterKeyUpCallback(() => { link.CurrentState.Sprite.Animation.Stop(); }, Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right);

            KeyboardManager.Instance.RegisterCommand(new SetDamageLinkCommand(this), Keys.E);
            KeyboardManager.Instance.RegisterCommand(new UseBombCommand((Player)playerCharacter, (BombItem)bombItem), Keys.D1);
            KeyboardManager.Instance.RegisterCommand(new UseBoomerangCommand((Player)playerCharacter, (BoomerangItem)boomerangItem), Keys.D2);
            KeyboardManager.Instance.RegisterCommand(new SetLinkAttackCommand((Player)playerCharacter, (MovingSwordItem)movingSword, (SwordHitboxItem)hitboxSword), Keys.Z, Keys.N);

            KeyboardManager.Instance.RegisterKeyUpCallback(Exit, Keys.Q);
            KeyboardManager.Instance.RegisterKeyUpCallback(Reset, Keys.R);
            KeyboardManager.Instance.RegisterKeyUpCallback(dungeon.NextRoom, Keys.L);
            KeyboardManager.Instance.RegisterKeyUpCallback(dungeon.PreviousRoom, Keys.K);
            KeyboardManager.Instance.RegisterKeyUpCallback(Pause, Keys.P);

            CollisionDetector.Instance.setup(this);
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Camera.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);

            Sound.Sound.Instance.LoadContent(Content);


            Reset();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardManager.Instance.Update(gameTime);
            InputMouse.Instance.Update(gameTime);
            Camera.Instance.Update(gameTime);
            if (pauseMenu.Pause || pauseMenu.Transition)
            {
                pauseMenu.Update(gameTime);
            }
            else
            {
                dungeon.Update(gameTime);

                playerCharacter.Update(gameTime);
                boomerangItem.Update(gameTime);
                bombItem.Update(gameTime);
                movingSword.Update(gameTime);
                hitboxSword.Update(gameTime);
            }

            IRoom currentRoom = dungeon.GetCurrentRoom();

            CollisionDetector.Instance.CheckCollision(currentRoom.enemies, currentRoom.blocks, currentRoom.items, linkProj,currentRoom.enemyProj, currentRoom.garbage);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            dungeon.Draw(SpriteBatch);
            pauseMenu.Draw(SpriteBatch);

            playerCharacter.Draw(SpriteBatch, Color.White);

            boomerangItem.Draw(SpriteBatch, Color.White);
            bombItem.Draw(SpriteBatch, Color.White);
            movingSword.Draw(SpriteBatch, Color.White);

            SpriteBatch.End();

            base.Draw(gameTime);


        }

        public void Pause()
        {
            if (pauseMenu.Transition == false)
            {
                pauseMenu.PauseGame();
            }
        }
    }
}