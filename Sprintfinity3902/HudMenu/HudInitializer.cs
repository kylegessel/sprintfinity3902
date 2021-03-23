using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.HudMenu
{
    public class HudInitializer
    {
        private IHud Hud;
        private float x; private float y;
        private int i; private int j;

        public HudInitializer(IHud hud)
        {
            Hud = hud;
        }

        public void InitializeInGameHud()
        {
            //HUD BACKGROUND
            Hud.Icons.Add(new InGameHudEntity(new Vector2(0, 0)));

            //HEALTH
            y = 32;
            for (i = 0; i < 2; i++)
            {
                x = 176;
                for (j = 0; j < 8; j++)
                {
                    Hud.Icons.Add(new BlackSquareIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    x = x + 8;
                }
                y = y + 8;
            }

            //ITEMS
            y = 16;
            for (i = 0; i < 4; i++)
            {
                x = 96;
                for (j = 0; j < 3; j++)
                {
                    if (j == 0 && i != 1)
                    {
                        Hud.Icons.Add(new LetterX(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    else if (j == 1 && i != 1)
                    {
                        Hud.Icons.Add(new Number0(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    else
                    {
                        Hud.Icons.Add(new BlackSquareIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    x = x + 8;
                }
                y = y + 8;
            }

            //B BUTTON
            Hud.Icons.Add(new BlackLongIcon(new Vector2(128 * Global.Var.SCALE, 24 * Global.Var.SCALE)));
            //A BUTTON
            Hud.Icons.Add(new BlackLongIcon(new Vector2(152 * Global.Var.SCALE, 24 * Global.Var.SCALE)));
            //SWORD
            Hud.Icons.Add(new SwordIcon(new Vector2(152 * Global.Var.SCALE, 24 * Global.Var.SCALE)));
        }
    }
}
