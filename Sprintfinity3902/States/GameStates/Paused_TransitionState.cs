using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.States.GameStates
{
    public class Paused_TransitionState : IGameState
    {
        private Game1 game;
        public Paused_TransitionState(Game1 _game)
        {
            game = _game;
        }

        public void Update(GameTime gameTime)
        {
            game.pauseMenu.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            game.hud.Draw(spriteBatch, Color.White);
            game.dungeon.Draw(spriteBatch);
            game.link.Draw(spriteBatch, Color.White);

        }

        public void SetUp()
        {
            if (game.PreviousState.Equals(game.PLAYING))
            {
                KeyboardManager.Instance.PushCommandMatrix();
                KeyboardManager.Instance.RegisterKeyUpCallback(game.Exit, Keys.Q);
                // Workaround since ResetGame is a private member of Game.RESET
                KeyboardManager.Instance.RegisterKeyUpCallback(() => game.SetState(game.RESET), Keys.R);
                // Should not be able to use this command until the menu is truly paused
                // KeyboardManager.Instance.RegisterKeyUpCallback(PauseGame, Keys.P);
            }
            else if (game.PreviousState.Equals(game.PAUSED))
            {
                // None
            }
        }

        private void PauseGame()
        {
            game.SetState(game.PAUSED_TRANSITION);
        }
    }
}