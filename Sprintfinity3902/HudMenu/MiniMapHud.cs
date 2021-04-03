using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public class MiniMapHud : AbstractHud
    {
        private Game1 Game;
        private IPlayer Link;
        private HudInitializer hudInitializer;
        private List<Point> RoomLocations;
        private bool MapPickup;

        //public List<IEntity> Icons { get; private set; }
        public List<IEntity> Map { get; private set; }

        public MiniMapHud(Game1 game, List<Point> roomLocations)
        {
            Game = game;
            Link = Game.playerCharacter;
            Icons = new List<IEntity>();
            Map = new List<IEntity>();
            RoomLocations = roomLocations;
            WorldPoint = new Vector2(0, 0 * Global.Var.SCALE);
            hudInitializer = new HudInitializer(this);
            MapPickup = false;

            Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (!MapPickup && Link.itemcount[IItem.ITEMS.MAP] > 0)
            {
                foreach (IEntity room in Map)
                {
                    Icons.Add(room);
                }
                MapPickup = true;
            }
        }

        /*
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, color);
            }
        }
        */

        public override void Initialize()
        {
            hudInitializer.InitializeMiniMap(RoomLocations, Map);
        }
    }
}
