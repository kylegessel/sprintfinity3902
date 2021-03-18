using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.HudMenu
{
    public class InventoryHud : IHud
    {
        private Game1 Game;
        private Player Link;
        public List<IEntity> Icons { get; set; }

        public InventoryHud(Game1 game)
        {
            Game = game;
            Link = Game.link;
            Icons = new List<IEntity>();


            Icons.Add(new InventoryHudEntity(new Vector2(0, -176 * Global.Var.SCALE)));

        }
    }
}
