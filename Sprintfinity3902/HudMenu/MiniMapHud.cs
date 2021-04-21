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

        private HudInitializer hudInitializer;
        private bool CompassPickup;
        float x, y;

        private IEntity WinLocation;
        private IEntity LinkLocation;

        private Point Location;
        private Point WinPoint;

        //public List<IEntity> Icons { get; private set; }

        public List<IEntity> locationIcons {get; set;}
        public List<IEntity> Map { get; private set; }

        private static MiniMapHud instance;
        public static MiniMapHud Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MiniMapHud();
                }
                return instance;
            }
        }
        public MiniMapHud()
        {
            Icons = new List<IEntity>();
            Map = new List<IEntity>();
            //RoomLocations = dungeon.RoomLocations;
            WorldPoint = new Vector2(0, 0 * Global.Var.SCALE);
            hudInitializer = new HudInitializer(this);
            //MapPickup = false;
            CompassPickup = false;
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public void PickupMap()
        {
            if (CompassPickup) Icons.Remove(WinLocation);
            Icons.Remove(LinkLocation);
            foreach (IEntity room in Map)
            {
                Icons.Add(room);
            }
            if (CompassPickup) Icons.Add(WinLocation);
            Icons.Add(LinkLocation);
        }

        public void PickupCompass()
        {
            CompassPickup = true;
            x = WinPoint.X * ROOM_WIDTH + INSIDE_MAP_X;
            y = WinPoint.Y * ROOM_HEIGHT + INSIDE_MAP_Y;
            WinLocation = new WinLocationIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE));
            Icons.Add(WinLocation);
        }

        /*
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            pushMatrix(Icons.ToArray());
            pushMatrix(WinLocation);
            pushMatrix(LinkLocation);
            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, color);
            }
            

            LinkLocation.Draw(spriteBatch, color);
            if (CompassPickup)
            {
                WinLocation.Draw(spriteBatch, color);
            }
            popMatrix(LinkLocation);
            popMatrix(WinLocation);
            popMatrix(Icons.ToArray());
        }
        */

        public void UpdateHudLinkLoc(Point loc)
        {
            Location = loc;
            LinkLocation.X = (Location.X * ROOM_WIDTH + INSIDE_MAP_X) * Global.Var.SCALE;
            LinkLocation.Y = (Location.Y * ROOM_HEIGHT + INSIDE_MAP_Y) * Global.Var.SCALE;
        }


        public override void Initialize()
        {
            hudInitializer.InitializeMiniMap();
            InitLocationMarkers();
        }

        private void InitLocationMarkers()
        {
            x = Location.X * ROOM_WIDTH + INSIDE_MAP_X;
            y = Location.Y * ROOM_HEIGHT + INSIDE_MAP_Y;

            LinkLocation = new GreenLinkLocationIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE));
            Icons.Add(LinkLocation);
            //WinLocation = new WinLocationIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE));
        }

        public void InitializeRooms(List<Point> roomLocations, Point loc, Point winLoc)
        {
            Location = loc;
            WinPoint = winLoc;

            foreach (Point location in roomLocations)
            {
                x = location.X * ROOM_WIDTH + INSIDE_MAP_X;
                y = location.Y * ROOM_HEIGHT + INSIDE_MAP_Y;
                Map.Add(new MiniRoomIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
            }
        }
    }
}
