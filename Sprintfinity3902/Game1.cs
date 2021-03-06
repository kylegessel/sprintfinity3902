using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Dungeon;
using Sprintfinity3902.Navigation;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Collision;

namespace Sprintfinity3902 {
    public class Game1 : Game {

        private GraphicsDeviceManager graphics;
        private SpriteBatch SpriteBatch;

        public static int ScaleWindow = Global.Var.SCALE;
        public GraphicsDeviceManager Graphics { get { return graphics; } }


        public ILink playerCharacter;
        private Player link;
        private IEntity boomerangItem;
        private IEntity bombItem;
        private IEntity movingSword;
        private IDungeon dungeon;
        private bool pause;
        private bool done;
        private int count;
        //private IDetector detector;


        //private IMap basicMap; 

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Window.Title = "The Legend of Zelda";
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            pause = false;
            done = true;
            count = 0;

            Camera.Instance.SetWindowBounds(graphics);
            dungeon = new Dungeon.Dungeon();
            //basicMap = new DefaultMap();

            Graphics.ApplyChanges();
        }

        protected override void Initialize() {
            base.Initialize();
        }

        protected void Reset() {
            KeyboardManager.Instance.Reset();

            
            //basicMap.Setup(this);

            dungeon.Build();

            playerCharacter = new Player();
            link = (Player)playerCharacter;

            boomerangItem = new BoomerangItem();
            bombItem = new BombItem(new Vector2(-1000, -1000));
            movingSword = new MovingSwordItem(new Vector2(-1000, -1000));

            KeyboardManager.Instance.Initialize(link);

            KeyboardManager.Instance.RegisterKeyUpCallback(() => { link.CurrentState.Sprite.Animation.Stop(); }, Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right);

            KeyboardManager.Instance.RegisterCommand(new SetDamageLinkCommand(this), Keys.E);
            KeyboardManager.Instance.RegisterCommand(new UseBombCommand((Player)playerCharacter, (BombItem)bombItem), Keys.D1);
            KeyboardManager.Instance.RegisterCommand(new UseBoomerangCommand((Player)playerCharacter, (BoomerangItem)boomerangItem), Keys.D2);
            KeyboardManager.Instance.RegisterCommand(new SetLinkAttackCommand((Player)playerCharacter, (MovingSwordItem)movingSword), Keys.Z, Keys.N);

            KeyboardManager.Instance.RegisterKeyUpCallback(Exit, Keys.Q);
            KeyboardManager.Instance.RegisterKeyUpCallback(Reset, Keys.R);
            KeyboardManager.Instance.RegisterKeyUpCallback(dungeon.NextRoom, Keys.L);
            KeyboardManager.Instance.RegisterKeyUpCallback(dungeon.PreviousRoom, Keys.K);
            KeyboardManager.Instance.RegisterKeyUpCallback(Pause, Keys.P);

            CollisionDetector.Instance.setup(this);
        }

        protected override void LoadContent() {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Camera.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);

            Reset();
        }

        protected override void Update(GameTime gameTime) {
            KeyboardManager.Instance.Update(gameTime);
            InputMouse.Instance.Update(gameTime);
            Camera.Instance.Update(gameTime);


            if (pause == false)
            {
                if (done == false)
                {
                    dungeon.GetCurrentRoom().ChangePosition(pause);

                    if(count == 176 * Global.Var.SCALE)
                    {
                        done = true;
                    }
                    count = count + 2*Global.Var.SCALE;
                }
                else
                {
                    dungeon.Update(gameTime);

                    playerCharacter.Update(gameTime);
                    boomerangItem.Update(gameTime);
                    bombItem.Update(gameTime);
                    movingSword.Update(gameTime);
                }
            }
            else if (pause == true)
            {
                if(done == false)
                {
                    dungeon.GetCurrentRoom().ChangePosition(pause);

                    if (count == 176 * Global.Var.SCALE)
                    {
                        done = true;
                    }
                    count = count + 2*Global.Var.SCALE;
                }
            }
            //basicMap.Update(gameTime);

            IRoom currentRoom = dungeon.GetCurrentRoom();

            CollisionDetector.Instance.CheckCollision(currentRoom.items);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            //This will be used for the Sprint 3 and is not needed for Sprint 2
            //Camera.Instance.Draw(SpriteBatch);
            dungeon.Draw(SpriteBatch);
            //basicMap.Draw(SpriteBatch);

            playerCharacter.Draw(SpriteBatch, Color.White);

            boomerangItem.Draw(SpriteBatch);
            bombItem.Draw(SpriteBatch);
            movingSword.Draw(SpriteBatch);

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        protected void Pause()
        {
            pause = !pause;
            dungeon.GetCurrentRoom().SetPauseCount();
            count = 0;
            done = false;

            if (pause)
            {
                KeyboardManager.Instance.RegisterCommand(new DoNothingCommand(this), Keys.W, Keys.Up, Keys.S, Keys.Down, Keys.A, Keys.Left, Keys.D, Keys.Right);
                KeyboardManager.Instance.RegisterCommand(new DoNothingCommand(this), Keys.E, Keys.D1, Keys.D2, Keys.Z, Keys.N);

                KeyboardManager.Instance.RemoveKeyUpCallback(Keys.L, Keys.K);

            }
            else if (pause == false)
            {
                KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveUpCommand((Player)playerCharacter), Keys.W, Keys.Up);
                KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveLeftCommand((Player)playerCharacter), Keys.A, Keys.Left);
                KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveDownCommand((Player)playerCharacter), Keys.S, Keys.Down);
                KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveRightCommand((Player)playerCharacter), Keys.D, Keys.Right);
                KeyboardManager.Instance.RegisterCommand(new SetDamageLinkCommand(this), Keys.E);
                KeyboardManager.Instance.RegisterCommand(new UseBombCommand((Player)playerCharacter, (BombItem)bombItem), Keys.D1);
                KeyboardManager.Instance.RegisterCommand(new UseBoomerangCommand((Player)playerCharacter, (BoomerangItem)boomerangItem), Keys.D2);
                KeyboardManager.Instance.RegisterCommand(new SetLinkAttackCommand((Player)playerCharacter, (MovingSwordItem)movingSword), Keys.Z, Keys.N);

                KeyboardManager.Instance.RegisterKeyUpCallback(dungeon.NextRoom, Keys.L);
                KeyboardManager.Instance.RegisterKeyUpCallback(dungeon.PreviousRoom, Keys.K);
            }
        }
    }
}