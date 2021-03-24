using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprintfinity3902.Dungeon.GameState
{
    public class WinWrapper : RoomWrapper
    {

        private enum animation_state
        {
            FLASH,
            BACKGROUND_ANIMATE,
            OPTIONS
        }

        private animation_state state;

        private double this_count;
        private Color blockColor;
        private Color[] cycleColors;
        private double animation_color_duration;

        private Vector2 pos_left_pane, pos_right_pane;
        private float delta_x_percent;

        public WinWrapper(IRoom room, IDungeon dung, ILink link) : base(room)
        {

            dungeon = dung;
            animation_color_duration = 2700.0;
            cycleColors = new Color[] {
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255),
                new Color(100, 100, 100, 255),
                new Color(255, 255, 255, 255)
            };

            updateState(animation_state.FLASH);

            CollisionDetector.Instance.Pause();
        }

        public override void Update(GameTime gameTime)
        {
            int col_pos;
            this_count += gameTime.ElapsedGameTime.TotalMilliseconds;

            switch (state) {
                case animation_state.FLASH:

                    /* TODO: Have no way of making player spin */

                    /* Do not remove "extra" parenthesis below -- computer does not know what it's saying */
                    col_pos = Math.Min((int)((this_count / 4000) * (cycleColors.Length - 1)), cycleColors.Length - 1);

                    blockColor = cycleColors[col_pos];

                    if (col_pos == cycleColors.Length - 1) {
                        updateState(animation_state.BACKGROUND_ANIMATE);
                    }
                    break;
                case animation_state.BACKGROUND_ANIMATE:

                    delta_x_percent = (float)(this_count / 2000.0);

                    if (this_count > 2000) {
                        updateState(animation_state.OPTIONS);
                    }

                    break;
                case animation_state.OPTIONS:
                    /* TODO - Since once the player gets to the options screen
                     there is no HUD, it may make sense for this to be handled in dungeon*/
                    if (this_count > 400) {
                        wrapup();
                    }
                    break;
            }

        }

        private void updateState(animation_state a)
        {
            state = a;
            this_count = 0;

            switch (a) {
                case animation_state.FLASH:
                    SoundManager.Instance.PauseAll();
                    music_id = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Triforce_Piece_Obtained));
                    SoundManager.Instance.GetSoundEffectInstance(music_id).IsLooped = false;
                    SoundManager.Instance.GetSoundEffectInstance(music_id).Play();
                    break;
                case animation_state.BACKGROUND_ANIMATE:
                    delta_x_percent = 0;

                    break;
                case animation_state.OPTIONS:
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            switch (state) {
                case animation_state.FLASH:
                    foreach (IBlock entity in blocks) {
                        entity.Draw(spriteBatch, blockColor);
                    }

                    foreach (IEntity entity in garbage) {
                        entity.Draw(spriteBatch, blockColor);
                    }
                    break;
                case animation_state.BACKGROUND_ANIMATE:
                    foreach (IBlock entity in blocks) {
                        entity.Draw(spriteBatch, blockColor);
                    }

                    foreach (IEntity entity in garbage) {
                        entity.Draw(spriteBatch, blockColor);
                    }


                    Debug.WriteLine(-spriteBatch.GraphicsDevice.Viewport.Width / 2 + (spriteBatch.GraphicsDevice.Viewport.Width / 2) * delta_x_percent);

                    Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);

                    texture.SetData(new[] { Color.Black });

                    spriteBatch.Draw(texture, new Vector2(spriteBatch.GraphicsDevice.Viewport.Width/2, spriteBatch.GraphicsDevice.Viewport.Height / 2), Color.Black);
                    spriteBatch.Draw(texture, new Vector2(10,10), Color.DarkGreen);

                    break;
                case animation_state.OPTIONS:
                    break;
            }
        }
    }
}
