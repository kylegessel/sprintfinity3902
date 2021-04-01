using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States.GameStates
{
    public class IntroState : IGameState
    {
        private Game1 Game;

        private ISprite titleScreen;
        private string introMusicInstanceID;

        public IntroState(Game1 game)
        {
            Game = game;

            titleScreen = BlockSpriteFactory.Instance.CreateTitleScreen();

        }

        public void Update(GameTime gameTime)
        {
            titleScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            titleScreen.Draw(spriteBatch, new Vector2(0, 16 * Global.Var.SCALE), Color.White);
        }

        public void SetUp()
        {
            introMusicInstanceID = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Intro), 0.02f, true);
            SoundManager.Instance.GetSoundEffectInstance(introMusicInstanceID).Play();

            KeyboardManager.Instance.PushCommandMatrix(copyPreviousLayer: true);
            KeyboardManager.Instance.RegisterKeyUpCallback(StartPlaying, Keys.Enter);
        }

        private void StartPlaying()
        {
            SoundManager.Instance.GetSoundEffectInstance(introMusicInstanceID).Stop();
            Game.SetState(Game.PLAYING);
        }
    }
}
