﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
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

        //HUD MENUS
        public ISprite CreateInGameHud()
        {
            return new InGameHudSprite(hudSpriteSheet);
        }

        public ISprite CreateDungeonHud()
        {
            return new DungeonHudSprite(hudSpriteSheet);
        }

        public ISprite CreateInventoryHud()
        {
            return new InventoryHudSprite(hudSpriteSheet);
        }

        public ISprite CreateMiniMap()
        {
            return new MiniMapSprite(hudSpriteSheet);
        }

        //HUD ICONS
        public ISprite CreateBlackSquareIcon()
        {
            return new BlackSquareIconSprite(hudSpriteSheet);
        }
        public ISprite CreateBlackLongIcon()
        {
            return new BlackLongIconSprite(hudSpriteSheet);
        }
        public ISprite CreateHeartFullIcon()
        {
            return new HeartFullIconSprite(hudSpriteSheet);
        }
        public ISprite CreateHeartHalfIcon()
        {
            return new HeartHalfIconSprite(hudSpriteSheet);
        }
        public ISprite CreateHeartEmptyIcon()
        {
            return new HeartEmptyIconSprite(hudSpriteSheet);
        }
    }
}