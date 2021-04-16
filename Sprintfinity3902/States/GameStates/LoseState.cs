using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.HudMenu;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.States.GameStates
{
    public class LoseState : IGameState
    {
        private Game1 game;
        public LoseState(Game1 _game)
        {
            this.game = _game;
        }

        public void Update(GameTime gameTime)
        {
            game.dungeon.Update(gameTime);
            game.link.Update(gameTime);
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
            game.dungeon.UpdateState(IDungeon.GameState.LOSE);
        }
    }
}