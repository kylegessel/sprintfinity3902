using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.HudMenu;

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
            Game.dungeon.Update(gameTime);
            Game.link.Update(gameTime);
            Game.hud.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Game.dungeon.Draw(spriteBatch);
            Game.link.Draw(spriteBatch, Color.White);
            Game.hud.Draw(spriteBatch, Color.White);
        }

        public void SetUp()
        {
            if (Game.PreviousState.Equals(Game.PAUSED_TRANSITION) || Game.PreviousState.Equals(Game.FLUTE))
            {
                // This is bad practice for state autanomy but difficult to remove. It's fine for now.
                KeyboardManager.Instance.PopCommandMatrix();
            }
            else if (Game.PreviousState.Equals(Game.INTRO))
            {
                /* We know that the command matrix has one layer here, so we'll push the playing commands
                 * and copy the previous layer; quit and reset commands
                 */
                KeyboardManager.Instance.PushCommandMatrix(copyPreviousLayer: true);
                KeyboardManager.Instance.RegisterKeyUpCallback(PauseGame, Keys.P);
                Game.dungeon.Initialize();
                Game.hud.Initialize();

                /* Player Controls */
                KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveUpCommand(Game.playerCharacter), Keys.W, Keys.Up);
                KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveLeftCommand(Game.playerCharacter), Keys.A, Keys.Left);
                KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveDownCommand(Game.playerCharacter), Keys.S, Keys.Down);
                KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveRightCommand(Game.playerCharacter), Keys.D, Keys.Right);

                KeyboardManager.Instance.RegisterKeyUpCallback(() => {
                    Game.playerCharacter.CurrentState.Sprite.Animation.Stop();
                }, Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            }


        }

        private void PauseGame()
        {
            Game.SetState(Game.PAUSED_TRANSITION);
        }
    }
}