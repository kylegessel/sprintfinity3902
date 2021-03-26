using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
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

        public List<IEntity> Icons { get; set; }

        public MiniMapHud(Game1 game)
        {
            Game = game;
            Link = Game.playerCharacter;
            Icons = new List<IEntity>();
            hudInitializer = new HudInitializer(this);

            Initialize();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Initialize()
        {
            hudInitializer.InitializeMiniMap();
        }
    }
}
