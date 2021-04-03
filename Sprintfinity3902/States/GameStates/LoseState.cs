using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.States.GameStates
{
    public class LoseState : IGameState
    {
        private Game1 Game;
        public LoseState(Game1 game)
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
            Game.dungeon.UpdateState(IDungeon.GameState.LOSE);
        }
    }
}