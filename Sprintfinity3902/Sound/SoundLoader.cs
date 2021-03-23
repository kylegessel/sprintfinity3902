using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprintfinity3902.Sound
{
    public class SoundLoader
    {

        public enum Sounds
        {
            Death_Mountain,
            Ending,
            Whistle,
            Game_Over,
            Triforce,
            Secret,
            Dungeon,
            Item,
            Overworld,
            Intro,
            Bomb_Apearance_and_Selfdrestruction,
            Boss_Defeated,
            Boss_Roaring,
            Boss_Zapped,
            Door_Opened,
            Enemy_Shrinking,
            Enemy_Zapped,
            Flames_Shot,
            Health_Heart,
            Item_Obtained,
            Item_Received,
            Key_Appearance,
            Magic_Whistle_Tune,
            Magical_Boomerang_Thrown,
            Magical,
            Master_Sword_Sword_Zap,
            Player_Hurt,
            Power_Zap,
            Rupees_Decreasing,
            Shield_Deflecting,
            Shiney,
            Sword_Zap_SFX,
            The_Triforce_Reveals_Ganon,
            Triforce_Piece_Obtained,
            Two_Zap_Bolts,
            Upgraded_Magical_Boomerang_Thrown,
            Walking_on_Stairs
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