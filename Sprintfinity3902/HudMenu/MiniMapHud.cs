﻿using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public class MiniMapHud : AbstractHud
    {
        private Game1 Game;
        private IPlayer Link;
        private HudInitializer hudInitializer;

        public MiniMapHud(Game1 game)
        {
            Game = game;
            Link = Game.playerCharacter;
            Icons = new List<IEntity>();
            WorldPoint = new Vector2(0, 0 * Global.Var.SCALE);
            hudInitializer = new HudInitializer(this);

            Initialize();
        }

        public override void Update(GameTime gameTime)
        {

        }

        /*Method called on health change or item picked up from player*/
        public override void UpdateSelf()
        {
            // Do nothing
        }


        public override void Initialize()
        {
            hudInitializer.InitializeMiniMap();
        }
    }
}
