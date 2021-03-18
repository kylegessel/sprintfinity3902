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
        public List<IEntity> Icons { get; set; }

        public MiniMapHud(Game1 game)
        {
            Game = game;
            Link = Game.link;
            Icons = new List<IEntity>();

            Icons.Add(new MiniMapEntity(new Vector2(16 * Global.Var.SCALE, 8 * Global.Var.SCALE)));

        }

        public void AddIcons()
        {
            //Private method calls to initialize black boxes at start
            //Private method calls to check conditionals and add new icons as needed
        }
    }
}
