using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.States.GameStates
{
    public class Paused_TransitionState : IGameState
    {
        private Game1 Game;
        public Paused_TransitionState(Game1 game)
        {
            Game = game;
        }

        public void Update(GameTime gameTime)
        {
            Game.pauseMenu.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            HudMenu.DungeonHud.Instance.Draw(spriteBatch, Color.White);
            HudMenu.InGameHud.Instance.Draw(spriteBatch, Color.White);
            HudMenu.InventoryHud.Instance.Draw(spriteBatch, Color.White);
            HudMenu.MiniMapHud.Instance.Draw(spriteBatch, Color.White);
            Game.dungeon.Draw(spriteBatch);
            Game.link.Draw(spriteBatch, Color.White);

        }

        public void SetUp()
        {
            if (Game.PreviousState.Equals(Game.PLAYING))
            {
                KeyboardManager.Instance.PushCommandMatrix();
                KeyboardManager.Instance.RegisterKeyUpCallback(Game.Exit, Global.Var.QUIT_KEY);
                // Workaround since ResetGame is a private member of Game.RESET
                KeyboardManager.Instance.RegisterKeyUpCallback(() => Game.SetState(Game.RESET), Global.Var.RESET_KEY);
                // Should not be able to use this command until the menu is truly paused
                // KeyboardManager.Instance.RegisterKeyUpCallback(PauseGame, Keys.P);
            }
            else if (Game.PreviousState.Equals(Game.PAUSED))
            {
                // None
            }
        }

        private void PauseGame()
        {
            Game.SetState(Game.PAUSED_TRANSITION);
        }
    }
}