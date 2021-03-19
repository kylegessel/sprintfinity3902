using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.HudMenu
{
    public class DungeonHud : IHud
    {
        private Game1 Game;
        private Player Link;
        public List<IEntity> Icons { get; set; }

        public DungeonHud(Game1 game)
        {
            Game = game;
            Link = Game.link;
            Icons = new List<IEntity>();

            Icons.Add(new DungeonHudEntity(new Vector2(0, -88 * Global.Var.SCALE)));

        }

        public void Update(GameTime gameTime)
        {

        }

        public void AddIcons()
        {
            //Private method calls to initialize black boxes at start
            //Private method calls to check conditionals and add new icons as needed
        }
    }
}
