using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sound
{
    public class SoundManager
    {

        private static Dictionary<string, SoundEffectInstance> soundEffectInstances;

        private static SoundManager instance;

        public static SoundManager Instance
        {
            get {
                if (instance == null) {
                    instance = new SoundManager();
                }
                return instance;
            }
        }

        public SoundManager() {
            soundEffectInstances = new Dictionary<string, SoundEffectInstance>();
        }

        public string RegisterSoundEffectInst(SoundEffectInstance se) {
            Random r = new Random();
            String ID;

            se.Volume = 0.02f;

            do { ID = r.Next(65, 91) + r.Next(65, 91) + r.Next(65, 91) + r.Next(1000).ToString(); }
            while (soundEffectInstances.ContainsKey(ID));

            soundEffectInstances.Add(ID, se);

            return ID;
        }

        private void setSoundEffectInstanceAttributes(SoundEffectInstance se, float vol, bool looped) {
            
            se.Volume = vol;
            se.IsLooped = looped;
        }

        public string RegisterSoundEffectInst(SoundEffect se)
        {
            SoundEffectInstance sei = se.CreateInstance();

            setSoundEffectInstanceAttributes(sei, 0.02f, true);
            return RegisterSoundEffectInst(sei);
        }

        public string RegisterSoundEffectInst(SoundEffect se, float vol)
        {
            SoundEffectInstance sei = se.CreateInstance();

            setSoundEffectInstanceAttributes(sei, vol, true);
            return RegisterSoundEffectInst(sei);
        }

        public string RegisterSoundEffectInst(SoundEffect se, float vol, bool looped)
        {
            SoundEffectInstance sei = se.CreateInstance();

            setSoundEffectInstanceAttributes(sei, vol, looped);
            return RegisterSoundEffectInst(sei);
        }

        public SoundEffectInstance GetSoundEffectInstance(string ID) {
            if (soundEffectInstances.ContainsKey(ID)) {
                return soundEffectInstances[ID];
            }

            throw new KeyNotFoundException();
        }
    }
}
