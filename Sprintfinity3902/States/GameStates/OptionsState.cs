using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.States.GameStates
{
    public class OptionsState : IGameState
    {
        private Game1 Game;
        public OptionsState(Game1 game)
        {
            Game = game;
        }

        public void Update(GameTime gameTime)
        {
            Game.optionMenu.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Game.optionMenu.Draw(spriteBatch);
        }

        public void SetUp()
        {
            KeyboardManager.Instance.PushCommandMatrix();
            Game.optionMenu.Initialize();
        }
    }
}