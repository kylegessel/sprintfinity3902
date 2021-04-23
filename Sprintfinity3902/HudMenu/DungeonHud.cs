using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

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

        private HudInitializer hudInitializer;
        private bool MapPickup;
        private IEntity LinkBlock;
        private IRoom CurrentRoom;
        public List<IEntity> Map { get; private set; }
        public List<int> AlreadyInMap { get; set; }

        /*Added to create Singleton*/
        private static DungeonHud instance;
        public static DungeonHud Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DungeonHud();
                }
                return instance;
            }
        }

        public DungeonHud()
        {
            MapPickup = false;
            Icons = new List<IEntity>();
            Map = new List<IEntity>();
            AlreadyInMap = new List<int>();
            hudInitializer = new HudInitializer(this);
            WorldPoint = new Vector2(0, 0);
        }

        public override void Initialize()
        {
            MapPickup = false;
            Icons.Clear();
            Map.Clear();
            AlreadyInMap.Clear();
            hudInitializer.InitializeDungeonHud();
        }

        

        public override void Update(GameTime gameTime)
        {
        }

        public void MapPickedUp()
        {
            int x = (CurrentRoom.RoomPos.X * BLOCK_SIZE + 2) * Global.Var.SCALE;
            int y = (CurrentRoom.RoomPos.Y * BLOCK_SIZE + 2) * Global.Var.SCALE;
            LinkBlock = new YellowLinkBlock(new Vector2(x + DUNGEON_INSIDE_MAP_X, y + DUNGEON_INSIDE_MAP_Y));
            foreach (IEntity room in Map)
            {
                Icons.Add(room);
            }
            Icons.Add(LinkBlock);
            Icons.Add(new MapIcon(new Vector2(MAP_ICON_X * Global.Var.SCALE, MAP_ICON_Y * Global.Var.SCALE)));
            MapPickup = true;
        }

        public void CreateCompassIcon()
        {
            Icons.Add(new CompassIcon(new Vector2(COMPASS_ICON_X * Global.Var.SCALE, COMPASS_ICON_Y * Global.Var.SCALE)));
        }

        public void SetInitialRoom(IRoom room)
        {
            
            CurrentRoom = room;
            //UpdateHudLinkLoc(room);
            //UpdateHudRooms(room);
            
        }

        public void RoomChange(IDungeon dungeon)
        {
            UpdateHudRooms(dungeon.CurrentRoom);
            UpdateHudLinkLoc(dungeon.CurrentRoom);
            CurrentRoom = dungeon.CurrentRoom;
        }

        private void UpdateHudRooms(IRoom room)
        {
            /*Add every room Link is in into the Map List*/
            if (!AlreadyInMap.Contains(room.Id))
            {
                Map.Add(GetNewRoom(room));
                AlreadyInMap.Add(room.Id);
                /*If map has already been picked up, add to Icons as well*/
                if (MapPickup)
                {
                    Icons.Remove(LinkBlock);
                    Icons.Add(GetNewRoom(room));
                    Icons.Add(LinkBlock);
                }
                
            }
        }
       // private void UpdateHudLinkLoc(IDungeon dungeon)
        private void UpdateHudLinkLoc(IRoom room)
        {
            if (MapPickup)
            {
                int deltaX = (room.RoomPos.X - CurrentRoom.RoomPos.X) * BLOCK_SIZE * Global.Var.SCALE;
                if (deltaX != 0)
                {
                    LinkBlock.X += deltaX;
                }
                else
                {
                    int deltaY = (room.RoomPos.Y - CurrentRoom.RoomPos.Y) * BLOCK_SIZE * Global.Var.SCALE;
                    LinkBlock.Y += deltaY;
                }
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
