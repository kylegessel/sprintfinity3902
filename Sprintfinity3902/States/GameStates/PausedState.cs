using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;

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
            Game.dungeonHud.Update(gameTime);
            Game.in_gameHud.Update(gameTime);
            Game.inventoryHud.Update(gameTime);
            Game.miniMapHud.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Game.dungeonHud.Draw(spriteBatch, Color.White);
            Game.in_gameHud.Draw(spriteBatch, Color.White);
            Game.inventoryHud.Draw(spriteBatch, Color.White);
            Game.miniMapHud.Draw(spriteBatch, Color.White);

            Game.dungeon.Draw(spriteBatch);

            Game.link.Draw(spriteBatch, Color.White);
        }

        public void SetUp()
        {
            KeyboardManager.Instance.PushCommandMatrix(copyPreviousLayer: true);
            KeyboardManager.Instance.RegisterKeyUpCallback(((InventoryHud)Game.inventoryHud).MoveSelectorLeft, Keys.A, Keys.Left);
            KeyboardManager.Instance.RegisterKeyUpCallback(((InventoryHud)Game.inventoryHud).MoveSelectorRight, Keys.D, Keys.Right);
        }
    }
}