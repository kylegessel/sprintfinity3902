using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;

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
            Game.dungeon.UpdateState(IDungeon.GameState.WIN);
        }
    }
}