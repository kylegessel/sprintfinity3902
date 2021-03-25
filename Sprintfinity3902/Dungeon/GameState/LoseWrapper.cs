using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprintfinity3902.Dungeon.GameState
{
    public class LoseWrapper : RoomWrapper
    {

        private enum animation_state {
            DELAY,
            BACKGROUND,
            EXPLODE,
            BACKGROUND_ANIMATE,
            OPTIONS
        }

        private animation_state state;

        private double this_count;
        private Color blockColor;
        private Color[] cycleColors;
        private IEntity explode;

        private Game1 game;


        public LoseWrapper(IRoom room, IDungeon dung, Game1 _game) : base(room)
        {
            game = _game;
            state = animation_state.DELAY;
            dungeon = dung;
            
            cycleColors = new Color[] {
                new Color(0, 200, 0, 255),
                new Color(0, 130, 0, 255),
                new Color(0, 60, 0, 255),
                new Color(0, 0, 0, 255)
            };

            updateState(animation_state.DELAY);

            CollisionDetector.Instance.Pause();
        }

        public override void Update(GameTime gameTime)
        {
            int col_pos;
            this_count += gameTime.ElapsedGameTime.TotalMilliseconds;

            switch (state) {
                case animation_state.DELAY:
                    if (this_count > 800) {
                        updateState(animation_state.BACKGROUND);
                    }
                    break;
                case animation_state.BACKGROUND:
                    if (this_count > 2100) {
                        updateState(animation_state.BACKGROUND_ANIMATE);
                    }
                    break;
                case animation_state.BACKGROUND_ANIMATE:

                    /* TODO: Have no way of making player spin */

                    /* Do not remove "extra" parenthesis below -- computer does not know what it's saying */
                    col_pos = Math.Min((int)((this_count / 600) * (cycleColors.Length - 1)), cycleColors.Length - 1);

                    blockColor = cycleColors[col_pos];

                    if (col_pos == cycleColors.Length - 1) {
                        updateState(animation_state.EXPLODE);
                    }

                    break;
                case animation_state.EXPLODE:
                    explode.Update(gameTime);

                    if (this_count > 400) {
                        updateState(animation_state.OPTIONS);
                    }
                    break;
                case animation_state.OPTIONS:
                    /* TODO - Since once the player gets to the options screen
                     there is no HUD, it may make sense for this to be handled in dungeon*/
                    if (this_count > 400) {
                        Wrapup();
                    }
                    break;
            }

        }

        private void updateState(animation_state a) {
            state = a;
            this_count = 0;

            switch (a) {
                case animation_state.DELAY:
                    blockColor = cycleColors[0];
                    break;
                case animation_state.BACKGROUND:
                    SoundManager.Instance.PauseAll();
                    music_id = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Game_Over));
                    SoundManager.Instance.GetSoundEffectInstance(music_id).IsLooped = false;
                    SoundManager.Instance.GetSoundEffectInstance(music_id).Play();
                    game.playerCharacter.DeathSpin(false);
                    break;
                case animation_state.BACKGROUND_ANIMATE:
                    
                    break;
                case animation_state.EXPLODE:
                    game.playerCharacter.DeathSpin(true);
                    explode = new BombExplosionItem(game.playerCharacter.Position);
                    break;
                case animation_state.OPTIONS:
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            switch (state) {
                case animation_state.DELAY:
                    foreach (IBlock entity in blocks) {
                        entity.Draw(spriteBatch, color);
                    }

                    foreach (IEntity entity in garbage) {
                        entity.Draw(spriteBatch, color);
                    }
                    break;
                case animation_state.BACKGROUND_ANIMATE: 
                case animation_state.BACKGROUND:
                    foreach (IBlock entity in blocks) {
                        entity.Draw(spriteBatch, blockColor);
                    }

                    foreach (IEntity entity in garbage) {
                        entity.Draw(spriteBatch, blockColor);
                    }
                    break;
                case animation_state.EXPLODE:
                    explode.Draw(spriteBatch, Color.White);
                    break;
                case animation_state.OPTIONS:

                    break;
            }
        }
    }
}
