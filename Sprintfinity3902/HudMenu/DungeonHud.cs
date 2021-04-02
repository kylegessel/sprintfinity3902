using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public class DungeonHud : AbstractHud
    {
        private Game1 Game;
        private IPlayer Link;

        public DungeonHud(Game1 game)
        {
            Game = game;
            Link = Game.playerCharacter;
            Icons = new List<IEntity>();
            WorldPoint = new Vector2(0, -88 * Global.Var.SCALE);

            Initialize();
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Initialize()
        {
            Icons.Add(new DungeonHudEntity(new Vector2(0, 0 * Global.Var.SCALE)));
        }

    }
}
