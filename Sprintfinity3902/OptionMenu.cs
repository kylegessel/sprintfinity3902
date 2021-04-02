
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Sprites.Fonts;
using System;

namespace Sprintfinity3902
{
    public class OptionMenu : Sprintfinity3902.Interfaces.IUpdateable, Sprintfinity3902.Interfaces.IDrawable
    {

        private enum animation_state
        {
            GAMEOVER,
            OPTIONS,
            RETURN,
            CLOSEGAME
        }

        public enum options
        {
            RETRY,
            CLOSE
        }

        private animation_state state;

        private Font gameOver;

        private Font retry;
        private Font close;
        private ISprite heartSprite;


        private static int rowOneHeight = 100;
        private static int rowTwoHeight = 300;
        private static int heartDistanceMultiplier = 2 * Global.Var.SCALE;
        private static int TRANSLATE_HEART_Y = 10;

        public options selectedOption;

        private double count;

        private Game1 game;

        public OptionMenu(Game1 _game)
        {
            game = _game;
            gameOver = new Font("Game Over");

            

            retry = new Font("Retry");
            close = new Font("Close");
            heartSprite = HudSpriteFactory.Instance.CreateHeartFullIcon();

        }

        public void Initialize()
        {
            KeyboardManager.Instance.RegisterKeyUpCallback(MoveHeartUp, Keys.Up, Keys.W);

            KeyboardManager.Instance.RegisterKeyUpCallback(MoveHeartDown, Keys.Down, Keys.S);

            KeyboardManager.Instance.RegisterKeyUpCallback(SelectOption, Keys.Enter);
        }

        private void MoveHeartUp() {
            options[] values = (options[])Enum.GetValues(typeof(options));

            int currentPos = Array.IndexOf(values, selectedOption);

            selectedOption = currentPos == 0 ? values[values.Length - 1] : values[currentPos - 1];
        }

        private void MoveHeartDown() {
            options[] values = (options[])Enum.GetValues(typeof(options));

            int currentPos = Array.IndexOf(values, selectedOption);

            selectedOption = currentPos == values.Length - 1 ? values[0] : values[currentPos + 1];
        }

        private void SelectOption() {
            switch (selectedOption)
            {
                case options.RETRY:
                    updateState(animation_state.RETURN);
                    break;
                case options.CLOSE:
                    updateState(animation_state.CLOSEGAME);
                    break;
            }
            //updateState(animation_state.RETURN);
        }

        public void Update(GameTime gameTime)
        {
            count += gameTime.ElapsedGameTime.TotalMilliseconds;
            switch (state) {
                case animation_state.GAMEOVER:
                    if (count > 3000) {
                        updateState(animation_state.OPTIONS);
                    }
                    break;
                case animation_state.OPTIONS:
                    break;
            }

        }

        private void updateState(animation_state a)
        {
            count = 0;

            switch (a) {
                case animation_state.GAMEOVER:
                    break;
                case animation_state.OPTIONS:
                    break;
                case animation_state.RETURN:
                    game.SetState(game.RESET);
                    return;
                case animation_state.CLOSEGAME:
                    game.Exit();
                    return;
            }

            state = a;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Viewport v = spriteBatch.GraphicsDevice.Viewport;

            switch (state) {

                case animation_state.GAMEOVER:
                    gameOver.Draw(spriteBatch, new Vector2((v.Width - gameOver.Width) / 2, (v.Height - gameOver.Height) / 2));
                    break;
                case animation_state.OPTIONS:
                    int leftJustified = (v.Width - retry.Width) / 2;
                    retry.Draw(spriteBatch, new Vector2(leftJustified, rowOneHeight));
                    close.Draw(spriteBatch, new Vector2(leftJustified, rowTwoHeight));
                    switch (selectedOption) {
                        case options.RETRY:
                            heartSprite.Draw(spriteBatch, new Vector2((float)(leftJustified - heartSprite.Animation.CurrentFrame.Width * heartDistanceMultiplier), rowOneHeight + TRANSLATE_HEART_Y), Color.White);
                            break;
                        case options.CLOSE:
                            heartSprite.Draw(spriteBatch, new Vector2((float)(leftJustified - heartSprite.Animation.CurrentFrame.Width * heartDistanceMultiplier), rowTwoHeight + TRANSLATE_HEART_Y), Color.White);
                            break;
                    }
                    break;
            }

            
        }

    }
}
