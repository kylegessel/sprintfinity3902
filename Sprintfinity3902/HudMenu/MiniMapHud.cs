using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{

    

    public class MiniMapHud : AbstractHud
    {
        private const int ROOM_WIDTH = 8;
        private const int ROOM_HEIGHT = 4;
        private const int INSIDE_MAP_X = 16;
        private const int INSIDE_MAP_Y = 16;

        private Game1 Game;
        private IPlayer Link;
        private HudInitializer hudInitializer;
        private List<Point> RoomLocations;
        private IDungeon Dungeon;
        private bool MapPickup;
        private bool CompassPickup;
        float x, y;

        private IEntity WinLocation;
        private IEntity LinkLocation;

        private Point Location;

        //public List<IEntity> Icons { get; private set; }

        public List<IEntity> locationIcons {get; set;}
        public List<IEntity> Map { get; private set; }

        public MiniMapHud(Game1 game, IDungeon dungeon)
        {
            Game = game;
            Link = Game.playerCharacter;
            Icons = new List<IEntity>();
            Map = new List<IEntity>();
            RoomLocations = dungeon.RoomLocations;
            Dungeon = dungeon;
            WorldPoint = new Vector2(0, 0 * Global.Var.SCALE);
            hudInitializer = new HudInitializer(this);
            MapPickup = false;
            CompassPickup = false;

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

            if (!CompassPickup && Link.itemcount[IItem.ITEMS.COMPASS] > 0)
            {
                CompassPickup = true;
            }

            UpdateHudLinkLoc();
        }

        
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, color);
            }


            LinkLocation.Draw(spriteBatch, color);
            if (CompassPickup)
            {
                WinLocation.Draw(spriteBatch, color);
            }
        }

        public void UpdateHudLinkLoc()
        {

            Location = Dungeon.CurrentRoom.RoomPos;
            LinkLocation.X = (Location.X * ROOM_WIDTH + INSIDE_MAP_X) * Global.Var.SCALE;
            LinkLocation.Y = (Location.Y * ROOM_HEIGHT + INSIDE_MAP_Y) * Global.Var.SCALE;
        }


        public override void Initialize()
        {
            hudInitializer.InitializeMiniMap(RoomLocations, Map);
            InitLocationMarkers();
        }

        private void InitLocationMarkers()
        {
            Location = Dungeon.WinLocation;
            x = Location.X * ROOM_WIDTH + INSIDE_MAP_X;
            y = Location.Y * ROOM_HEIGHT + INSIDE_MAP_Y;

            //link icon is temporarily built in final room, update manages his location
            LinkLocation = new GreenLinkLocationIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE));
            WinLocation = new WinLocationIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE));


        }
    }
}
