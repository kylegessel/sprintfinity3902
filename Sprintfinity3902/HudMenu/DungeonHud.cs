using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sprintfinity3902.HudMenu
{
    public class DungeonHud : AbstractHud
    {
        private const int DUNGEON_INSIDE_MAP_X = 516;
        private const int DUNGEON_INSIDE_MAP_Y = -316;
        private const int MAP_ICON_X = 48;
        private const int MAP_ICON_Y= -64;
        private const int COMPASS_ICON_X = 44;
        private const int COMPASS_ICON_Y = -24;
        private const int BLOCK_SIZE = 8;

        private Game1 Game;
        private IPlayer Link;
        private HudInitializer hudInitializer;
        private List<Point> RoomLocations;
        private bool MapPickup;
        private bool CompassPickup;
        private IEntity LinkBlock;
        private IRoom CurrentRoom;
        //public List<IEntity> Icons { get; private set; }
        public List<IEntity> Map { get; private set; }
        public List<int> AlreadyInMap { get; set; }
        public IDungeon Dungeon { get; protected set; }

        public DungeonHud(Game1 game, IDungeon dungeon)
        {
            Game = game;
            Link = Game.playerCharacter;
            MapPickup = false;
            CompassPickup = false;
            Icons = new List<IEntity>();
            Map = new List<IEntity>();
            AlreadyInMap = new List<int>();
            hudInitializer = new HudInitializer(this);
            Dungeon = dungeon;
            RoomLocations = dungeon.RoomLocations;
            CurrentRoom = dungeon.CurrentRoom;
            WorldPoint = new Vector2(0, 0);

            Initialize();
        }

        public override void Initialize()
        {
            hudInitializer.InitializeDungeonHud(RoomLocations);
        }

        public override void Update(GameTime gameTime)
        {
            if (!MapPickup && Link.itemcount[IItem.ITEMS.MAP] > 0)
            {
                CreateInitialHudDungeon();
                
            }
            if (!CompassPickup && Link.itemcount[IItem.ITEMS.COMPASS] > 0)
            {
                CreateCompassIcon();
            }
            if (CurrentRoom.Id != Dungeon.CurrentRoom.Id)
            {
                UpdateHudRooms();
                UpdateHudLinkLoc();
                CurrentRoom = Dungeon.CurrentRoom;
            }
        }

        public void CreateInitialHudDungeon()
        {
            int x = (Dungeon.CurrentRoom.RoomPos.X * BLOCK_SIZE + 2) * Global.Var.SCALE;
            int y = (Dungeon.CurrentRoom.RoomPos.Y * BLOCK_SIZE + 2) * Global.Var.SCALE;
            LinkBlock = new YellowLinkBlock(new Vector2(x + DUNGEON_INSIDE_MAP_X, y + DUNGEON_INSIDE_MAP_Y));
            foreach (IEntity room in Map)
            {
                Icons.Add(room);
            }
            Icons.Add(LinkBlock);
            Icons.Add(new MapIcon(new Vector2(MAP_ICON_X * Global.Var.SCALE, MAP_ICON_Y * Global.Var.SCALE)));
            MapPickup = true;
        }

        private void CreateCompassIcon()
        {
            Icons.Add(new CompassIcon(new Vector2(COMPASS_ICON_X * Global.Var.SCALE, COMPASS_ICON_Y * Global.Var.SCALE)));
            CompassPickup = true;
        }

        public void UpdateHudRooms()
        {
            /*Add every room Link is in into the Map List*/
            if (!AlreadyInMap.Contains(Dungeon.CurrentRoom.Id))
            {
                Map.Add(GetNewRoom(Dungeon.CurrentRoom));
                AlreadyInMap.Add(Dungeon.CurrentRoom.Id);
                /*If map has already been picked up, add to Icons as well*/
                if (MapPickup) Icons.Add(GetNewRoom(Dungeon.CurrentRoom));
            }
        }
        public void UpdateHudLinkLoc()
        {
            if (MapPickup)
            {
                Icons.Remove(LinkBlock);
                int deltaX = (Dungeon.CurrentRoom.RoomPos.X - CurrentRoom.RoomPos.X) * BLOCK_SIZE * Global.Var.SCALE;
                if (deltaX != 0)
                {
                    LinkBlock.X += deltaX;
                }
                else
                {
                    int deltaY = (Dungeon.CurrentRoom.RoomPos.Y - CurrentRoom.RoomPos.Y) * BLOCK_SIZE * Global.Var.SCALE;
                    LinkBlock.Y += deltaY;
                }
                Icons.Add(LinkBlock);
            }
        }

        public IEntity GetNewRoom(IRoom room)
        {
            int input = room.RoomType;
            int x = room.RoomPos.X * Global.Var.SCALE;
            int y = room.RoomPos.Y * Global.Var.SCALE;
            IEntity roomEntity = new DoorRightRoom(new Vector2(0,0));
            switch (input)
            {
                case 1:
                    roomEntity = new DoorRightRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 2:
                    roomEntity = new DoorLeftRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 3:
                    roomEntity = new DoorLeftRightRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 4:
                    roomEntity = new DoorBotRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 5:
                    roomEntity = new DoorBotRightRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 6:
                    roomEntity = new DoorBotLeftRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 7:
                    roomEntity = new DoorBotLeftRightRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 8:
                    roomEntity = new DoorTopRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 9:
                    roomEntity = new DoorTopRightRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 10:
                    roomEntity = new DoorTopLeftRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 11:
                    roomEntity = new DoorTopLeftRightRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 12:
                    roomEntity = new DoorTopBotRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 13:
                    roomEntity = new DoorTopBotRightRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 14:
                    roomEntity = new DoorTopBotLeftRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
                case 15:
                    roomEntity = new DoorAllSidesRoom(new Vector2(x * BLOCK_SIZE + DUNGEON_INSIDE_MAP_X, y * BLOCK_SIZE + DUNGEON_INSIDE_MAP_Y));
                    break;
            }
            return roomEntity;

        }
    }
}
