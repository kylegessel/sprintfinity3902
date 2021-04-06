using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.States.GameStates
{
    public class PlayingState : IGameState
    {
        private Game1 Game;

        public PlayingState(Game1 game)
        {
            Game = game;
        }

        public void Update(GameTime gameTime)
        {
            foreach (IHud hud in Game.huds)
            {
                hud.Update(gameTime);
            }

            Game.dungeon.Update(gameTime);
            Game.link.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {


            Game.dungeon.Draw(spriteBatch);

            Game.link.Draw(spriteBatch, Color.White);
            foreach (IHud hud in Game.huds)
            {
                hud.Draw(spriteBatch, Color.White);
            }
        }

        public void SetUp()
        {
            if (Game.PreviousState.Equals(Game.PAUSED_TRANSITION))
            {
                KeyboardManager.Instance.PopCommandMatrix();
            }
            else if (Game.PreviousState.Equals(Game.INTRO))
            {
                KeyboardManager.Instance.PopCommandMatrix();
                KeyboardManager.Instance.PushCommandMatrix(copyPreviousLayer: true);
                KeyboardManager.Instance.RegisterKeyUpCallback(PauseGame, Keys.P);
                Game.dungeon.Initialize();
                Game.playerCharacter.Initialize();
                foreach (IHud hud in Game.huds)
                {
                    hud.Initialize();
                }
            }
        }

        private void PauseGame()
        {
            Game.SetState(Game.PAUSED_TRANSITION);
        }
    }
}