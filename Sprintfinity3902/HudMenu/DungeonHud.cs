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
        private bool MapPickup;
        public List<IEntity> Icons { get; private set; }
        public List<IEntity> Map { get; private set; }
        public List<int> AlreadyAdded { get; private set; }
        public IDungeon dungeon { get; protected set; }

        public DungeonHud(Game1 game, List<Point> roomLocations)
        {
            Game = game;
            Link = Game.playerCharacter;
            MapPickup = false;
            Icons = new List<IEntity>();
            Map = new List<IEntity>();
            AlreadyAdded = new List<int>();
            hudInitializer = new HudInitializer(this);
            RoomLocations = roomLocations;

            Initialize();
        }

        public void Initialize()
        {
            //Icons.Add(new DungeonHudEntity(new Vector2(0, -88 * Global.Var.SCALE)));
            hudInitializer.InitializeDungeonHud(RoomLocations, Map);
            /*Get x and y values from Room1 csv file*/
            //Map.Add(new DoorRightRoom(new Vector2(136 * Global.Var.SCALE, -32 * Global.Var.SCALE)));
        }

        public void Update(GameTime gameTime)
        {
            /*check to see if the current room is in the list of added rooms (use ID).
             If its not in the list add to the list and to the Map*/
            //if (! AlreadyAdded.Contains(dungeon.CurrentRoom.Id))
            if (!MapPickup && Link.itemcount[IItem.ITEMS.MAP] > 0) 
            {
                foreach (IEntity room in Map)
                {
                    Icons.Add(room);
                }
                MapPickup = true;
            }
        }

        

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            foreach (IEntity icon in Icons)
            {
                icon.Draw(spriteBatch, color);
            }
        }
    }
}
