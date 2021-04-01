using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States.GameStates
{
    public class PausedState : IGameState
    {
        private Game1 Game;
        public PausedState(Game1 game)
        {
            Game = game;
        }

        public void Update(GameTime gameTime)
        {

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
            KeyboardManager.Instance.PushCommandMatrix(copyPreviousLayer: true);
            KeyboardManager.Instance.RegisterKeyUpCallback(((InventoryHud)Game.huds[2]).MoveSelectorLeft, Keys.A, Keys.Left);
            KeyboardManager.Instance.RegisterKeyUpCallback(((InventoryHud)Game.huds[2]).MoveSelectorRight, Keys.D, Keys.Right);
        }
    }
}