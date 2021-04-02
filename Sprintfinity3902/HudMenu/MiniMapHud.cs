﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public class MiniMapHud : IHud
    {
        private Game1 Game;
        private IPlayer Link;
        private HudInitializer hudInitializer;
        private List<Point> RoomLocations;

        public List<IEntity> Icons { get; private set; }

        public MiniMapHud(Game1 game, List<Point> roomLocations)
        {
            Game = game;
            Link = Game.playerCharacter;
            Icons = new List<IEntity>();
            RoomLocations = roomLocations;
            hudInitializer = new HudInitializer(this);

            Initialize();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, color);
            }
        }

        public void Initialize()
        {
            hudInitializer.InitializeMiniMap(RoomLocations);
        }
    }
}
