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

        public string RegisterSoundEffectInst(SoundEffect se)
        {
            SoundEffectInstance sei = se.CreateInstance();
            sei.Volume = 0.02f;
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
