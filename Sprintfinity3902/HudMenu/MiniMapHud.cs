using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.HudMenu
{
    public class MiniMapHud : IHud
    {
        private Game1 Game;
        private Player Link;
        private float x; private float y;
        private int i; private int j;
        public List<IEntity> Icons { get; set; }

        public MiniMapHud(Game1 game)
        {
            Game = game;
            Link = Game.link;
            Icons = new List<IEntity>();

            AddIcons();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void AddIcons()
        {
            Initialize();
            //Private method calls to initialize black boxes at start
            //Private method calls to check conditionals and add new icons as needed
        }

        private void Initialize()
        {
            Icons.Add(new MiniMapEntity(new Vector2(16 * Global.Var.SCALE, 8 * Global.Var.SCALE)));
            Icons.Add(new Number1(new Vector2(64 * Global.Var.SCALE, 8 * Global.Var.SCALE)));

            y = 16;
            for (i = 0; i < 4; i++)
            {
                x = 16;
                for (j = 0; j < 8; j++)
                {
                    Icons.Add(new BlackSquareIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    x = x + 8;
                }
                y = y + 8;
            }
        }
    }
}
