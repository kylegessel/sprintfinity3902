using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Dungeon.GameState
{
    public class LoseWrapper : RoomWrapper
    {

        private double this_count;
        private Color blockColor;
        private static Color[] cycleColors = { Color.Orange, Color.IndianRed, Color.Green };
        public LoseWrapper(IRoom room, IDungeon dung) : base(room)
        {
            blockColor = Color.White;
            this_count = 0;
            dungeon = dung;

            SoundManager.Instance.PauseAll();
            music_id = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Game_Over));
            SoundManager.Instance.GetSoundEffectInstance(music_id).IsLooped = false;
            SoundManager.Instance.GetSoundEffectInstance(music_id).Play();
        }

        public override void Update(GameTime gameTime)
        {
            this_count = gameTime.TotalGameTime.TotalSeconds;

            blockColor = cycleColors[(int)(gameTime.TotalGameTime.TotalMilliseconds % cycleColors.Length)];


        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (this_count > 10) {
                wrapup();
            }

            foreach (IBlock entity in blocks) {
                entity.Draw(spriteBatch, blockColor);
            }

            foreach (IEntity entity in enemies.Values) {
                entity.Draw(spriteBatch, Color.White);
            }

            foreach (IEntity entity in garbage) {
                entity.Draw(spriteBatch, Color.White);
            }

        }
    }
}
