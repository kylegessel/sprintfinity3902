using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sound
{
    public class SoundManager
    {

        private static int A_ASCII = 65;
        private static int Z_ASCII = 90;
        private static int NINE_HUNDRED_NINETY_NINE = 999;
        private static int ONE = 1;


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

        private SoundManager() {
            Reset();
        }

        public void Reset() {
            if (soundEffectInstances != null) { PauseAll(); }
            soundEffectInstances = new Dictionary<string, SoundEffectInstance>();
        }

        public string RegisterSoundEffectInst(SoundEffectInstance se) {
            Random r = new Random();
            String ID;

            se.Volume = Global.Var.VOLUME;

            do { ID = r.Next(A_ASCII, Z_ASCII + ONE) + r.Next(A_ASCII, Z_ASCII + ONE) + r.Next(A_ASCII, Z_ASCII + ONE) + r.Next(ONE + NINE_HUNDRED_NINETY_NINE).ToString(); }
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

            setSoundEffectInstanceAttributes(sei, Global.Var.VOLUME, true);
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

        public void PauseAll() {
            foreach (SoundEffectInstance sei in soundEffectInstances.Values) {
                sei.Stop();
            }
        }

        public void PlayAll()
        {
            foreach (SoundEffectInstance sei in soundEffectInstances.Values) {
                sei.Play();
            }
        }

        public void DestroySoundEffectInstance(string id) {

            if (soundEffectInstances.ContainsKey(id)) {
                soundEffectInstances[id].Stop();
                soundEffectInstances[id].Dispose();
                soundEffectInstances.Remove(id);
                return;
            }

            throw new KeyNotFoundException();
        }
    }
}
