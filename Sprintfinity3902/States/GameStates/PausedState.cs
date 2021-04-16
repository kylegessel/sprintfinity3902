using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.States.GameStates
{
    public class PausedState : IGameState
    {
        private Game1 game;
        public PausedState(Game1 _game)
        {
            game = _game;
        }

        public void Update(GameTime gameTime)
        {
            game.hud.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            game.hud.Draw(spriteBatch, Color.White);

            game.dungeon.Draw(spriteBatch);

            game.link.Draw(spriteBatch, Color.White);
        }

        public void SetUp()
        {
            KeyboardManager.Instance.PushCommandMatrix(copyPreviousLayer: true);
            KeyboardManager.Instance.RegisterKeyUpCallback(() => {
                KeyboardManager.Instance.PopCommandMatrix();
                game.SetState(game.PAUSED_TRANSITION);
            }, Keys.P);
            KeyboardManager.Instance.RegisterKeyUpCallback(((InventoryHud)((DungeonHud)game.hud).Inventory).MoveSelectorLeft, Keys.A, Keys.Left);
            KeyboardManager.Instance.RegisterKeyUpCallback(((InventoryHud)((DungeonHud)game.hud).Inventory).MoveSelectorRight, Keys.D, Keys.Right);
        }
    }
}