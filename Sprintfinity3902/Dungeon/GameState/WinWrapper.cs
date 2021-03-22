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


        private double this_count;

        public WinWrapper(IRoom room, IDungeon dung) : base(room) {
            this_count = 0;
            dungeon = dung;

            SoundManager.Instance.PauseAll();
            music_id = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Triforce_Piece_Obtained));
            SoundManager.Instance.GetSoundEffectInstance(music_id).IsLooped = false;
            SoundManager.Instance.GetSoundEffectInstance(music_id).Play();

        }

        public override void Update(GameTime gameTime)
        {
            this_count = gameTime.TotalGameTime.TotalSeconds;
            //base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (this_count > 10) {
                wrapup();
            }

            foreach (IBlock entity in blocks) {
                if (blocks[1].Equals(entity)) {
                    entity.Draw(spriteBatch, Color.Blue);
                    continue;
                }
                entity.Draw(spriteBatch, Color.Green);
            }
                
            foreach (IEntity entity in enemies.Values) { }
            //entity.Draw(spriteBatch, color);

            foreach (IEntity entity in items) { }
            //entity.Draw(spriteBatch, color);

            foreach (IEntity entity in garbage) {
                entity.Draw(spriteBatch, Color.Brown);
            }

            foreach (IEntity entity in enemyProj) { }
                //entity.Draw(spriteBatch, color);
        }

    }
}
