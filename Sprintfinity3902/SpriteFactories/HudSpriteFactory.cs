using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.SpriteFactories
{
    public class HudSpriteFactory
    {
        private Texture2D hudSpriteSheet;

        private static HudSpriteFactory instance;

        private static string HUD_FILE_NAME = "Zelda_HudElements_Transparent";

        public static HudSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HudSpriteFactory();
                }
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            hudSpriteSheet = content.Load<Texture2D>(HUD_FILE_NAME);
        }

    }
}
