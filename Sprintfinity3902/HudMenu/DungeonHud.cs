﻿using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public class DungeonHud : IHud
    {
        private Game1 Game;
        private IPlayer Link;
        public List<IEntity> Icons { get; set; }

        public DungeonHud(Game1 game)
        {
            Game = game;
            Link = Game.playerCharacter;
            Icons = new List<IEntity>();

            Initialize();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Initialize()
        {
            Icons.Add(new DungeonHudEntity(new Vector2(0, -88 * Global.Var.SCALE)));
        }
    }
}
