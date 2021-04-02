using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private HudInitializer hudInitializer;
        private List<Point> RoomLocations;
        public List<IEntity> Icons { get; private set; }

        public DungeonHud(Game1 game, List<Point> roomLocations)
        {
            Game = game;
            Link = Game.playerCharacter;
            Icons = new List<IEntity>();
            hudInitializer = new HudInitializer(this);
            RoomLocations = roomLocations;

            Initialize();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Initialize()
        {
            //Icons.Add(new DungeonHudEntity(new Vector2(0, -88 * Global.Var.SCALE)));
            hudInitializer.InitializeDungeonHud(RoomLocations);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, color);
            }
        }
    }
}
