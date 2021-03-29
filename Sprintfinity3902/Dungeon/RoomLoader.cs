using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Entities.Doors;
using Sprintfinity3902.Interfaces;
using System;
using System.IO;

namespace Sprintfinity3902.Dungeon
{
    /*MAGIC NUMBERS REFACTOR*/
    public class RoomLoader
    {

        /*MAGIC NUMBERS REFACTOR*/
        private static int ONE = 1;
        private static int TWO = 2;
        private static int FOUR = 4;
        private static int EIGHT = 8;
        private static int ELEVEN = 11;
        private static int TWELVE = 12;
        private static int THIRTY_TWO = 32;
        private static int FIFTY = 50;
        private static int SIXTY_FOUR = 64;
        private static int EIGHTY = 80;
        private static int NINETY_SIX = 96;
        private static int ONE_HUNDRED_FIVE = 105;
        private static int ONE_HUNDRED_TWELVE = 112;
        private static int ONE_HUNDRED_THIRTY_SIX = 136;
        private static int ONE_HUNDRED_SIXTY = 160;
        private static int TWO_HUNDRED_EIGHT = 208;
        private static int TWO_HUNDRED_TWENTY_FOUR = 224;

        StreamReader mapStream;
        private IRoom Room { get; set; }
        private Vector2 Position { get; set; }
        public IDoor DoorTop { get; set; }
        public IDoor DoorBottom { get; set; }
        public IDoor DoorLeft { get; set; }
        public IDoor DoorRight { get; set; }
        int enemyID;
        int spikeNum;
        

        // Have this input a filename and then load the room.
        public RoomLoader(IRoom room)
        {
            // Really think there is a better way to list these files, just a demo for the time being though.
            Room = room;
            mapStream = new StreamReader(Room.path);
            spikeNum = 1;
            enemyID = 0;

        }

        public void Build()
        {
            string line;
            int currX = THIRTY_TWO * Global.Var.SCALE;
            int currY = NINETY_SIX*Global.Var.SCALE;
            Position = new Vector2(currX, currY);

            for (int i = 0; i < 2; i++)
            {
                line = mapStream.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');
                    BuildWallAndFloor(lineValues[0]);
                }
            }

            // add fake entitities
            for (int i = 0; i < 7; i++)
            {
                line = mapStream.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] lineValues = line.Split(',');
                    for(int j = 0; j < 12; j++)
                    {
                        BuildBlocks(lineValues[j]);
                        currX += Global.Var.TILE_SIZE * Global.Var.SCALE;
                        if(currX == Global.Var.TILE_SIZE*Global.Var.SCALE * TWELVE + THIRTY_TWO * Global.Var.SCALE)
                        {
                            currX = THIRTY_TWO * Global.Var.SCALE;
                            currY += Global.Var.TILE_SIZE * Global.Var.SCALE;
                        }
                        Position = new Vector2(currX, currY);
                    }
                }
            }

            if(Room.Id != 13)
            {
                DoorTop = new Door(new Vector2(ONE_HUNDRED_TWELVE * Global.Var.SCALE, SIXTY_FOUR * Global.Var.SCALE));
                DoorBottom = new Door(new Vector2(ONE_HUNDRED_TWELVE * Global.Var.SCALE, TWO_HUNDRED_EIGHT * Global.Var.SCALE));
                DoorLeft = new Door(new Vector2(0, ONE_HUNDRED_THIRTY_SIX * Global.Var.SCALE));
                DoorRight = new Door(new Vector2(TWO_HUNDRED_TWENTY_FOUR * Global.Var.SCALE, ONE_HUNDRED_THIRTY_SIX * Global.Var.SCALE));
                Room.blocks.Add(DoorTop);
                Room.blocks.Add(DoorBottom);
                Room.blocks.Add(DoorLeft);
                Room.blocks.Add(DoorRight);
                for (int i = 0; i < 4; i++)
                {
                    line = mapStream.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] lineValues = line.Split(',');
                        BuildDoors(lineValues[0], lineValues[1]);
                    }
                }
            }
        }

        public void BuildWallAndFloor(string input)
        {
            switch (input)
            {
                //WALLS AND FLOORS
                case "RMEX":
                    Room.blocks.Add(new RoomExterior(new Vector2(0, SIXTY_FOUR * Global.Var.SCALE)));
                    //add all 8

                    Room.blocks.Add(new VerticalWall(new Vector2 (0, SIXTY_FOUR * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(0, ONE_HUNDRED_SIXTY * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(TWO_HUNDRED_TWENTY_FOUR * Global.Var.SCALE, SIXTY_FOUR * Global.Var.SCALE)));
                    Room.blocks.Add(new VerticalWall(new Vector2(TWO_HUNDRED_TWENTY_FOUR * Global.Var.SCALE, ONE_HUNDRED_SIXTY * Global.Var.SCALE)));

                    Room.blocks.Add(new HorizontalWall(new Vector2(0, SIXTY_FOUR * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(0, TWO_HUNDRED_EIGHT * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(ONE_HUNDRED_THIRTY_SIX * Global.Var.SCALE, SIXTY_FOUR * Global.Var.SCALE)));
                    Room.blocks.Add(new HorizontalWall(new Vector2(ONE_HUNDRED_THIRTY_SIX * Global.Var.SCALE, TWO_HUNDRED_EIGHT * Global.Var.SCALE)));






                    break;
                case "RMIN":
                    Room.blocks.Add(new RoomInterior(new Vector2(THIRTY_TWO * Global.Var.SCALE, NINETY_SIX * Global.Var.SCALE)));
                    break;
                case "RM08":
                    Room.blocks.Add(new Room8Interior(new Vector2(THIRTY_TWO * Global.Var.SCALE, NINETY_SIX * Global.Var.SCALE)));
                    Room.blocks.Add(new Room8Text(new Vector2(FIFTY * Global.Var.SCALE, ONE_HUNDRED_FIVE * Global.Var.SCALE)));
                    break;
                case "RM13":
                    Room.blocks.Add(new Room13(new Vector2(0 * Global.Var.SCALE, EIGHTY * Global.Var.SCALE)));
                    break;
                case " ":
                    break;

            }
        }

        public void BuildBlocks(string input)
        {
            /*This is all implimenting class objects instead on interface. Do i need to change this?*/
            switch (input)
            {
                //BLOCKS
                case "TILE":
                    IBlock tile = new FloorBlock(Position);
                    Room.blocks.Add(tile);
                    break;
                case "BLOK":
                    IBlock blok = new RegularBlock(Position);
                    Room.blocks.Add(blok);
                    break;
                case "RFSH":
                    IBlock rfsh = new Face1Block(Position);
                    Room.blocks.Add(rfsh);
                    break;
                case "LFSH":
                    IBlock lfsh = new Face2Block(Position);
                    Room.blocks.Add(lfsh);
                    break;
                case "SPOT":
                    IBlock spot = new SpottedBlock(Position);
                    Room.blocks.Add(spot);
                    break;
                case "BLCK":
                    IBlock blck = new BlackBlock(Position);
                    Room.blocks.Add(blck);
                    break;
                case "BRIK":
                    IBlock brik = new BrickBlock(Position);
                    Room.blocks.Add(brik);
                    break;
                case "DARK":
                    IBlock dark = new DarkBlueBlock(Position);
                    Room.blocks.Add(dark);
                    break;
                case "STAR":
                    IBlock star = new StairsBlock(Position);
                    Room.blocks.Add(star);
                    break;
                case "STIP":
                    IBlock stip = new StripeBlock(Position);
                    Room.blocks.Add(stip);
                    break;
                case "MVBK":
                    IBlock mvbk = new MovingVertBlock(Position);
                    Room.blocks.Add(mvbk);
                    break;
                case "MLBK":
                    IBlock mlbk = new MovingLeftBlock(Position);
                    Room.blocks.Add(mlbk);
                    break;

                //ENEMIES
                case "BBAT":
                    IEntity bat = new BlueBatEnemy(Position);
                    Room.enemies.Add(enemyID, bat);
                    enemyID++;
                    break;
                case "SKLN":
                    IEntity skel = new SkeletonEnemy(Position);
                    Room.enemies.Add(enemyID, skel);
                    enemyID++;
                    break;
                case "BOSS":
                    IAttack up = new FireAttack(1);
                    IAttack center = new FireAttack(0);
                    IAttack down = new FireAttack(2);
                    Room.enemies.Add(enemyID, up);
                    enemyID++;
                    Room.enemies.Add(enemyID, down);
                    enemyID++;
                    Room.enemies.Add(enemyID, center);
                    enemyID++;
                    Room.enemies.Add(enemyID, new FinalBossEnemy(Position, up, center, down));
                    enemyID++;
                    break;
                case "FIRE":
                    IEntity fire = new Fire(Position);
                    Room.enemies.Add(enemyID, fire);
                    enemyID++;
                    break;
                case "GELY":
                    IEntity gel = new GelEnemy(Position);
                    gel.X = gel.Position.X + FOUR * Global.Var.SCALE;
                    gel.Y = gel.Position.Y + FOUR * Global.Var.SCALE;
                    Room.enemies.Add(enemyID, gel);
                    enemyID++;
                    break;
                case "GORY":
                    IBoomerang goriyaBoomerang = new BoomerangItem();
                    IEntity goriya = new GoriyaEnemy(goriyaBoomerang, Position);
                    Room.enemyProj.Add(goriyaBoomerang);
                    Room.enemies.Add(enemyID, goriya);
                    enemyID++;
                    break;
                case "HAND":
                    IEntity hand = new HandEnemy(Position);
                    Room.enemies.Add(enemyID, hand);
                    enemyID++;
                    break;
                case "OLDM":
                    IEntity man = new OldManNPC(Position);
                    man.X = man.Position.X + EIGHT * Global.Var.SCALE;
                    Room.enemies.Add(enemyID, man);
                    enemyID++;
                    break;
                case "SPKE":
                    IEntity spike = new SpikeEnemy(Position, spikeNum);
                    Room.enemies.Add(enemyID, spike);
                    enemyID++;
                    spikeNum++;
                    if(spikeNum > 4) { spikeNum = 1; }
                    break;


                //ITEMS
                // Probably could use a static bomb and boomerang object now that I think of it.
                case "KEYI":
                    IItem key = new KeyItem(Position);
                    key.X = key.Position.X + FOUR * Global.Var.SCALE;
                    Room.items.Add(key);
                    break;
                case "BOWI":
                    IItem bow = new BowItem(Position);
                    Room.items.Add(bow);
                    break;
                case "CLCK":
                    IItem clock = new ClockItem(Position);
                    Room.items.Add(clock);
                    break;
                case "CMPS":
                    IItem compass = new CompassItem(Position);
                    compass.X = compass.Position.X + TWO * Global.Var.SCALE;
                    compass.Y = compass.Position.Y + TWO * Global.Var.SCALE;
                    Room.items.Add(compass);
                    break;
                case "FARY":
                    IItem fairy = new FairyItem(Position);
                    Room.items.Add(fairy);
                    break;
                case "HCON":
                    IItem hcont = new HeartContainerItem(Position);
                    hcont.X = hcont.Position.X + ONE * Global.Var.SCALE;
                    hcont.Y = hcont.Position.Y + ONE * Global.Var.SCALE;
                    Room.items.Add(hcont);
                    break;
                case "HART":
                    IItem heart = new HeartItem(Position);
                    Room.items.Add(heart);
                    break;
                case "MAPI":
                    IItem map = new MapItem(Position);
                    map.X = map.Position.X + FOUR * Global.Var.SCALE;
                    Room.items.Add(map);
                    break;
                case "RUPE":
                    IItem rupee = new RupeeItem(Position);
                    Room.items.Add(rupee);
                    break;
                case "TRIF":
                    IItem triforce = new TriforceItem(Position);
                    triforce.X = triforce.Position.X + ELEVEN * Global.Var.SCALE;
                    triforce.Y = triforce.Position.Y + ELEVEN * Global.Var.SCALE;
                    Room.items.Add(triforce);
                    break;

            }
        }

        public void BuildDoors(string input, string destination)
        {
            switch (input)
            {
                // DOORS
                case "WALT":
                    DoorTop.SetState(DoorBottom.wallTop);
                    DoorTop.DoorDestination = Int16.Parse(destination);
                    break;
                case "WALB":
                    DoorBottom.SetState(DoorBottom.wallBottom);
                    DoorBottom.DoorDestination = Int16.Parse(destination);
                    break;
                case "WALL":
                    DoorLeft.SetState(DoorBottom.wallLeft);
                    DoorLeft.DoorDestination = Int16.Parse(destination);
                    break;
                case "WALR":
                    DoorRight.SetState(DoorBottom.wallRight);
                    DoorRight.DoorDestination = Int16.Parse(destination);
                    break;
                case "ODRT":
                    DoorTop.SetState(DoorTop.openDoorTop);
                    DoorTop.DoorDestination = Int16.Parse(destination);
                    break;
                case "ODRB":
                    DoorBottom.SetState(DoorTop.openDoorBottom);
                    DoorBottom.DoorDestination = Int16.Parse(destination);
                    break;
                case "ODRL":
                    DoorLeft.SetState(DoorTop.openDoorLeft);
                    DoorLeft.DoorDestination = Int16.Parse(destination);
                    break;
                case "ODRR":
                    DoorRight.SetState(DoorRight.openDoorRight);
                    DoorRight.DoorDestination = Int16.Parse(destination);
                    break;
                case "CDRT":
                    DoorTop.SetState(DoorTop.closedDoorTop);
                    DoorTop.DoorDestination = Int16.Parse(destination);
                    break;
                case "CDRB":
                    DoorBottom.SetState(DoorTop.closedDoorBottom);
                    DoorBottom.DoorDestination = Int16.Parse(destination);
                    break;
                case "CDRL":
                    DoorLeft.SetState(DoorTop.closedDoorLeft);
                    DoorLeft.DoorDestination = Int16.Parse(destination);
                    break;
                case "CDRR":
                    DoorRight.SetState(DoorRight.closedDoorRight);
                    DoorRight.DoorDestination = Int16.Parse(destination);
                    break;
                case "LDRT":
                    DoorTop.SetState(DoorTop.lockedDoorTop);
                    DoorTop.DoorDestination = Int16.Parse(destination);
                    break;
                case "LDRB":
                    DoorBottom.SetState(DoorTop.lockedDoorBottom);
                    DoorBottom.DoorDestination = Int16.Parse(destination);
                    break;
                case "LDRL":
                    DoorLeft.SetState(DoorTop.lockedDoorLeft);
                    DoorLeft.DoorDestination = Int16.Parse(destination);
                    break;
                case "LDRR":
                    DoorRight.SetState(DoorRight.lockedDoorRight);
                    DoorRight.DoorDestination = Int16.Parse(destination);
                    break;
                case "HDRT":
                    DoorTop.SetState(DoorTop.holeDoorTop);
                    DoorTop.DoorDestination = Int16.Parse(destination);
                    break;
                case "HDRB":
                    DoorBottom.SetState(DoorTop.holeDoorBottom);
                    DoorBottom.DoorDestination = Int16.Parse(destination);
                    break;
                case "HDRL":
                    DoorLeft.SetState(DoorTop.holeDoorLeft);
                    DoorLeft.DoorDestination = Int16.Parse(destination);
                    break;
                case "HDRR":
                    DoorRight.SetState(DoorRight.holeDoorRight);
                    DoorRight.DoorDestination = Int16.Parse(destination);
                    break;
            }

        }
    }
}
