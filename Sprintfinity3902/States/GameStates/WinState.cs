using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States.GameStates
{
    public class WinState : IGameState
    {
        private Game1 Game;
        public WinState(Game1 game)
        {
            Game = game;
        }

        public void Update(GameTime gameTime)
        {
            Game.dungeon.Update(gameTime);
            Game.link.Update(gameTime);
            foreach (IHud hud in Game.huds)
            {
                hud.Update(gameTime);
            }
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
            Game.dungeon.UpdateState(IDungeon.GameState.WIN);
        }
    }
}