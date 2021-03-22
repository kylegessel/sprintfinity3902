using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Dungeon.GameState
{
    public class WinWrapper : RoomWrapper
    {

        private IDungeon dungeon;
        private string music_id;

        private double count;

        public WinWrapper(IRoom room, IDungeon dung) : base(room) {
            count = 0;
            dungeon = dung;
            SoundManager.Instance.PauseAll();

            music_id = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Triforce_Piece_Obtained));
            SoundManager.Instance.GetSoundEffectInstance(music_id).IsLooped = false;
            SoundManager.Instance.GetSoundEffectInstance(music_id).Play();

        }

        public override void Update(GameTime gameTime)
        {
            count += gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            base.Draw(spriteBatch, Color.DarkOrchid);

            if (count > 10) {
                wrapup(); 
            }
            
        }

        private void wrapup() {
            SoundManager.Instance.DestroySoundEffectInstance(music_id);

            SoundManager.Instance.PlayAll();
            dungeon.CurrentRoom = CurrentState;
        }

    }
}
