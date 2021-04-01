using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            foreach (IHud hud in Game.huds)
            {
                hud.Draw(spriteBatch, Color.White);
            }

            Game.dungeon.Draw(spriteBatch);

            Game.link.Draw(spriteBatch, Color.White);
        }

        public void SetUp()
        {
            if (Game.PreviousState.Equals(Game.PLAYING))
            {
                KeyboardManager.Instance.PushCommandMatrix();
                KeyboardManager.Instance.RegisterKeyUpCallback(PauseGame, Keys.P);
            }
            else if (Game.PreviousState.Equals(Game.PAUSED))
            {
                KeyboardManager.Instance.PopCommandMatrix();
            }
        }

        private void PauseGame()
        {
            Game.SetState(Game.PAUSED_TRANSITION);
        }
    }
}