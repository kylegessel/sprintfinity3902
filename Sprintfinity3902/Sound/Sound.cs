using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprintfinity3902.Sound
{
    public class Sound
    {

        public enum Sounds
        {
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

        private static string absolute_path_prefix = "Sounds";

        /*private static Dictionary<Sounds, string> path_maps = new Dictionary<Sounds, string>() {
            {Sounds.Bomb_Apearance_and_Selfdrestruction, "Bomb Apearance and Selfdrestruction" },
            {Sounds.Boss_Defeated, "Boss Defeated" },
            {Sounds.Boss_Roaring, "Boss Roaring" },
            {Sounds.Boss_Zapped, "Boss Zapped" },
            {Sounds.Door_Opened, "Door Opened" },
            {Sounds.defaultt, "Enemy Shrinking" },
            {Sounds.defaultt, "Enemy Zapped" },
            {Sounds.defaultt, "Flames Shot" },
            {Sounds.defaultt, "Health Heart" },
            {Sounds.defaultt, "Item Obtained" },
            {Sounds.defaultt, "Item Received" },
            {Sounds.defaultt, "Key Appearance" },
            {Sounds.defaultt, "Magic Whistle Tune" },
            {Sounds.defaultt, "Magical Boomerang Thrown" },
            {Sounds.defaultt, "Magical" },
            {Sounds.defaultt, "Master Sword Sword Zap" },
            {Sounds.defaultt, "Player Hurt" },
            {Sounds.defaultt, "Power Zap" },
            {Sounds.defaultt, "Rupees Decreasing" },
            {Sounds.defaultt, "Shield Deflecting" },
            {Sounds.defaultt, "Shiney" },
            {Sounds.defaultt, "Sword Zap SFX" },
            {Sounds.defaultt, "The Triforce Reveals Ganon" },
            {Sounds.defaultt, "Triforce Piece Obtained" },
            {Sounds.defaultt, "Two Zap Bolts" },
            {Sounds.defaultt, "Upgraded Magical Boomerang Thrown" },
            {Sounds.defaultt, "Walking on Stairs" }
        };*/

        private static Sound instance;

        public static Sound Instance
        {
            get {
                if (instance == null) {
                    instance = new Sound();
                }
                return instance;
            }
        }

        public Sound()
        {

        }

        public void LoadContent(ContentManager content)
        {

            /*foreach (Sounds sound in Enum.GetValues(typeof(Sounds))) {
                content.Load<SoundEffect>(absolute_path_prefix  + sound.ToString());
            }*/

        }


    }
}