using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.Sound;
using System.Collections.Generic;

namespace Sprintfinity3902.States.GameStates
{
    public class SoftResetState : IGameState
    {
        private Game1 Game;
        public SoftResetState(Game1 game)
        {
            Game = game;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        public void SetUp()
        {
            KeyboardManager.Instance.Reset();
            SoundManager.Instance.Reset();
            CollisionDetector.Instance.Reset();

            Global.Var.floor++;

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

            Game.dungeonHud = new DungeonHud(Game, Game.dungeon);
            Game.miniMapHud = new MiniMapHud(Game, Game.dungeon);

            KeyboardManager.Instance.RegisterKeyUpCallback(Game.Exit, Keys.Q);
            KeyboardManager.Instance.RegisterKeyUpCallback(ResetGame, Keys.R);

            BuildStates();

            Game.SetState(Game.INTRO);

            //Game.playerCharacter.GiveItemsBack(currHealth, maxHealth, savedInventory);
        }

        private void ResetGame()
        {
            Game.SetState(Game.SOFT_RESET);
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