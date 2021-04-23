using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
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
            HudMenu.DungeonHud.Instance.Update(gameTime);
            HudMenu.InGameHud.Instance.Update(gameTime);
            HudMenu.InventoryHud.Instance.Update(gameTime);
            HudMenu.MiniMapHud.Instance.Update(gameTime);
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
            KeyboardManager.Instance.PushCommandMatrix(copyPreviousLayer: true);
            KeyboardManager.Instance.RegisterKeyUpCallback(() => {
                KeyboardManager.Instance.PopCommandMatrix();
                Game.SetState(Game.PAUSED_TRANSITION);
            }, Keys.P);
            KeyboardManager.Instance.RegisterKeyUpCallback(HudMenu.InventoryHud.Instance.MoveSelectorLeft, Keys.A, Keys.Left);
            KeyboardManager.Instance.RegisterKeyUpCallback(HudMenu.InventoryHud.Instance.MoveSelectorRight, Keys.D, Keys.Right);
        }
    }
}