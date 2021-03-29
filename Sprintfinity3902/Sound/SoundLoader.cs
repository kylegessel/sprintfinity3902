using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace Sprintfinity3902.Sound
{
    public class SoundLoader
    {

        public enum Sounds
        {
            Dungeon,
            Game_Over,
            Intro,
            LOZ_Arrow_Boomerang,
            LOZ_Bomb_Blow,
            LOZ_Bomb_Drop,
            LOZ_Boss_Hit,
            LOZ_Boss_Scream1,
            LOZ_Boss_Scream2,
            LOZ_Boss_Scream3,
            LOZ_Candle,
            LOZ_Door_Unlock,
            LOZ_Enemy_Die,
            LOZ_Enemy_Hit,
            LOZ_Fanfare,
            LOZ_Get_Heart,
            LOZ_Get_Item,
            LOZ_Get_Rupee,
            LOZ_Key_Appear,
            LOZ_Link_Die,
            LOZ_Link_Hurt,
            LOZ_LowHealth,
            LOZ_MagicalRod,
            LOZ_Recorder,
            LOZ_Refill_Loop,
            LOZ_Secret,
            LOZ_Shield,
            LOZ_Shore,
            LOZ_Stairs,
            LOZ_Sword_Combined,
            LOZ_Sword_Shoot,
            LOZ_Sword_Slash,
            LOZ_Text,
            LOZ_Text_Slow,
            Triforce,
            Triforce_Piece_Obtained,

        };

        private static string absolute_path_prefix = "Sounds/";

        private static Dictionary<Sounds, SoundEffect> sound_map = new Dictionary<Sounds, SoundEffect>();

        private static SoundLoader instance;

        public static SoundLoader Instance
        {
            get {
                if (instance == null) {
                    instance = new SoundLoader();
                }
                return instance;
            }
        }

        public SoundLoader()
        {

        }

        public void LoadContent(ContentManager content)
        {

            foreach (Sounds sound in Enum.GetValues(typeof(Sounds))) {
                SoundEffect sefft = content.Load<SoundEffect>(absolute_path_prefix  + sound.ToString());
                sound_map.Add(sound, sefft);
            }

        }

        public SoundEffect GetSound(Sounds sound) {
            return sound_map[sound];
        }


    }
}