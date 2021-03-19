using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.HudMenu
{
    public class InGameHud : IHud
    {
        private Game1 Game;
        private Player Link;
        public List<IEntity> Icons { get; set; }

        public InGameHud(Game1 game)
        {
            Game = game;
            Link = Game.link;
            Icons = new List<IEntity>();


            Icons.Add(new InGameHudEntity(new Vector2(0, 0)));
            AddIcons();

        }

        public void AddIcons()
        {
            Initialize();
            //Private method calls to initialize black boxes at start
            //Private method calls to check conditionals and add new icons as needed
        }

        private void Initialize()
        {
            float x; float y;
            int i; int j;

            //HEALTH
            y = 32;
            for (i = 0; i < 2; i++)
            {
                x = 176;
                for (j = 0; j < 8; j++)
                {
                    Icons.Add(new BlackSquareIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    x = x + 8;
                }
                y = y + 8;
            }

            //ITEMS
            y = 16;
            for(i = 0; i < 4; i++)
            {
                x = 96;
                for(j = 0; j < 3; j++)
                {
                    Icons.Add(new BlackSquareIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    x = x + 8;
                }
                y = y + 8;
            }

            //B BUTTON
            Icons.Add(new BlackLongIcon(new Vector2(128 * Global.Var.SCALE, 24 * Global.Var.SCALE)));
            //A BUTTON
            Icons.Add(new BlackLongIcon(new Vector2(152 * Global.Var.SCALE, 24 * Global.Var.SCALE)));

        }
    }
}
