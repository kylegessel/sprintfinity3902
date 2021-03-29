using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public class MiniMapHud : AbstractHud
    {
        private Game1 Game;
        private Player Link;
        private HudInitializer hudInitializer;


        public MiniMapHud(Game1 game)
        {
            Game = game;
            Link = Game.link;
            Icons = new List<IEntity>();
            WorldPoint = new Vector2(0, -176 * Global.Var.SCALE);
            hudInitializer = new HudInitializer(this);

            Initialize();
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, color);
            }
        }

        public override void Initialize()
        {
            hudInitializer.InitializeMiniMap();
        }
    }
}
