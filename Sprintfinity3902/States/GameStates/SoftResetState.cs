using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.Sound;
using Sprintfinity3902.SpriteFactories;
using System.Collections.Generic;

namespace Sprintfinity3902.States.GameStates
{
    public class SoftResetState : IGameState
    {
        private Game1 Game;
        private ISprite loadingScreen;
        public SoftResetState(Game1 game)
        {
            Game = game;
            loadingScreen = BlockSpriteFactory.Instance.CreateTitleScreen();

        }

        public void Update(GameTime gameTime)
        {
            loadingScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            loadingScreen.Draw(spriteBatch, new Vector2(0, 16 * Global.Var.SCALE), Color.White);
        }

        public void SetUp()
        {
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Stairs).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            KeyboardManager.Instance.Reset();
            SoundManager.Instance.Reset();
            CollisionDetector.Instance.Reset();

            Global.Var.floor++;

            BlockSpriteFactory.Instance.UpdateFloorSheet();

            IPlayer savedLink = Game.playerCharacter;

            int currHealth = savedLink.LinkHealth;
            int maxHealth = savedLink.MaxHealth;
            Dictionary<IItem.ITEMS, int> savedInventory = savedLink.itemcount;

            Game.link = new Player(Game);
            Game.playerCharacter = (IPlayer)Game.link;

            Game.playerCharacter.GiveItemsBack(currHealth, maxHealth, savedInventory);

            Game.dungeon = new Dungeon.Dungeon(Game);

            Game.pauseMenu = new PauseMenu(Game);
            Game.optionMenu = new OptionMenu(Game);

            KeyboardManager.Instance.RegisterKeyUpCallback(Game.Exit, Keys.Q);
            KeyboardManager.Instance.RegisterKeyUpCallback(ResetGame, Keys.R);

            BuildStates();
            Game.SetState(Game.PLAYING);
        }

        private void ResetGame()
        {
            Game.SetState(Game.RESET);
        }

        private void BuildStates()
        {
            Game.INTRO = new IntroState(Game);
            Game.PLAYING = new PlayingState(Game);
            Game.PAUSED = new PausedState(Game);
            Game.PAUSED_TRANSITION = new Paused_TransitionState(Game);
            Game.FLUTE = new FluteState(Game);
            Game.WIN = new WinState(Game);
            Game.LOSE = new LoseState(Game);
            Game.OPTIONS = new OptionsState(Game);
        }
    }
}