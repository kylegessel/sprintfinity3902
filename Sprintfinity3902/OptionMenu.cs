
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprintfinity3902
{
    public class OptionMenu : Sprintfinity3902.Interfaces.IUpdateable, Sprintfinity3902.Interfaces.IDrawable
    {
        private string music_id;
        public OptionMenu(Game1 game)
        {
            
        }


        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Debug.WriteLine("Waiting to be implemented");
        }

        public void Start() {
            SoundManager.Instance.PauseAll();
            music_id = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.Ending));
            SoundManager.Instance.GetSoundEffectInstance(music_id).IsLooped = false;
            SoundManager.Instance.GetSoundEffectInstance(music_id).Play();
        }

    }
}
