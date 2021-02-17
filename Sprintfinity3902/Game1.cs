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
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprintfinity3902
{
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int ScaleWindow = 7;
        public GraphicsDeviceManager Graphics { get { return _graphics; } }

        private List<IEntity> cyclableBlocks;
        private List<IEntity> cyclableItems;
        private List<IEntity> cyclableCharacters;

        public ILink playerCharacter;
        public Player link;
        private IEntity boomerangItem;
        private IEntity bombItem;
        private IEntity movingSword;
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

            cyclableBlocks = new List<IEntity>();
            cyclableItems = new List<IEntity>();
            cyclableCharacters = new List<IEntity>();

            // cyclableBlocks.Add all blocks

            cyclableItems.Add(new RupeeItem(new Vector2(500, 300)));
            cyclableItems.Add(new HeartItem(new Vector2(500, 300)));
            cyclableItems.Add(new CompassItem(new Vector2(500, 300)));
            cyclableItems.Add(new MapItem(new Vector2(500, 300)));
            cyclableItems.Add(new KeyItem(new Vector2(500, 300)));
            cyclableItems.Add(new HeartContainerItem(new Vector2(500, 300)));
            cyclableItems.Add(new ClockItem(new Vector2(500, 300)));
            cyclableItems.Add(new BowItem(new Vector2(500, 300)));
            cyclableItems.Add(new TriforceItem(new Vector2(500, 300)));


            cyclableCharacters.Add(new SkeletonEnemy());
            cyclableCharacters.Add(new GelEnemy());
            cyclableCharacters.Add(new HandEnemy());
            cyclableCharacters.Add(new BlueBatEnemy());
            cyclableCharacters.Add(new SpikeEnemy());
            cyclableCharacters.Add(new GoriyaEnemy());
            cyclableCharacters.Add(new FinalBossEnemy());
            cyclableCharacters.Add(new OldManNPC());
            cyclableCharacters.Add(new Fire());

            cyclableBlocks.Add(new RegularBlock());
            cyclableBlocks.Add(new Face1Block());
            cyclableBlocks.Add(new Face2Block());
            playerCharacter = new Player();

            boomerangItem = new BoomerangItem();
            bombItem = new BombItem(new Vector2(-1000, -1000));
            movingSword = new MovingSwordItem(new Vector2(-1000, -1000));

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
            BlockSpriteFactory.Instance.LoadAllTextures(Content);

            Reset();
            
        }

        protected override void Update(GameTime gameTime)
        {
            InputKeyboard.Instance.Update();
            InputMouse.Instance.Update();

            cyclableBlocks[0].Update(gameTime);
            cyclableCharacters[0].Update(gameTime);
            cyclableItems[0].Update(gameTime);

            playerCharacter.Update(gameTime);
            boomerangItem.Update(gameTime);
            bombItem.Update(gameTime);
            movingSword.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            //camera.Draw(_spriteBatch);

            cyclableBlocks[0].Draw(_spriteBatch);
            cyclableItems[0].Draw(_spriteBatch);
            cyclableCharacters[0].Draw(_spriteBatch);

            playerCharacter.Draw(_spriteBatch, Color.White);

            boomerangItem.Draw(_spriteBatch);
            bombItem.Draw(_spriteBatch);
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

            // InputKeyboard.Instance.RegisterCommand(new ShiftListCommand<IEntity>(cyclableBlocks, -1), Keys.T);
            // InputKeyboard.Instance.RegisterCommand(new ShiftListCommand<IEntity>(ref cyclableBlocks, 1), Keys.Y);
        }

        public void SetListeners()
        {
            InputKeyboard.Instance.RegisterKeyUpCallback(() => { link.CurrentState.Sprite.Animation.Stop(); }, Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.E);
            InputKeyboard.Instance.RegisterKeyUpCallback(() => { Exit(); }, Keys.Q);
            InputKeyboard.Instance.RegisterKeyUpCallback(() => { Reset(); }, Keys.R);


            InputKeyboard.Instance.RegisterKeyUpCallback(() => {

                //Debug.WriteLine(cyclableBlocks[0].ToString());

                List<IEntity> holder = new List<IEntity>();
                int cycleBy = 1;

                for (int i = 0; i < cycleBy % cyclableBlocks.Count; i++) {
                    holder.Add(cyclableBlocks[i]);
                }

                cyclableBlocks.RemoveRange(0, cycleBy % cyclableBlocks.Count);

                cyclableBlocks.AddRange(holder);

            }, Keys.Y);

            InputKeyboard.Instance.RegisterKeyUpCallback(() => {

                Debug.WriteLine(cyclableBlocks[0].ToString());

                List<IEntity> holder = new List<IEntity>();
                int cycleBy = -1;

                for (int i = (cycleBy % cyclableBlocks.Count) + cyclableBlocks.Count; i < cyclableBlocks.Count; i++) {
                    holder.Add(cyclableBlocks[i]);
                }

                cyclableBlocks.RemoveRange((cycleBy % cyclableBlocks.Count) + cyclableBlocks.Count, Math.Abs(cycleBy % cyclableBlocks.Count));

                holder.AddRange(cyclableBlocks);

                cyclableBlocks = holder;


            }, Keys.T);

            InputKeyboard.Instance.RegisterKeyUpCallback(() => {

                //Debug.WriteLine(cyclableBlocks[0].ToString());

                List<IEntity> holder = new List<IEntity>();
                int cycleBy = 1;

                for (int i = 0; i < cycleBy % cyclableItems.Count; i++) {
                    holder.Add(cyclableItems[i]);
                }

                cyclableItems.RemoveRange(0, cycleBy % cyclableItems.Count);

                cyclableItems.AddRange(holder);

            }, Keys.I);

            InputKeyboard.Instance.RegisterKeyUpCallback(() => {

                Debug.WriteLine(cyclableItems[0].ToString());

                List<IEntity> holder = new List<IEntity>();
                int cycleBy = -1;

                for (int i = (cycleBy % cyclableItems.Count) + cyclableItems.Count; i < cyclableItems.Count; i++) {
                    holder.Add(cyclableItems[i]);
                }

                cyclableItems.RemoveRange((cycleBy % cyclableItems.Count) + cyclableItems.Count, Math.Abs(cycleBy % cyclableItems.Count));

                holder.AddRange(cyclableItems);

                cyclableItems = holder;


            }, Keys.U);

            InputKeyboard.Instance.RegisterKeyUpCallback(() => {

                //Debug.WriteLine(cyclableBlocks[0].ToString());

                List<IEntity> holder = new List<IEntity>();
                int cycleBy = 1;

                for (int i = 0; i < cycleBy % cyclableCharacters.Count; i++) {
                    holder.Add(cyclableCharacters[i]);
                }

                cyclableCharacters.RemoveRange(0, cycleBy % cyclableCharacters.Count);

                cyclableCharacters.AddRange(holder);

            }, Keys.P);

            InputKeyboard.Instance.RegisterKeyUpCallback(() => {

                Debug.WriteLine(cyclableCharacters[0].ToString());

                List<IEntity> holder = new List<IEntity>();
                int cycleBy = -1;

                for (int i = (cycleBy % cyclableCharacters.Count) + cyclableCharacters.Count; i < cyclableCharacters.Count; i++) {
                    holder.Add(cyclableCharacters[i]);
                }

                cyclableCharacters.RemoveRange((cycleBy % cyclableCharacters.Count) + cyclableCharacters.Count, Math.Abs(cycleBy % cyclableCharacters.Count));

                holder.AddRange(cyclableCharacters);

                cyclableCharacters = holder;


            }, Keys.O);

        }
    }
}
